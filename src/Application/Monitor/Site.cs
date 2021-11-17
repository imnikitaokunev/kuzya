using Application.Common.Interfaces;
using Application.Extensions;
using Application.Models;
using Application.Models.Settings;
using NLog;
using System.Net.Http.Headers;

namespace Application.Monitor
{
    public class Site
    {
        private readonly SiteSettings _settings;
        private readonly ILogger _logger;
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public Site(SiteSettings settings)
        {
            _settings = settings;

            _logger = LogManager.GetCurrentClassLogger();
        }

        public event Action<List<Flat>> NewFlats;

        public void Run()
        {
            while (!_tokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    var flats = SendRequestAsync(_settings).Result;
                    //var newFlats = GetNewFlats(flats);

                    //if (newFlats.Count > 0)
                    //{
                    //    NewFlats?.Invoke(newFlats);
                    //    //_repository.AddRange(newFlats.Adapt<IEnumerable<FlatEntity>>());
                    //}
                }
                catch (TypeInitializationException ex)
                {
                    _logger.Fatal(ex.ToString());
                    _tokenSource.Cancel();
                }
                catch (TypeLoadException ex)
                {
                    _logger.Fatal(ex.ToString());
                    _tokenSource.Cancel();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                }

                Thread.Sleep(_settings.IntervalInSeconds * 1000);
            }
        }

        private async Task<IEnumerable<Flat>> SendRequestAsync(SiteSettings site)
        {
            var baseUrl = site.Url;
            var queryString = site.Parameters.ToQueryString();

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));

            var response = await client.GetAsync(queryString);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(await response.Content.ReadAsStringAsync());
            }

            var result = await response.Content.ReadAsStringAsync();
            var type = Type.GetType(site.DeserializerType);

            if (type == null)
            {
                throw new TypeInitializationException(nameof(site.DeserializerType), null);
            }

            if (!(Activator.CreateInstance(type, site.Name) is IDeserializer helper))
            {
                return new List<Flat>();
            }

            return helper.Deserialize(result);
        }

        //private List<Flat> GetNewFlats(IEnumerable<Flat> flats) =>
        //    flats.Where(x => !_repository.IsExists(x.Id, x.Site)).ToList();
    }
}