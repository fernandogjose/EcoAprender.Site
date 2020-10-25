using Domain.Entities;
using Domain.Entities.Email;

namespace Domain.Interfaces.Email
{
    public interface IFaleConoscoService 
    {
        bool Enviar(FaleConosco entity);
    }
}
