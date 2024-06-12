using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.Model;

namespace PruebaFinanzauto.Data
{
    public class ApiDbContext: IdentityDbContext
    {
        //Listado de objetos que vamos a traer de la base de datos.
         public DbSet<Student> Student { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }

    }
}
