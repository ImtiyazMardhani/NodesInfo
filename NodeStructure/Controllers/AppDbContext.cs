using Microsoft.EntityFrameworkCore;
using NodeStructure.Models;

namespace NodeStructure.Controllers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NodesInfo> nodesInfo { get; set; }
    }
}
