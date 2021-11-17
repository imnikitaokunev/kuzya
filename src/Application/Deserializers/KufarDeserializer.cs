using AngleSharp.Html.Parser;
using Application.Extensions;
using Application.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Application.Deserializers
{
    public class KufarDeserializer : BaseDeserializer
    {
        public KufarDeserializer(string siteName) : base(siteName) { }

        public override IEnumerable<Flat> Deserialize(string text)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(text);

            var jsonContentId = "__NEXT_DATA__";
            var json = document.GetElementById(jsonContentId).InnerHtml;

            var deserializedObject = (JObject)JsonConvert.DeserializeObject(json);
            var flats = deserializedObject
                .Value<JObject>("props")
                .Value<JObject>("initialState")
                .Value<JObject>("listing")
                .Value<JArray>("listingElements").Select(ToSiteModel);

            return flats;
        }

        private Flat ToSiteModel(JToken json) => new Flat
        {
            Id = json["id"].Value<long>(),
            Site = SiteName,
            Rooms = json["additionalParameters"].Value<string>()[0].ToInt(),
            IsOwner = !json["initial"].Value<bool>("company_ad"),
            UsdPrice = json["additionalPrice"].Value<string>("ru").ParseInt(),
            BynPrice = json["price"].Value<string>("ru").ParseInt(),
            UpAt = json["updateDate"].Value<DateTime>(),
            Link = json["adViewLink"].Value<string>()
        };
    }
}
