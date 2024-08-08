using QNBFinansbank.VirtualPos.Entity.Response;

namespace QNBFinansbank.VirtualPos.Utilities
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

        /// <summary>
        /// Ödeme verilerini döndüren metot.
        /// </summary>
        /// <param name="orderId">Sipariş numarası.</param>
        /// <returns>Ödeme verilerini temsil eden <see cref="PaymentData"/> nesnesi.</returns>
        public static PaymentData GetPayment(string? orderId)
        {
            return new PaymentData
            {
                OrderId = Convert.ToInt32(orderId),
            };
        }

        /// <summary>
        /// Ödeme verilerini döndüren metot.
        /// </summary>
        /// <param name="orderId">Sipariş numarası.</param>
        /// <param name="paymentUrl">Ödeme URL'si.</param>
        /// <returns>Ödeme verilerini temsil eden <see cref="PaymentData"/> nesnesi.</returns>
        public static PaymentData GetPayment(string? orderId, string? paymentUrl)
        {
            return new PaymentData
            {
                OrderId = Convert.ToInt32(orderId),
                URL = paymentUrl
            };
        }
    }
}
