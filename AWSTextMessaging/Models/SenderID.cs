using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AWSTextMessaging.Models
{
    public class SenderID
    {
        private string _value = string.Empty;
        public string Value
        {
            get
            {
                return _value;
            }
        }

        public SenderID(string senderId)
        {
            if (IsValid(senderId))
            {
                _value = senderId;
            }
        }

        public static bool IsValid(string senderId)
        {
            Regex alphaNumericRegex = new Regex("^[a-zA-Z0-9]*$");
            return alphaNumericRegex.IsMatch(senderId) && senderId.Length < 11;
        }

        public bool HasValue()
        {
            return !string.IsNullOrWhiteSpace(_value);
        }
    }
}
