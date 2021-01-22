using Microsoft.Extensions.Configuration;
using PortalAPI.Models;
using System.Net.Mail;

namespace PortalAPI.Services
{
    public class EmailService
    {
        private readonly SmtpClient _smtp;
        private readonly IConfiguration _configuration;

        public EmailService(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }

        public void SendNewPassword(User user)
        {
            string msgBody = string.Format("<h2> Olá, " + user.Name + "</h2>" +
               "Sua nova senha é: " +
               "<h3>{0}</h3>", user.Password);

            MailMessage message = new MailMessage
            {
                From = new MailAddress(_configuration.GetValue<string>("Email:UserName"))
            };
            message.To.Add(user.Email);
            message.Subject = "Nova senha - Portal Comunitário ";
            message.Body = msgBody;
            message.IsBodyHtml = true;

            _smtp.Send(message);
        }
    }
}
