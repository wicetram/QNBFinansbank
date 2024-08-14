namespace QNBFinansbank.VirtualPos.Entity.Response.History
{
    /// <summary>
    /// İşlem geçmişine ait ödeme adresi detaylarını temsil eder.
    /// </summary>
    public class HistoryResponseDataDtoPaymentAddressDto : IDto
    {
        /// <summary>
        /// İstek için benzersiz GUID.
        /// </summary>
        public string? RequestGuid { get; set; }
    }
}
