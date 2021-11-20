using Application.Common.Interfaces;
using Application.Models;
using Application.Models.Options;
using Application.Onliner;
using Domain.Entities;
using MapsterMapper;
using Microsoft.Extensions.Options;
using Quartz;
using RestSharp;
using Serilog;

namespace Application.Jobs;

public class OnlinerJob : BaseJob, IJob
{
    private readonly IOnlinerApartmentRepository _onlinerApartmentRepository;
    private readonly ILogger _logger;

    public OnlinerJob(IOptions<OnlinerOptions> onlinerOptions, IOnlinerApartmentRepository onlinerApartmentRepository, IMapper mapper, IChatNotifier userNotifier, ILogger logger)
        : base(onlinerOptions.Value.BaseUrl, mapper, userNotifier)
    {
        _onlinerApartmentRepository = onlinerApartmentRepository;
        _logger = logger;
    }

    public override async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var response = await Client.GetAsync<OnlinerResponse>(new RestRequest());
            if (!response.Apartments.Any())
            {
                return;
            }

            var newApartments = new List<ApplicationApartment>();
            foreach (var apartment in response.Apartments)
            {
                var existingApartment = await _onlinerApartmentRepository.GetByIdAsync(apartment.Id);
                if (existingApartment == null)
                {
                    await _onlinerApartmentRepository.AddAsync(Mapper.Map<OnlinerApartment>(apartment));
                    newApartments.Add(Mapper.Map<ApplicationApartment>(apartment));
                }
            }

            if (newApartments.Any())
            {
                await UserNotifier.NotifyAsync(newApartments);
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "{Timestamp} [{Level}] {Message}{NewLine}{Exception}");
        }
    }
}
