using System;
using System.Collections.Generic;
using System.Linq;
using Flatik.Monitoring.Extensions;
using Flatik.Monitoring.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Flatik.Monitoring.Deserializers
{
    internal class OnlinerDeserializer : BaseDeserializer
    {
        public OnlinerDeserializer(string siteName) : base(siteName) { }

        public override IEnumerable<Flat> Deserialize(string json)
        {
            var deserializedObject = (JObject) JsonConvert.DeserializeObject(json);
            var flats = deserializedObject.Value<JArray>("apartments").Select(ToSiteModel);

            return flats;
        }

        private Flat ToSiteModel(JToken json) => new Flat
        {
            Id = json["id"].Value<int>(),
            Site = SiteName,
            Rooms = json["rent_type"].Value<string>()[0].ToInt(),
            IsOwner = json["contact"].Value<JObject>().Value<bool>("owner"),
            UsdPrice = Convert.ToInt32(json["price"].Value<double>("amount")),
            BynPrice = Convert.ToInt32(json["price"].Value<JObject>("converted").Value<JObject>("BYN").Value<double>("amount")),
            Link = json["url"].Value<string>(),
            CreatedAt = json["created_at"].Value<DateTime>(),
            UpAt = json["last_time_up"].Value<DateTime>()
        };
    }
}