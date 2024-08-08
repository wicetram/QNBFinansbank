namespace QNBFinansbank.VirtualPos.Entity.Request
{
    public class AccountDto : IDto
    {
        /// <summary>
        /// Kurum kodu. 
        /// Bu kod, üye işyerinin veya kurumun tanımlanmasında kullanılan benzersiz bir koddur.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? MbrId { get; set; }

        /// <summary>
        /// Üye işyeri numarası. 
        /// Bu numara, ödeme işlemlerini gerçekleştiren işyerinin tanımlayıcısıdır.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? MerchantId { get; set; }

        /// <summary>
        /// 3D Secure şifresi. 
        /// Bu şifre, 3D Secure ödeme işlemlerinde kullanılan güvenlik kodudur.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? MerchantPass { get; set; }

        /// <summary>
        /// Kullanıcı kodu. 
        /// Bu kod, işlemleri gerçekleştiren kullanıcının tanımlayıcısıdır.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? UserCode { get; set; }

        /// <summary>
        /// Kullanıcı şifresi. 
        /// Bu şifre, kullanıcının kimliğini doğrulamak için kullanılır.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? UserPass { get; set; }

        /// <summary>
        /// Sanal pos işlem güvenlik türü. 
        /// İşlemin güvenlik seviyesini belirten bir türdür. Olası değerler: 
        /// <c>NonSecure</c> (güvenliksiz), <c>3DPay</c> (3D Secure ödeme), 
        /// <c>3DModel</c> (3D Secure model), <c>3DPayHosting</c> (3D Secure ödeme barındırma).
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SecureType { get; set; }

        /// <summary>
        /// İşlem tipi. 
        /// Bu özellik, gerçekleştirilecek işlem türünü belirtir. Olası değerler:
        /// <c>Auth</c> (ödeme), <c>Void</c> (iptal), <c>Refund</c> (iade).
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? TxnType { get; set; }

        /// <summary>
        /// Banka linki. 
        /// Bu URL, sanal pos işlemlerinin gerçekleştirileceği banka sistemine bağlantı sağlar.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? BaseUrl { get; set; }
    }
}
