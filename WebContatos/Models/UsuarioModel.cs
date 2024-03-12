using System.ComponentModel.DataAnnotations;
using WebContatos.Enums;

namespace WebContatos.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o usuário!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o email!")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Selecione o perfil!")]
        public PerfilEnum Perfil { get; set;}

        [Required(ErrorMessage = "Digite o login!")]
        public string Login { get; set;}

        [Required(ErrorMessage = "Digite a senha!")]
        public string Senha { get; set;}

       
        public DateTime DataCadastro { get; set;}

        public DateTime? DataAtualizacao { get; set; }


    }
}
