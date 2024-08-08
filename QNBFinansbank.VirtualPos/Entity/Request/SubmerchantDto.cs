namespace QNBFinansbank.VirtualPos.Entity.Request
{
    public class SubmerchantDto : IDto
    {
        /// <summary>
        /// Alt üye işyeri numarası. 
        /// Bu özellik, alt üye işyerinin benzersiz tanımlayıcısını belirtir. 
        /// Örneğin, her alt üye işyerine özgü olan "12345678" gibi değerler alabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubmerchantId { get; set; }

        /// <summary>
        /// Alt üye işyeri ismi. 
        /// Bu özellik, alt üye işyerinin adını belirtir. 
        /// Örneğin, "ABC Ltd." gibi değerler alabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubmerchantName { get; set; }

        /// <summary>
        /// Alt üye işyeri websitesi. 
        /// Bu özellik, alt üye işyerinin web sitesinin URL'sini belirtir. 
        /// Örneğin, "https://www.abc.com" gibi değerler alabilir.
        /// Varsayılan değer olarak <c>null</c> olabilir.
        /// </summary>
        public string? SubmerchantIn { get; set; }
    }
}
