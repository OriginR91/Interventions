using Interventions.Models;
using Microsoft.EntityFrameworkCore;

namespace Interventions.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<IntervenantModel> Intervenant { get; set; }
    }
}
