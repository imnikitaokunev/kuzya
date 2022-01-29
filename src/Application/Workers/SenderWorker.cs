using Application.Common.Interfaces;
using Application.Models;
using Application.Models.Options;
using Domain.Entities;
using Mapster;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Workers;

public class SenderWorker : BackgroundService
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly ITelegramService _telegramService;
    private readonly ILogger<SenderWorker> _logger;
    private readonly int _interval;

    public SenderWorker(IApartmentRepository apartmentRepository, ISubscriptionRepository subscriptionRepository,
        ITelegramService telegramService, ILogger<SenderWorker> logger, IOptions<ApplicationOptions> applicationOptions)
    {
        _apartmentRepository = apartmentRepository;
        _subscriptionRepository = subscriptionRepository;
        _telegramService = telegramService;
        _logger = logger;
        _interval = applicationOptions.Value.Interval;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var apartments = (await _apartmentRepository.GetUnsentAsync()).Adapt<IEnumerable<ApplicationApartment>>();
                var subscriptions = (await _subscriptionRepository.GetActiveAsync()).Adapt<IEnumerable<ApplicationSubscription>>();

                foreach (var apartment in apartments)
                {
                    foreach (var subscription in subscriptions)
                    {
                        if (!subscription.IsAimedAt(apartment))
                        {
                            continue;
                        }

                        // Todo: Move template to separated file.
                        await _telegramService.SendAsync(subscription.ChatId, $"{apartment}\n<i>Подписка:</i> <code>{subscription.Name}</code>");
                    }

                    apartment.IsSent = true;
                    await _apartmentRepository.UpdateAsync(apartment.Adapt<Apartment>());
                }

                _logger.LogInformation("Sent {count} apartment(s) between {count1} subscription(s)", apartments.Count(), subscriptions.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }
}
