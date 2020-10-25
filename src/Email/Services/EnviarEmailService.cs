using Domain.Entities.Email;
using System;
using System.Net;
using System.Net.Mail;

namespace Email.Services
{
    public static class EnviarEmailService
    {
        public static bool Enviar(EmailEnviar emailEntity)
        {
            //--- objeto e-mail
            var cliente = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("carspremiumcontato@gmail.com", "Contato@2015"),
            };

            //--- Remetente
            var remetente = new MailAddress(emailEntity.RemetenteEmail, emailEntity.RemetenteNome);

            //--- Destinatário
            var destinatario = new MailAddress(emailEntity.DestinoEmail, emailEntity.DestinoNome);

            //--- Mensagem
            var mensagem = new MailMessage(remetente, destinatario)
            {
                Body = emailEntity.Body,
                Subject = emailEntity.Assunto,
                IsBodyHtml = true,
                SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"),
                BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1"),
                Priority = MailPriority.High,
            };

            try
            {
                cliente.Send(mensagem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
