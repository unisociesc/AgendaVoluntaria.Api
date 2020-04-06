using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace AgendaVoluntaria.Scheduler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly RestClient restClient;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            restClient = new RestClient("https://agendavoluntaria.herokuapp.com/api");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                if (true)
                {
                    var request = new RestRequest("/Email/SendNextDayScheduleForCoordinators");
                    var response = restClient.Get(request);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
