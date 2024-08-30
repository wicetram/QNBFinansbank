namespace QNBFinansbank.VirtualPos.Entity.Response
{
    /// <summary>
    /// Herhangi bir işlem sonucunu temsil eden veri transfer nesnesi.
    /// Bu sınıf, işlem sonucunun başarılı olup olmadığını, sonucunun durum kodunu ve açıklayıcı bir mesajı içerir.
    /// </summary>
    public class ProcessResult : IDto
    {
        /// <summary>
        /// İşlemin başarılı olup olmadığını belirten bir değer. 
        /// <c>true</c> değeri işlem başarılı, <c>false</c> değeri işlem başarısız olduğunu gösterir.
        /// Varsayılan değer <c>false</c> olarak belirlenmiştir.
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// İşlem sonucunun durum kodunu belirten bir değer. 
        /// Bu kod, işlemin sonucunu daha ayrıntılı tanımlamak için kullanılır.
        /// Örneğin, 10000 başarılı bir işlemi, diğer değerler ise hata durumlarını gösterebilir.
        /// Varsayılan değer 0'dır, bu da henüz bir işlem yapılmadığını gösterebilir.
        /// </summary>
        public int ResultCode { get; set; }

        /// <summary>
        /// İşlemin sonucuna ilişkin açıklayıcı bir mesaj. 
        /// Bu mesaj, işlem sonucu hakkında daha fazla bilgi sağlar veya hata durumlarını açıklar.
        /// Varsayılan değer boş bir stringdir.
        /// </summary>
        public string ResultMessage { get; set; } = string.Empty;
    }
}
