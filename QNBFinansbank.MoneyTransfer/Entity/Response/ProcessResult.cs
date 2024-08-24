namespace QNBFinansbank.MoneyTransfer.Entity.Response
{
    public class ProcessResult : IDto
    {
        /// <summary>
        /// İşlemin başarılı olup olmadığını belirten bir değer. 
        /// <c>true</c> değeri işlem başarılı, <c>false</c> değeri işlem başarısız olduğunu gösterir.
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// İşlem sonucunun durum kodunu belirten bir değer. 
        /// Bu kod, işlemin sonucunu daha ayrıntılı tanımlamak için kullanılır.
        /// Örneğin, 10000 başarılı bir işlemi, diğer değerler ise hata durumlarını gösterebilir.
        /// </summary>
        public int ResultCode { get; set; }

        /// <summary>
        /// İşlemin sonucuna ilişkin açıklayıcı bir mesaj. 
        /// Bu mesaj, işlem sonucu hakkında daha fazla bilgi sağlar veya hata durumlarını açıklar.
        /// </summary>
        public string ResultMessage { get; set; } = string.Empty;
    }
}
