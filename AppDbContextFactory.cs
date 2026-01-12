using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DINNO_ERP
{
    public class AppDbContextFactory 
        :IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseNpgsql(
                "Host=localhost;Database=ginno;Username=dinno_admin;Password=$Dinno.ERP.Admin!;"
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
