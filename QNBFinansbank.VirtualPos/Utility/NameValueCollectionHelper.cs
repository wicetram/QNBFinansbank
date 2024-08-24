using System.Collections.Specialized;
using System.Reflection;
using System.Text;

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
            AddPropertiesToCollection(dto, nameValueCollection);
            return nameValueCollection;
        }

        /// <summary>
        /// Bir nesnenin özelliklerini NameValueCollection'a ekler.
        /// </summary>
        /// <param name="obj">NameValueCollection'a özellikleri eklenecek nesne.</param>
        /// <param name="collection">Özelliklerin ekleneceği NameValueCollection.</param>
        private static void AddPropertiesToCollection(object obj, NameValueCollection collection)
        {
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                object? value = property.GetValue(obj);
                if (value != null)
                {
                    // Eğer property bir sınıf ise, bu sınıfın da özelliklerini dolaş
                    if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                    {
                        AddPropertiesToCollection(value, collection);
                    }
                    else
                    {
                        collection.Add(property.Name, value.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Verilen NameValueCollection ve action URL'sine göre otomatik olarak submit eden bir HTML formu oluşturur.
        /// </summary>
        /// <param name="collection">Form alanlarını temsil eden NameValueCollection nesnesi.</param>
        /// <param name="actionUrl">Formun gönderileceği URL.</param>
        /// <returns>Otomatik olarak submit eden bir HTML formunu temsil eden string.</returns>
        public static string GenerateHtmlForm(NameValueCollection collection, string? actionUrl)
        {
            StringBuilder sb = new();
            sb.AppendLine("<html>");
            sb.AppendLine("<body onload='document.forms[0].submit()'>");
            sb.AppendLine($"<form name='PostForm' id='paymentForm' method='POST' action='{actionUrl}'><div hidden='hidden'>");

            var inputFields = collection.AllKeys
                                        .Select(key => $"<input type='hidden' type='text' name='{key}' value='{collection[key]}' />");

            sb.AppendLine(string.Join(Environment.NewLine, inputFields));

            sb.AppendLine("</div>");
            sb.AppendLine("</form>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}
