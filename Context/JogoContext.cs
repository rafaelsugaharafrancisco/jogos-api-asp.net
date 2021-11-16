using ApiCatalogoJogos.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoJogos.Context
{
    public class JogoContext : DbContext
    {
        public JogoContext(DbContextOptions<JogoContext> option) : base(option) { }

        public DbSet<Jogo> Jogos { get; set; }
    }
}
