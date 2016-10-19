using System.Collections.Generic;

namespace App.Common.Mail
{
    public interface IEmailContent
    {
        string From { get; set; }
        string To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        IList<string> Attachments { get; set; }
    }
}
