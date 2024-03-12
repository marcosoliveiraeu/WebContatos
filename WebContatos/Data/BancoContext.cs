using Microsoft.EntityFrameworkCore;
using WebContatos.Models;



namespace WebContatos.Data
{
    public class BancoContext: DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> option ): base( option ) 
        {}

        public DbSet<ContatoModel> Contatos { get; set; }


        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}
