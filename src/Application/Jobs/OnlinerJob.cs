using Application.Common.Interfaces;
using Application.Models.Options;
using Application.Onliner;
using Domain.Entities;
using MapsterMapper;
using Microsoft.Extensions.Options;
using Quartz;
using RestSharp;

namespace Application.Jobs;

public class OnlinerJob : BaseJob, IJob
{
    private readonly IOnlinerApartmentRepository _onlinerApartmentRepository;

    public OnlinerJob(IOptions<OnlinerOptions> onlinerOptions, IOnlinerApartmentRepository onlinerApartmentRepository, IMapper mapper) : base(onlinerOptions.Value.BaseUrl, mapper)
    {
        _onlinerApartmentRepository = onlinerApartmentRepository;
    }

    public override async Task Execute(IJobExecutionContext context)
    {
        var response = await Client.GetAsync<OnlinerResponse>(new RestRequest());
        if (!response.Apartments.Any())
        {
            return;
        }

        var newApartments = new List<OnlinerApartmentDto>();
        foreach (var apartment in response.Apartments)
        {
            var existingApartment = await _onlinerApartmentRepository.GetByIdAsync(apartment.Id);
            if (existingApartment == null)
            {
                await _onlinerApartmentRepository.AddAsync(Mapper.Map<OnlinerApartment>(apartment));
                newApartments.Add(apartment);
            }
        }

        foreach (var apartment in newApartments)
        {
            Console.WriteLine($"#{apartment.Id} - {apartment.Url}");
        }
    }
}
