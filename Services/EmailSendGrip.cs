using Portafolio.Interfaces;
using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Services
{
    public class EmailSendGrip : IEmailSendGrip
    {
        private readonly IConfiguration _configuration;
        public EmailSendGrip( IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contactoViewModel)
        {
            var apiKey = _configuration.GetValue<string>("SEND_API_KEY");
            var email = _configuration.GetValue<string>("SEND_FROM");
            var nombre = _configuration.GetValue<string>("SEND_NOMBRE");


            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $" {contactoViewModel.Nombre} quiere contactarte";
            var to= new EmailAddress(email, nombre);
            var mensajeTextoPlano = contactoViewModel.Mensaje;
            var contenidoHTML = $@" De: {contactoViewModel.Nombre} - Email:{contactoViewModel.Email}  Mensaje{contactoViewModel.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHTML);
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }
    }
}
