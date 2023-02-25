using System;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Z6O9JF_SOF_2022231.ASP.Services;

namespace Z6O9JF_SOF_2022231.AzureFunctions
{
    public class Function1
    {
        [FunctionName("NewsLetter")]
        public void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            WebClient webClient = new WebClient();
            var res = webClient.DownloadString("https://localhost:7282/Appointment/Reminder");
        }
    }
}
