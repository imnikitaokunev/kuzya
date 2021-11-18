using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace Application.Jobs
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceScope _serviceScope;

        public JobFactory(IServiceProvider serviceProvider)
        {
            _serviceScope = serviceProvider.CreateScope();
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _serviceScope.ServiceProvider.GetService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {
            (job as IDisposable)?.Dispose();
        }
    }
}
