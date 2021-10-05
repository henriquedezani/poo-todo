using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class UsuarioLoginViewModel
    {
        [Required(ErrorMessage = "Campo e-mail é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        [MinLength(6, ErrorMessage = "Campo deve conter no mínimo 6 caracteres")]
        public string Senha { get; set; }
    }
}