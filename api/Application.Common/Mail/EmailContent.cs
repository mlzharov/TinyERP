using App.Common.Configurations;
using System.Collections.Generic;

namespace App.Common.Mail
{
    public class EmailContent: IEmailContent
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<string> Attachments { get; set; }
        public EmailContent()
        {
            this.Attachments = new List<string>();
            this.From = Configuration.Current.Mail.DefaultSender;
        }
    }
}
