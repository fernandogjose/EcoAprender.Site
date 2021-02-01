using Domain.Entities;
using Domain.Entities.Email;
using Domain.Interfaces.Email;

namespace Email.Services
{
    public class FaleConoscoService : IFaleConoscoService
    {
        public bool Enviar(FaleConosco entity)
        {
            var body = "<!DOCTYPE html>" +
                          "<html>" +
                          "<head>" +
                          "    <meta name='viewport' content='width=device-width' />" +
                          "    <title>Fale Conosco</title>" +
                          "</head>" +
                          "<body>" +
                          "    <div style='width: 750px; border: 1px solid #e2e2e2; padding: 15px 15px; background-color: #fafafa; font-size: verdana;'>" +
                          "        <div style='width: 745px; height: 74px; background-color: #666666; text-align: center; -moz-border-radius: 7px; -webkit-border-radius: 7px; border-radius: 7px; padding-top: 20px; margin-left: 1px;'>" +
                          "            <p style='color: #000;'>nome: " + entity.Nome + "</p>" +
                          "            <p style='color: #000;'>e-mail: " + entity.Email + "</p>" +
                          "            <p style='color: #000;'>mensagem:  " + entity.Mensagem + "</p>" +
                          "        </div>" +
                          "    </div>" +
                          "</body>" +
                          "</html>";

            var emailEntity = new EmailEnviar
            {
                Body = body,
                DestinoNome = "Priscila Antunes",
                DestinoEmail = "priscilaecoaprender@gmail.com",
                Assunto = entity.Assunto,
                RemetenteNome = entity.Nome,
                RemetenteEmail = entity.Email
            };

            return EnviarEmailService.Enviar(emailEntity);
        }
    }
}
