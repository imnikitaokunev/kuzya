using MapsterMapper;
using Quartz;
using RestSharp;

namespace Application.Jobs
{
    public abstract class BaseJob : IJob
    {
        protected readonly RestClient Client;
        protected readonly IMapper Mapper;

        public BaseJob(string url, IMapper mapper)
        {
            Client = new RestClient(url);
            Mapper = mapper;
        }

        public abstract Task Execute(IJobExecutionContext context);
    }
}
