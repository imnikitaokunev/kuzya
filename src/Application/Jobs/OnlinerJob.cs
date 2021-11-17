using Application.Common.Interfaces;
using Application.Models.Options;
using Application.Onliner;
using Domain.Entities;
using Mapster;
using Microsoft.Extensions.Options;
using Quartz;
using RestSharp;

namespace Application.Jobs
{
    public class OnlinerJob : BaseJob, IJob
    {
        private readonly IOnlinerApartmentRepository _onlinerApartmentRepository;

        public OnlinerJob(IOptions<OnlinerOptions> onlinerOptions, IOnlinerApartmentRepository onlinerApartmentRepository) : base(onlinerOptions.Value.BaseUrl)
        {
            _onlinerApartmentRepository = onlinerApartmentRepository;
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            // Send request to site
            var response = await Client.GetAsync<OnlinerResponse>(new RestRequest());
            if (!response.Apartments.Any())
            {
                return;
            }

            var newApartments = new List<OnlinerDto>();

            // Add apartments to database
            foreach(var apartment in response.Apartments)
            {
                var existingApartment = await _onlinerApartmentRepository.GetByIdAsync(apartment.Id);
                if(existingApartment == null)
                {
                    await _onlinerApartmentRepository.AddAsync(apartment.Adapt<OnlinerApartment>());
                    newApartments.Add(apartment);
                }
            }

            // Show new
            foreach(var apartment in newApartments)
            {
                Console.WriteLine($"#{apartment.Id} - {apartment.Url}");
            }
        }
    }
}
