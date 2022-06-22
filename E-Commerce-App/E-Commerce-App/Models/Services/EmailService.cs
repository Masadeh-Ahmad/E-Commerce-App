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
            SendGridClient client = new SendGridClient("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");
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("22029729@student.ltuc.com", "ASAC Team");
            msg.AddTo("Ahmad.msadae@gmail.com");
            msg.SetSubject("Test send email Subject");
            msg.AddContent(MimeType.Html, "Test send email Content");
            await client.SendEmailAsync(msg);
        }
    }
}
