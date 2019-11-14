using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessTextMessageAPI.Models
{
    public class SMSRequests
    {
        public List<string> PhoneNumbers { get; set; }
        public string Message { get; set; }
    }
}
