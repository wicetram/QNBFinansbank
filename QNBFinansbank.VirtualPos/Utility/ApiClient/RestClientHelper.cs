using RestSharp;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using QNBFinansbank.VirtualPos.Entity.Request.Check;
using QNBFinansbank.VirtualPos.Utility.Serialization;

namespace QNBFinansbank.VirtualPos.Utility.ApiClient
{
    public static class RestClientHelper
    {
        /// <summary>
        /// Verilen model nesnesini XML formatında serileştirerek belirtilen HTTP yöntemi ve URL ile bir REST API isteği yapar ve yanıtı döner.
        /// Bu yardımcı metot, çeşitli HTTP yöntemleri (POST, GET, vb.) kullanarak REST API çağrıları yapmak için kullanılır.
        /// </summary>
        /// <param name="modal">API'ye gönderilecek olan model nesnesi. XML formatında serileştirilir.</param>
        /// <param name="method">HTTP yöntemi (POST, GET, PUT, DELETE, vb.)</param>
        /// <param name="baseUrl">API çağrısının yapılacağı temel URL.</param>
        /// <returns>
        /// API'den dönen yanıtı içeren <see cref="RestResponse"/> nesnesi.
        /// </returns>
        public static RestResponse RestXmlExecuteHelper(object modal, Method method, string? baseUrl)
        {
            var request = new RestRequest { Method = method };
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddParameter("text/xml", modal, ParameterType.RequestBody);

            // API'ye gönderilecek olan REST istemcisinin oluşturulması.
            var client = new RestClient($"{baseUrl}");
            var response = client.Execute(request);

            return response;
        }
    }
}
