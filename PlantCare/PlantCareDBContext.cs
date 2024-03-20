using Microsoft.EntityFrameworkCore;

namespace PlantCare
{

    public class PlantCareDBContext : DbContext
    {
        public PlantCareDBContext(DbContextOptions<PlantCareDBContext> options) : base(options)
        {

        }
        public DbSet<PlantInfo> PlantInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=PlantCare;Trusted_Connection=True;Encrypt=False;Trust_Certificate=true");
            }
        }
    }
}
