using Microsoft.EntityFrameworkCore;

namespace QuantumTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Note> Notes { get; set; }
    }
}
