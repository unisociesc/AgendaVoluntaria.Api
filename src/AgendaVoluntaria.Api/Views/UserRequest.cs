using AgendaVoluntaria.Api.Views.Core;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Views
{
    public class UserRequest : BaseRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar Email")]
        [EmailAddress(ErrorMessage = "Email Invalido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar Senha")]
        [MinLength(6, ErrorMessage = "A Senha deve conter no minimo {1} Caracteres")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar Nome")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "o CPF deve conter {1} Caracteres")]
        public string CPF { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informar Telefone")]
        public string Phone { get; set; }

        /// <summary>
        /// admin, volunteer, psico
        /// </summary>
        [Required]
        public string Role { get; set; }
    }
}
