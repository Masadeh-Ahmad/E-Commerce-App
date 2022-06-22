using E_Commerce_App.Models.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace E_Commerce_App.Models.Services
{
    public class EmailService : IEmail
    {
        public async Task sendEmail()
        {
            SendGridClient client = new SendGridClient("");
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("", "");
            msg.AddTo("");
            msg.SetSubject("");
            msg.AddContent(MimeType.Html, "");
            await client.SendEmailAsync(msg);
        }
    }
}
