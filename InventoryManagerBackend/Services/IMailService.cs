using InventoryManagerBackend.Utilities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace InventoryManagerBackend.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest request);
    }

    public class MailService : IMailService
    {
        private readonly MailingOptions _mailOptions;

        public MailService(IOptions<MailingOptions> mailOptions)
        {
            _mailOptions = mailOptions.Value;
        }

        public async Task SendEmailAsync(MailRequest request)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailOptions.Mail);
            email.To.Add(MailboxAddress.Parse(request.Recipient));
            email.Subject = request.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_mailOptions.Host, _mailOptions.Port, false);
            await smtp.AuthenticateAsync(_mailOptions.Mail, _mailOptions.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
