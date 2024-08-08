using System.Collections.Specialized;
using System.Reflection;

namespace QNBFinansbank.VirtualPos.Utility
{
    public static class NameValueCollectionHelper
    {
        /// <summary>
        /// Belirtilen DTO nesnesini kullanarak bir NameValueCollection oluşturur.
        /// </summary>
        /// <typeparam name="T">DTO türü.</typeparam>
        /// <param name="dto">NameValueCollection'a dönüştürülecek DTO nesnesi.</param>
        /// <returns>DTO'nun özellik adlarını ve değerlerini içeren NameValueCollection.</returns>
        public static NameValueCollection ToNameValueCollection<T>(T? dto) where T : class
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "DTO object cannot be null");
            }

            var nameValueCollection = new NameValueCollection();
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                string name = property.Name;
                object? value = property.GetValue(dto);
                if (value != null)
                {
                    nameValueCollection.Add(name, value.ToString());
                }
            }
            return nameValueCollection;
        }
    }
}
