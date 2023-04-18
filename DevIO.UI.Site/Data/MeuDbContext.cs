using Microsoft.EntityFrameworkCore;

namespace DevIO.UI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options)
        : base(options)
        {

        }
    }
}
