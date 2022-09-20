using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services
{
    public class SmsService :ISmsService
    {
        public string Celular { get; private set; }
        public string Mensagem { get; private set; }

        public SmsService(string celular, string mensagem)
        {
            Celular = celular;
            Mensagem = mensagem;
        }

        public void RegistarSmsFila(Carrinho carrinho, bool notificarClienteSms)
        {
            if (notificarClienteSms)
            {
                if (!string.IsNullOrWhiteSpace(carrinho.Cliente.Celular))
                {
                    var smsService = new SmsService("Obrigado por sua compra", carrinho.Cliente.Celular);
                    EnviarSms();
                }
            }
        }
        private void EnviarSms()
        {
            //Este método não precisa ser implementado.
        }

    }
}