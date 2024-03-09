using System.ComponentModel.DataAnnotations;
using WebContatos.Repositorio;

namespace WebContatos.Models
{
    public class ContatoModel 
    {

       
        
        public int Id { get; set; }


        [Required(ErrorMessage ="Digite o nome!")]
        public required string Nome { get; set; }


        [Required(ErrorMessage = "Digite o email!")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public required string Email { get; set; }


        [Phone(ErrorMessage = "Celular inválido")]
        [Required(ErrorMessage = "Digite o celular!")]
        public required string Celular { get; set;}

        
    }
}
