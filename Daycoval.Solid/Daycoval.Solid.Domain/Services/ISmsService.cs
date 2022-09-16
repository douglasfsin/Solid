using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services
{
    public interface ISmsService
    {
        void RegistarSmsFila(Carrinho carrinho, bool notificarClienteSms);
  
    }
}