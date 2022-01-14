using Application.Common.Interfaces;
using Application.Models;
using Application.Models.Options;
using Application.Onliner;
using Domain.Entities;
using Mapster;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Application.Workers;

public class OnlinerWorker : BackgroundService
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly ILogger<OnlinerWorker> _logger;
    private readonly int _interval;
    private readonly RestClient _restClient;

    public OnlinerWorker(IApartmentRepository apartmentRepository, ILogger<OnlinerWorker> logger,
        IOptions<OnlinerOptions> onlinerOptions, IOptions<ApplicationOptions> applicationOptions)
    {
        _apartmentRepository = apartmentRepository;
        _logger = logger;
        _interval = applicationOptions.Value.Interval;
        _restClient = new RestClient(onlinerOptions.Value.BaseUrl);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("Processing Onliner at: {time}", DateTimeOffset.Now);

                var response = await _restClient.GetAsync<OnlinerResponse>(new RestRequest(), stoppingToken);
                if (!response.Apartments.Any())
                {
                    return;
                }

                var newApartments = new List<ApplicationApartment>();
                foreach (var apartment in response.Apartments)
                {
                    if (!await _apartmentRepository.IsExists(apartment.Id, apartment.Platform))
                    {
                        var entity = apartment.Adapt<Apartment>();
                        await _apartmentRepository.AddAsync(entity);
                        newApartments.Add(apartment.Adapt<ApplicationApartment>());
                    }
                }

                _logger.LogInformation("Processed {count} apartments", newApartments.Count());
                // Send apartments.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }
}
