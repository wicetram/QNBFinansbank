namespace QNBFinansbank.VirtualPos.Constant
{
    public static class TxnTypes
    {
        /// <summary>
        /// Satış işlemi veya taksitli satış işlemi için yetkilendirme.
        /// </summary>
        public const string Auth = "Auth";

        /// <summary>
        /// İptal işlemi.
        /// </summary>
        public const string Void = "Void";

        /// <summary>
        /// İade işlemi.
        /// </summary>
        public const string Refund = "Refund";

        /// <summary>
        /// Sipariş sorgulama işlemi.
        /// </summary>
        public const string OrderInquiry = "OrderInquiry";

        /// <summary>
        /// İşlem geçmişi sorgulama.
        /// </summary>
        public const string TxnHistory = "TxnHistory";

        /// <summary>
        /// Ön provizyon işlemi.
        /// </summary>
        public const string PreAuth = "PreAuth";

        /// <summary>
        /// Ön provizyon kapama işlemi.
        /// </summary>
        public const string PostAuth = "PostAuth";

        /// <summary>
        /// Gün sonu kapama işlemi.
        /// </summary>
        public const string BatchClose = "BatchClose";

        /// <summary>
        /// Gün sonu detay sorgulama işlemi.
        /// </summary>
        public const string EodDetail = "EodDetail";

        /// <summary>
        /// Seçmeli kampanya sorgulama işlemi.
        /// </summary>
        public const string OptCampaignInquiry = "OptCampaignInquiry";

        /// <summary>
        /// Para puan kullanım yetkilendirme işlemi.
        /// </summary>
        public const string ParaPuanAuth = "ParaPuanAuth";

        /// <summary>
        /// Para puan sorgulama işlemi.
        /// </summary>
        public const string ParaPuanInquiry = "ParaPuanInquiry";

        /// <summary>
        /// Para puan iade işlemi.
        /// </summary>
        public const string ParaPuanRefund = "ParaPuanRefund";

        /// <summary>
        /// Para puan işlemi iptali.
        /// </summary>
        public const string ParaPuanVoid = "ParaPuanVoid";

        /// <summary>
        /// Segment sorgulama işlemi.
        /// </summary>
        public const string SegmentInquiry = "SegmentInquiry";

        /// <summary>
        /// Tekrarlı ödeme işlemi.
        /// </summary>
        public const string RecurringPayment = "RECURRINGPAYMENT";

        /// <summary>
        /// Tekrarlı ödeme kontrol işlemi.
        /// </summary>
        public const string CheckRecurringPayment = "CPOSINQUIRY";
    }

}
