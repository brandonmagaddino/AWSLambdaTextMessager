using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using AWSTextMessaging.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSTextMessaging
{
    public class AWSSMSMessager
    {
        private string accessKey;
        private string secretKey;

        public AWSSMSMessager(string accessKey, string secretKey)
        {
            this.accessKey = accessKey;
            this.secretKey = secretKey;
        }

        public PublishResponse SendText(string phone, string message, double MaxPrice = 0.0065, Urgency urgency = Urgency.Promotional, SenderID senderID = null)
        {
            AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(accessKey, secretKey, Amazon.RegionEndpoint.USEast1);
            PublishRequest pubRequest = new PublishRequest();
            pubRequest.Message = message;
            pubRequest.PhoneNumber = phone;

            if (senderID != null && senderID.HasValue())
            {
                pubRequest.MessageAttributes["AWS.SNS.SMS.SenderID"] =
                    new MessageAttributeValue { StringValue = senderID.Value, DataType = "String" };
            }
            pubRequest.MessageAttributes["AWS.SNS.SMS.MaxPrice"] =
                new MessageAttributeValue { StringValue = MaxPrice.ToString(), DataType = "Number" };
            pubRequest.MessageAttributes["AWS.SNS.SMS.SMSType"] =
                new MessageAttributeValue { StringValue = urgency.ToString(), DataType = "String" };
            // add optional MessageAttributes, for example:
            //   pubRequest.MessageAttributes.Add("AWS.SNS.SMS.SenderID", new MessageAttributeValue
            //      { StringValue = "SenderId", DataType = "String" });
            PublishResponse pubResponse = snsClient.PublishAsync(pubRequest).Result;
            return pubResponse;
        }
    }



}
