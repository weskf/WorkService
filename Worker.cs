using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using LinuxService.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LinuxService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Sites _sites;
        public Worker(ILogger<Worker> logger, IConfiguration _conf)
        {
            _logger = logger;
            _sites = _conf.GetSection("Sites").Get<Sites>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {           

            while (!stoppingToken.IsCancellationRequested)
            {
                //HttpStatusCode Status = await Requesters.GetStatusFromUrl(_sites.Url);

                DateTime date = new DateTime(2021,7,27,21,51,00);
                DateTime dateNow = DateTime.Now;
                //int result = DateTime.Compare(date.Hour, DateTime.Now.Hour);
                
                if(date.Hour == dateNow.Hour && 
                    date.Minute == dateNow.Minute &&
                    date.Second == dateNow.Second){

                    _logger.LogInformation("Serviço iniciado");
                }

                // if(Status != HttpStatusCode.OK){
                //     string nameFile = string.Format("logFile_{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
                //     string path = Path.Combine(@"D:\Temp", nameFile);
                //     StreamWriter logFile = new StreamWriter(path, true);    
                //     string message = string.Format("O site {0} ficou fora do ar no dia {1}", _sites.Url, DateTime.Now.ToString());
                //     logFile.WriteLine(message);
                //     logFile.Close();

                //     _logger.LogInformation(message);
                // }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);             
            }     
        }
    }
}
