namespace QNBFinansbank.VirtualPos.Entity.Response.History
{
    /// <summary>
    /// İşlem geçmişi sorgulama yanıtını temsil eden DTO.
    /// Bu sınıf, ödeme isteği ve ödeme adresi gibi işlem geçmişine ait detayları içerir.
    /// </summary>
    public class HistoryResponseDataDto : IDto
    {
        /// <summary>
        /// İşlem geçmişine ait ödeme isteği detaylarını içerir.
        /// </summary>
        public HistoryResponseDataDtoPaymentRequestDto? PaymentRequest { get; set; }

        /// <summary>
        /// İşlem geçmişine ait ödeme adresi detaylarını içerir.
        /// </summary>
        public HistoryResponseDataDtoPaymentAddressDto? PaymentAddress { get; set; }

        /// <summary>
        /// İşlemle ilgili ek parametreleri içeren bir liste.
        /// </summary>
        public List<List<string?>>? ExtraParameters { get; set; }
    }
}
