using Daycoval.Solid.Domain.Entidades;
using System.Net.Mail;

namespace Daycoval.Solid.Domain.Services
{
    public class EmailService : IEmailService
    {
        public void EnviarEmail(Carrinho carrinho, bool notificarClienteEmail)
        {
            if (notificarClienteEmail)
            {
                if (!string.IsNullOrWhiteSpace(carrinho.Cliente.Email))
                {
                    using (var msg = new MailMessage("tiago.dantas@bancodaycoval.com.br", carrinho.Cliente.Email))
                    using (var smtp = new SmtpClient("servidor.smtp"))
                    {
                        msg.Subject = "Dados da sua compra";
                        msg.Body = $"Obrigado por efetuar sua compra conosco.";

                        smtp.Send(msg);
                    }
                }
            }
        }
    }
}
