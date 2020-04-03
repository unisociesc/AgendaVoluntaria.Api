using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Repositories.Interfaces;
using AgendaVoluntaria.Api.Services.Core;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils;
using AgendaVoluntaria.Api.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly INotifier _notifier;
        private readonly string _domain = "smtp.gmail.com";
        private readonly int _port = 587;
        private readonly string _from = "agendatriagem@prodcom.com.br";
        private readonly string _name = "Agenda triagem";
        private readonly string _password = "XXX";

        public EmailService(INotifier notifier)
        {
            _notifier = notifier;
        }

        public Task SendAsync(string to, string subject, string message)
        {
            try
            {
                using var mail = new MailMessage();
                mail.To.Add(new MailAddress(to));
                mail.From = new MailAddress(_from, _name);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                
                using var client = new SmtpClient(_domain);
                client.Port = _port;
                client.Credentials = new NetworkCredential(_from, _password);
                client.EnableSsl = true;
                
                return client.SendMailAsync(mail);
            }
            catch(Exception)
            {
                _notifier.Add("Erro ao enviar o e-mail");
            }

            return null;
        }
    }
}
