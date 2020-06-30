using System;
using System.Collections.Generic;
using System.Linq;
using Flatik.Monitoring.Extensions;
using Flatik.Monitoring.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Flatik.Monitoring.Deserializers
{
    internal class OnlinerDeserializer : IDeserializer
    {
        public IEnumerable<SiteModel> Deserialize(string json)
        {
            var deserializedObject = (JObject) JsonConvert.DeserializeObject(json);
            var apartments = deserializedObject.Value<JArray>("apartments").Select(ToSiteModel);

            return apartments;
        }

        private SiteModel ToSiteModel(JToken json) => new SiteModel
        {
            Id = json["id"].Value<int>(),
            Rooms = json["rent_type"].Value<string>()[0].ToInt(),
            IsOwner = json["contact"].Value<JObject>().Value<bool>("owner"),
            UsdPrice = Convert.ToInt32(json["price"].Value<double>("amount")),
            BynPrice = Convert.ToInt32(json["price"].Value<JObject>("converted").Value<JObject>("BYN").Value<double>("amount")),
            Link = json["url"].Value<string>()
        };
    }
}