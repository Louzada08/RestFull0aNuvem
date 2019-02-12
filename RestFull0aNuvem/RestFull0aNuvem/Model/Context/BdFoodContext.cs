using Microsoft.EntityFrameworkCore;

namespace RestFull0aNuvem.Model.Context
{
    public class BdFoodContext : DbContext
    {
       public BdFoodContext(DbContextOptions<BdFoodContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
