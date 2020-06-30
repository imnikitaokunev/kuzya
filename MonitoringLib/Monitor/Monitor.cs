using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Flatik.Monitoring.Deserializers;
using Flatik.Monitoring.Extensions;
using Flatik.Monitoring.Models;
using Flatik.Monitoring.Settings;

namespace Flatik.Monitoring.Monitor
{
    public class Monitor
    {
        private readonly MonitoringSettings _settings;

        public Monitor(MonitoringSettings settings)
        {
            _settings = settings;
        }

        public IEnumerable<SiteModel> Run()
        {
            var result = new List<SiteModel>();

            foreach (var site in _settings.Sites)
            {
                var models = SendRequest(site);
                result.AddRange(models);
            }

            return result;
        }

        private IEnumerable<SiteModel> SendRequest(SiteSettings site)
        {
            var baseUrl = site.Url;
            var queryString = site.Parameters.ToQueryString();

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(queryString).Result;
            if (!response.IsSuccessStatusCode)
            {
                // TODO: Throw an exception.
                return null;
            }

            var result = response.Content.ReadAsStringAsync().Result;
            //var json = (JObject)JsonConvert.DeserializeObject(result);
            var type = Type.GetType(site.DeserializerType);

            // TODO: Create helper creator.

            var helper = Activator.CreateInstance(type) as IDeserializer;

            if (helper != null)
            {
                var deserializedObject = helper.Deserialize(result);
                return deserializedObject;
            }

            //using (var webClient = new System.Net.WebClient())
            //{
            //    var jsonString = webClient.DownloadString(url);
            //    var json = (JObject)JsonConvert.DeserializeObject(jsonString);
            //    // Now parse with JSON.Net
            //}

            return null;
        }
    }
}
