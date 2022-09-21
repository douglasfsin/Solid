using System.ComponentModel.DataAnnotations;

namespace Daycoval.Solid.Autenticacao.API.Models
{
    public class UserViewModels
    {
        [Required(ErrorMessage = "O campo {0} ] e obrigatorio")]
        [EmailAddress(ErrorMessage = "O campo {0} esta em  formato invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="O campo {0} e obrigatorio")]
        [StringLength(100,ErrorMessage ="")]
        public string Senha { get; set; }
        public string SenhaConfirmacao { get; set; }
    }
}
