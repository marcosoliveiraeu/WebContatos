using WebContatos.Models;

namespace WebContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {


        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);

        UsuarioModel ListarPorId(int id);


        List<UsuarioModel> BuscarTodos();

        
        UsuarioModel BuscarPorlogin(string login);
        
      

    }
}
