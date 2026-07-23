using Microsoft.EntityFrameworkCore;

namespace BackendApi.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		//vincular
		public DbSet<Producto> Productos { get; set; }
	}
}
