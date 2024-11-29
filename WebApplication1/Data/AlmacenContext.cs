using Microsoft.EntityFrameworkCore;
using AlmacenMVC.Models;

namespace AlmacenMVC.Data
{
    public class AlmacenContext : DbContext
    {
        public AlmacenContext(DbContextOptions<AlmacenContext> options) : base(options) { }

        public DbSet<Articulo> Articulos { get; set; }
    }
}
