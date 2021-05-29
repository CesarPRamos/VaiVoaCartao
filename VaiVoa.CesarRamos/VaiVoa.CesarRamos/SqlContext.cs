
using Microsoft.EntityFrameworkCore;

namespace Vaivoa.CesarRamos
{

    public class SqlContext : DbContext
    {

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<PessoaCartao> PessoaCartoes { get; set; }

    }
}
