using QNBFinansbank.CashManagement.Business.Abstract;
using QNBFinansbank.CashManagement.Constant;
using QNBFinansbank.CashManagement.Entity.Request.GetTransaction;
using QNBFinansbank.CashManagement.Entity.Response.GetTransaction;
using QNBFinansbank.CashManagement.Utility.ResponseHandlers;
using QNBFinansbank.CashManagement.Utility.Serialization;
using RestSharp;

namespace QNBFinansbank.CashManagement.Business.Concrete
{
    public class CashManagementManager : ICashManagementService
    {
        public GetTransactionResponseDto GetTransaction(GetTransactionRequestDto transactionRequestDto)
        {
            try
            {
                var dto = new GetTransactionRequestDataDto
                {
                    Body = new GetTransactionRequestBody
                    {
                        GetTransactionInfo = new GetTransactionInfo
                        {
                            TransactionInfo = new TransactionInfoRequest
                            {
                                UserName = transactionRequestDto?.Account?.Username,
                                Password = transactionRequestDto?.Account?.Password,
                                TransactionInfoInputType = new TransactionInfoInputType
                                {
                                    AccountNo = transactionRequestDto?.Account?.AccountNo,
                                    Iban = transactionRequestDto?.Account?.IBAN,
                                    StartDate = transactionRequestDto?.TransactionInfo?.StartDate?.ToString("yyyy-MM-ddTHH:mm:ss"),
                                    EndDate = transactionRequestDto?.TransactionInfo?.EndDate?.ToString("yyyy-MM-ddTHH:mm:ss"),
                                }
                            }
                        }
                    }
                };

                string body = XmlHelper.SerializeToXml(dto);

                var request = new RestRequest { Method = Method.Post };
                request.AddHeader("Content-Type", "application/xml");
                request.AddHeader("SoapAction", $"{transactionRequestDto?.Account?.ActionUrl}");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                // API'ye gönderilecek olan REST istemcisinin oluşturulması.
                var client = new RestClient($"{transactionRequestDto?.Account?.BaseUrl}");
                var response = client.Execute(request);

                if (response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                {
                    return new GetTransactionResponseDto
                    {
                        Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Hesap hareketleri işlemi başarısız. Hata detayı: {response?.StatusCode} | {response?.ErrorException?.Message ?? response?.ErrorMessage}")
                    };
                }

                // API yanıtının deserialization işlemi.
                var result = GetList(response.Content);

                // İşleme ait sonuç döndürülmesi.
                return new GetTransactionResponseDto
                {
                    Result = ResponseHandler.GetResult(true, ResultCode.SuccessCode, $"Hesap hareketleri işlemi başarılı."),
                    Transaction = result
                };
            }
            catch (Exception ex)
            {
                // Beklenmeyen bir hata meydana gelirse, hata mesajıyla birlikte sonuç döndürülmesi.
                return new GetTransactionResponseDto
                {
                    Result = ResponseHandler.GetResult(false, ResultCode.FailCode, $"Hesap hareketleri işlemi sırasında tanımsız hata. Hata: {ex.Message}")
                };
            }
        }

        private GetTransactionResponseDataDto GetList(string? content)
        {
            throw new NotImplementedException();
        }
    }
}
