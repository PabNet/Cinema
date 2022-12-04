using System;
using System.Net;
using System.Net.Mail;
using Cinema.Common.Helpers;

namespace Cinema.Common.Helpers.Mail
{
    public partial class MailHelper
    {
        private readonly SmtpClient _smtpClient;
        private readonly MailAddress _senderMailAddress;

        public MailHelper(ConfigurationHelper configuration)
        {
            this._smtpClient = new SmtpClient
            {
                Host = configuration.GetValue(Host),
                Port = Convert.ToInt32(configuration.GetValue(Port)),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential
                {
                    UserName = configuration.GetValue(UserName),
                    Password = configuration.GetValue(Password)
                }
            };

            _senderMailAddress = new MailAddress(configuration.GetValue(UserName),
                                        configuration.GetValue(SenderName));
        }

        public void SendMessage(string receiver, string subject, string content)
        {
            var message = new MailMessage(this._senderMailAddress, new MailAddress(receiver, receiver))
            {
                Subject = subject,
                Body = content
            };
            
            this._smtpClient.Send(message);
        }
    }
}