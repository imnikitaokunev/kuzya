using Quartz;
using RestSharp;

namespace Application.Jobs
{
    public abstract class BaseJob : IJob
    {
        protected readonly RestClient Client;

        public BaseJob(string url)
        {
            Client = new RestClient(url);
        }

        public abstract Task Execute(IJobExecutionContext context);
    }
}
