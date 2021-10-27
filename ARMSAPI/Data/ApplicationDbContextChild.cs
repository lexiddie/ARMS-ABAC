using Microsoft.EntityFrameworkCore;

namespace ARMSAPI.Data
{
    public class ApplicationDbContextChild : ApplicationDbContext
    {    
        public ApplicationDbContextChild() { }
        public ApplicationDbContextChild(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ARMS;Trusted_Connection=true;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}