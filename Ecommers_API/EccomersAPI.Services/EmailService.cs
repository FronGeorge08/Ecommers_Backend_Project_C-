using EccomersAPI.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.Services
{
    public class EmailService : IEmailService
    {
        IEmailConfig _configuration;
        public EmailService(IEmailConfig conf) 
        {
            this._configuration = conf;
        }
        public void SendVerificationCode(string email, string code)
        {
            var fromAddress = _configuration.Email;
            var smtpHost = _configuration.Host;
            var smtpPort = _configuration.Port;
            var username = _configuration.Email;
            var password = _configuration.Password;

            MailMessage msg = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = "Verification Code",
                Body = "Buna, acesta este codul tau de verificare "+code,
                IsBodyHtml = true
            };
            using var client = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
            msg.To.Add(email);
            client.Send(msg);
        }
    }
}
