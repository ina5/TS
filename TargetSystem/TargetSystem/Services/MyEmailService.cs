using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;


namespace TargetSystem.Account.Service
{
    public class MyEmailService : IMyEmailService
    {
        private const string hostEmail = "managertest17@gmail.com";
        private const string hostEmailPassword = "manager17";
        private const int port = 587;
        private const string host = "smtp.gmail.com";
        private const string subject = "Email и парола за вход в системата";
        private SmtpClient client;

        public MyEmailService(SmtpClient client)
        {
            this.Client = client;
        }
        private SmtpClient Client
        {
            get
            {
                return this.client;
            }
            set
            {
                this.client = value;
                this.client.Port = port;
                this.client.Host = host;
                this.client.EnableSsl = true;
                this.client.Timeout = 10000;
                this.client.DeliveryMethod = SmtpDeliveryMethod.Network;
                this.client.UseDefaultCredentials = false;
                this.client.Credentials = new NetworkCredential(hostEmail, hostEmailPassword);
            }
        }

        public void SendEmail(string personalEmail, string serviceEmail, string password)
        {
            var content = new StringBuilder();
            content.Append("Здравейте, <br /><br />");
            content.Append("Вече имате регистрация в Target System! <br />");
            content.Append("Вашият акаунт за достъп е : <b>" + serviceEmail + "</b> <br />");
            content.Append("Вашата парола е : <b>" + password + "</b> <br /><br />");
            content.Append("За по-голяма сигурност, влезте в системата и сменете паролата си!");

            MailMessage mailMessage = new MailMessage(hostEmail, personalEmail, subject, content.ToString())
            {
                IsBodyHtml = true,
                BodyEncoding = UTF8Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };
            this.Client.Send(mailMessage);
        }
    }
}