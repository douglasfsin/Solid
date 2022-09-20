using Daycoval.Solid.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Services
{
    public interface IEmailService
    {
        void EnviarEmail(Carrinho carrinho, bool notificarClienteEmail);
    }
}
