using System.Data;
using System.Linq;
using WebContatos.Data;
using WebContatos.Models;

namespace WebContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
            
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            // gravar no banco

            usuario.DataCadastro =  DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

        public List<UsuarioModel> BuscarTodos()
        {

            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {

            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Erro ao atualizar usuario!");

            usuarioDB.Nome= usuario.Nome;
            usuarioDB.Email  = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Senha = usuario.Senha;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;

        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public bool Apagar(int id)
        {

            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new Exception("Erro ao apagar usuário!");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
