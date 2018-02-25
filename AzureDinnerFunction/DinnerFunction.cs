using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AzureDinnerFunction
{
    public static class DinnerFunction
    {
        [FunctionName("DinnerFunction")]
        public static void Run([TimerTrigger("0 */2 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"Start: {DateTime.Now}");

            try
            {
                GetClient().SendEmailAsync(GetMessage(new DinnerItemGenerator()));

                log.Info($"End: {DateTime.Now}");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

        }

        private static SendGridMessage GetMessage(DinnerItemGenerator itemGenerator)
        {
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("Dinner@idea.com", "Dinner Options"));
            msg.AddTos(GetRecipients());
            msg.SetSubject("Weekly Meal Ideas");

            foreach(var item in itemGenerator.GetDinnerOptions(5))
            {
                msg.AddContent(MimeType.Text, "Idea: " + item.Title + " Type: " + item.Type);

            }

            return msg;
        }

        private static List<EmailAddress> GetRecipients()
        {
            var recipients = ConfigurationSettings.AppSettings["EMAIL_Recipients"].Split('|');
            var listOfEmails = new List<EmailAddress>();

            recipients.ToList().ForEach(r => listOfEmails.Add(new EmailAddress(r)));

            return listOfEmails;
        }

        private static SendGridClient GetClient()
        {
            
            return new SendGridClient(ConfigurationSettings.AppSettings["EMAIL_API"]);
            
        }

    }
}
