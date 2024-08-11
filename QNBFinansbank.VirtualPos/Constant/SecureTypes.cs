namespace QNBFinansbank.VirtualPos.Constant
{
    public static class SecureTypes
    {
        /// <summary>
        /// Güvenliksiz işlem.
        /// </summary>
        public const string NonSecure = "NonSecure";

        /// <summary>
        /// 3D Secure ödeme.
        /// </summary>
        public const string ThreeDPay = "3DPay";

        /// <summary>
        /// 3D Secure model.
        /// </summary>
        public const string ThreeDModel = "3DModel";

        /// <summary>
        /// 3D Secure model ödeme.
        /// </summary>
        public const string ThreeDModelPayment = "3DModelPayment";

        /// <summary>
        /// 3D Secure ödeme barındırma.
        /// </summary>
        public const string ThreeDPayHosting = "3DPayHosting";

        /// <summary>
        /// Raporlama işlemi.
        /// </summary>
        public const string Report = "Report";

        /// <summary>
        /// Sipariş sorgulama işlemi.
        /// </summary>
        public const string Inquiry = "Inquiry";
    }
}
