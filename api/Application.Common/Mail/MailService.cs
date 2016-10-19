using App.Common.Configurations;
using App.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace App.Common.Mail
{
    public class MailService : IMailService
    {
        public void Send<TEntity>(TEntity emailConent) where TEntity : IEmailContent
        {
            SmtpClient smtpClient = GetSmtpClient();
            MailMessage mesage = GetMailMessage(emailConent);
            smtpClient.Send(mesage);
        }

        private MailMessage GetMailMessage<TEntity>(TEntity emailConent) where TEntity : IEmailContent
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(Configuration.Current.Mail.DefaultSender, Configuration.Current.Mail.DisplayName);
            IList<MailAddress> toAddresses = GetMaillAddresses(emailConent.To);
            foreach (MailAddress toAddress in toAddresses) {
                message.To.Add(toAddress);
            }
            message.Body = ResourceHelper.Resolve(emailConent.Body);
            message.Subject = ResourceHelper.Resolve(emailConent.Subject);
            message.IsBodyHtml = true;
            foreach (string attchment in emailConent.Attachments) {
                message.Attachments.Add(new Attachment(attchment));
            }
            return message;
        }

        public IList<MailAddress> GetMaillAddresses(string emails)
        {
            IList<MailAddress> addresses = new List<MailAddress>();
            foreach (string email in emails.Split(';')) {
                addresses.Add(new MailAddress(email));
            }
            return addresses;
        }

        private SmtpClient GetSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = Configuration.Current.Mail.Server;
            smtpClient.Port = Configuration.Current.Mail.Port;
            smtpClient.UseDefaultCredentials = true;

            smtpClient.Credentials = new NetworkCredential(Configuration.Current.Mail.Username, Configuration.Current.Mail.Password);
            smtpClient.EnableSsl = Configuration.Current.Mail.Ssl;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            return smtpClient;
        }
    }
}
