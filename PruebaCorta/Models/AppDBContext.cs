using Microsoft.EntityFrameworkCore;

namespace PruebaCorta.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
       : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<PreguntaM> PreguntaM { get; set; }

        public DbSet<RespuestaM> RespuestaM { get; set; }
    }
}
