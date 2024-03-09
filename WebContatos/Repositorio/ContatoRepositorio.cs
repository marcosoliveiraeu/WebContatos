using System.Data;
using System.Linq;
using WebContatos.Data;
using WebContatos.Models;

namespace WebContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
            
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // gravar no banco

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public List<ContatoModel> BuscarTodos()
        {

            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {

            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new Exception("Erro ao atualizar contato!");

            contatoDB.Nome= contato.Nome;
            contatoDB.Email  = contato.Email;
            contatoDB.Celular = contato.Celular;


            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;

        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public bool Apagar(int id)
        {

            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new Exception("Erro ao apagar contato!");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
