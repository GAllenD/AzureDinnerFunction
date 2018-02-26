using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text;

namespace AzureDinnerFunction
{
    public static class DinnerFunction
    {
        [FunctionName("DinnerFunction")]
        public static void Run([TimerTrigger("0 00 3 * * Mon")]TimerInfo myTimer, TraceWriter log)
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
            var messageHtml = new StringBuilder();
            messageHtml.Append("<h2>Weekly Meal Planning List</h2><br /><ul>");

            msg.SetFrom(new EmailAddress("Dinner@idea.com", "Dinner Options"));
            msg.AddTos(GetRecipients());
            msg.SetSubject("Weekly Meal Ideas");

            foreach(var item in itemGenerator.GetDinnerOptions(5))
            {
                messageHtml.Append("<li><b>Idea:</b> " + item.Title + "  <b>Type:</b> " + item.Type + "</li>");

            }

            messageHtml.Append("</ul>");

            msg.AddContent(MimeType.Html, messageHtml.ToString());

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
