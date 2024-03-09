using WebContatos.Models;

namespace WebContatos.Repositorio
{
    public interface IContatoRepositorio
    {


        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);

        ContatoModel ListarPorId(int id);


        List<ContatoModel> BuscarTodos();


    }
}
