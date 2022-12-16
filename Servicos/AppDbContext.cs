using Banco.Dominios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Banco.Servicos
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder x)
        => x.UseSqlServer("Server=localhost;database=Banco;User ID=sa;Password=dojpM88NHC&JNAm56Z&;TrustServerCertificate=True;Encrypt=false");
        public DbSet<ContaCorrente> ContaCorrente { get; set; }

    }
}