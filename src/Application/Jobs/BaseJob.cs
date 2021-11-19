using Application.Common.Interfaces;
using MapsterMapper;
using Quartz;
using RestSharp;

namespace Application.Jobs
{
    public abstract class BaseJob : IJob
    {
        protected readonly RestClient Client;
        protected readonly IMapper Mapper;
        protected readonly IChatNotifier UserNotifier;

        public BaseJob(string url, IMapper mapper, IChatNotifier userNotifier)
        {
            Client = new RestClient(url);
            Mapper = mapper;
            UserNotifier = userNotifier;
        }

        public abstract Task Execute(IJobExecutionContext context);
    }
}
