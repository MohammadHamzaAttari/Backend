using MailKit.Net.Smtp;
using MimeKit;
using UserManagementService.Models;

namespace UserManagementService.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService(EmailConfiguration emailConfiguration)
        {
            this._emailConfiguration = emailConfiguration;
        }
        public void SendEmail(Message message)
        {
            var createMessage = CreateEmailMessage(message);
            Send(createMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }
        private void Send(MimeMessage mimeMessage)
        {
            using var Client = new SmtpClient();
            try
            {
                Client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                Client.AuthenticationMechanisms.Remove("XOAUTH2");
                Client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);
                Client.Send(mimeMessage);
            }
            catch
            {
                throw;
            }
            finally
            {
                Client.Disconnect(true);
                Client.Dispose();
            }
        }
    }
}
