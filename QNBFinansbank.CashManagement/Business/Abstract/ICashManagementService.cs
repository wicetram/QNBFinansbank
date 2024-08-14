using QNBFinansbank.CashManagement.Entity.Request.GetTransaction;
using QNBFinansbank.CashManagement.Entity.Response.GetTransaction;

namespace QNBFinansbank.CashManagement.Business.Abstract
{
    public interface ICashManagementService
    {
        /// <summary>
        /// QNB Finansbank nakit yönetimi işlemlerini sorgular ve belirli bir işlem talebi için ilgili verileri döner.
        /// Bu yöntem, işlem sorgulama parametrelerini alarak ilgili işlem verilerini sağlar.
        /// </summary>
        /// <param name="transactionRequestDto">
        /// Sorgulama işlemini gerçekleştirmek için gerekli olan parametreleri içeren bir <see cref="GetTransactionRequestDto"/> nesnesi.
        /// Bu nesne, sorgulamak istediğiniz işlem aralığı, hesap bilgileri gibi detayları içerebilir.
        /// </param>
        /// <returns>
        /// İşlem verilerini içeren bir <see cref="GetTransactionResponseDto"/> nesnesi döner.
        /// Bu nesne, işlemin detaylarını, sorgulama sonucunu ve ilgili diğer bilgileri içerir.
        /// </returns>
        GetTransactionResponseDto GetTransaction(GetTransactionRequestDto transactionRequestDto);
    }
}
