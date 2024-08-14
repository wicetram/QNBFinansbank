using QNBFinansbank.CashManagement.Entity.Response;

namespace QNBFinansbank.CashManagement.Utility.ResponseHandlers
{
    /// <summary>
    /// Yanıtları işlemek için yardımcı metotlar sağlayan sınıf.
    /// </summary>
    public static class ResponseHandler
    {
        /// <summary>
        /// İşlem sonucunu döndüren metot.
        /// </summary>
        /// <param name="result">İşlem sonucu başarılıysa true, değilse false.</param>
        /// <param name="code">İşlem sonucu kodu.</param>
        /// <param="message">İşlem sonucu mesajı.</param>
        /// <returns>İşlem sonucunu temsil eden <see cref="ProcessResult"/> nesnesi.</returns>
        public static ProcessResult GetResult(bool result, int code, string message)
        {
            return new ProcessResult
            {
                Result = result,
                ResultCode = code,
                ResultMessage = message
            };
        }
    }
}
