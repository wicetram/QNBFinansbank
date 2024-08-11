namespace QNBFinansbank.VirtualPos.Entity.Request.Payment.ThreeD.ModelPayment
{
    /// <summary>
    /// 3D Model Payment işlemi için API isteğini temsil eden DTO sınıfı.
    /// Bu sınıf, 3D Model Payment işlemi sırasında gerekli olan parametreleri içerir.
    /// </summary>
    public class ThreeDModelPaymentRequestDto : IDto
    {
        /// <summary>
        /// Otorizasyon sistemi kullanıcı kodu. 
        /// (Bankadan temin edilir)
        /// </summary>
        public string? UserCode { get; set; }

        /// <summary>
        /// Otorizasyon sistemi kullanıcı şifresi. 
        /// (Bankadan temin edilir)
        /// </summary>
        public string? UserPass { get; set; }

        /// <summary>
        /// Üye işyeri tarafından üretilen işleme özgü bir numara. 
        /// Sipariş numarası olarak kullanılır.
        /// </summary>
        public string? OrderId { get; set; }

        /// <summary>
        /// İşlemin güvenlik türünü belirtir. 
        /// (Örneğin, 3DModelPayment)
        /// </summary>
        public string? SecureType { get; set; }

        /// <summary>
        /// İstek için oluşturulmuş benzersiz GUID. 
        /// Her işlem için benzersiz bir kimlik sağlar.
        /// </summary>
        public string? RequestGuid { get; set; }

        public string? BaseUrl { get; set; }
    }
}
