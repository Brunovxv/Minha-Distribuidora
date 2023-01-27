using Microsoft.EntityFrameworkCore;
using MinhaDistribuidora.Models;

namespace MinhaDistribuidora.Data
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
