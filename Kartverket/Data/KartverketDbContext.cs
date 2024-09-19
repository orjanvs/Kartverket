using Kartverket.Models;
using Microsoft.EntityFrameworkCore;

namespace Kartverket.Data
{
    public class KartverketDbContext : DbContext
    {
        public KartverketDbContext(DbContextOptions<KartverketDbContext> options) : base(options)
        {
        }

        public DbSet<FaultReportModel> FaultReports { get; set; }
    }
    
    
}
