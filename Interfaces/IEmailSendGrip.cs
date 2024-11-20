using Portafolio.Models;

namespace Portafolio.Interfaces
{
    public interface IEmailSendGrip
    {
        public Task Enviar(ContactoViewModel contactoViewModel);
    }
}
