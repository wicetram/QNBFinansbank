namespace QNBFinansbank.VirtualPos.Constant
{
    /// <summary>
    /// Sanal POS işlemleri için kullanılan metot adlarını tutan sabitler sınıfıdır.
    /// </summary>
    public class MethodNames
    {
        /// <summary>
        /// İptal (Cancel) işlemi metot adı.
        /// </summary>
        public const string Cancel = "Cancel";

        /// <summary>
        /// Check işlemi metot adı.
        /// </summary>
        public const string Check = "Check";

        /// <summary>
        /// İade (Refund) işlemi metot adı.
        /// </summary>
        public const string Refund = "Refund";

        /// <summary>
        /// Ödeme (Payment) işlemi metot adı.
        /// </summary>
        public const string Payment = "Payment";

        /// <summary>
        /// 3D Model ödeme işlemi metot adı.
        /// </summary>
        public const string ThreeDModelPayment = "ThreeD Model Payment";

        /// <summary>
        /// Ön otorizasyon (Pre-Auth) işlemini sonlandırma metot adı.
        /// </summary>
        public const string StopPreAuth = "Stop Pre Auth";

        /// <summary>
        /// Para puan sorgulama işlemi metot adı.
        /// </summary>
        public const string CheckRewardPoints = "Check Reward Points";

        /// <summary>
        /// Para puan kullanımı ile ödeme işlemi metot adı.
        /// </summary>
        public const string UseRewardPoints = "Use Reward Points";

        /// <summary>
        /// İşlem geçmişi sorgulama metot adı.
        /// </summary>
        public const string History = "History";

        /// <summary>
        /// Toplu kapama (Batch Close) işlemi metot adı.
        /// </summary>
        public const string BatchClose = "Batch Close";

        /// <summary>
        /// Segment sorgulama işlemi metot adı.
        /// </summary>
        public const string SegmentInquiry = "Segment Inquiry";

        /// <summary>
        /// Raporlama işlemi metot adı.
        /// </summary>
        public const string Report = "Report";

        /// <summary>
        /// EOD Raporlama işlemi metot adı.
        /// </summary>
        public const string EOD = "EOD";

        /// <summary>
        /// Kampanya sorgulama işlemi metot adı.
        /// </summary>
        public const string CampaignCheck = "Campaign Check";

        /// <summary>
        /// Kampanyalı ödeme işlemi metot adı.
        /// </summary>
        public const string CampaignUsage = "Campaign Usage";
    }
}
