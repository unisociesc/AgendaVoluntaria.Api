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
            restClient = new RestClient("https://api");
            restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var horario = DateTime.Now;
                _logger.LogInformation("Worker start at: {time}", horario);

                if (horario.ToShortTimeString() == "12:00")
                {
                    var request = new RestRequest("/api/Email/SendNextDayScheduleForCoordinators");
                    var response = await restClient.ExecuteGetAsync(request);

                    if (response.IsSuccessful)
                        _logger.LogInformation("Enviado Emails de escala: {time}", horario);
                    else
                        _logger.LogError("Erro ao enviar emails: {time} | {error}", horario, response.ErrorMessage);
                }
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
