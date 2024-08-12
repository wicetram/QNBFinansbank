namespace QNBFinansbank.VirtualPos.Entity.Response.History
{
    /// <summary>
    /// İşlem geçmişi sorgulama yanıtını temsil eden DTO.
    /// Bu sınıf, ödeme isteği ve ödeme adresi gibi işlem geçmişine ait detayları içerir.
    /// </summary>
    public class HistoryResponseDto : IDto
    {
        /// <summary>
        /// İşlem geçmişine ait ödeme isteği detaylarını içerir.
        /// </summary>
        public HistoryResponseDtoPaymentRequestDto? PaymentRequest { get; set; }

        /// <summary>
        /// İşlem geçmişine ait ödeme adresi detaylarını içerir.
        /// </summary>
        public HistoryResponseDtoPaymentAddressDto? PaymentAddress { get; set; }

        /// <summary>
        /// İşlemle ilgili ek parametreleri içeren bir liste.
        /// </summary>
        public List<List<string?>>? ExtraParameters { get; set; }
    }
}
