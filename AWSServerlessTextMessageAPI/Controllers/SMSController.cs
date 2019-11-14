using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService.Model;
using AWSServerlessTextMessageAPI.Models;
using AWSTextMessaging;
using AWSTextMessaging.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerlessTextMessageAPI.Controllers
{
    [Route("api/[controller]")]
    public class SMSController : Controller
    {
        // GET api/values
        [HttpPost]
        public List<PublishResponse> Post([FromBody] SMSRequests requests)
        {
            AWSSMSMessager messager = new AWSSMSMessager(
                accessKey: Startup.Configuration.GetSection("AWSSimplePushCredentials:accessKey").Value,
                secretKey: Startup.Configuration.GetSection("AWSSimplePushCredentials:secretKey").Value);

            List<PublishResponse> responses = new List<PublishResponse>();
            foreach (string phoneNumber in requests.PhoneNumbers)
            {
                responses.Add(
                    messager.SendText(
                    phone: phoneNumber,
                    message: requests.Message,
                    MaxPrice: 0.0065,
                    urgency: Urgency.Promotional)
                );
            }
            return responses;
        }
    }
}
