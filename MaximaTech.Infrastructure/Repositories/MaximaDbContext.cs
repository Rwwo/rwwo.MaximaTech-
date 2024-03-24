using MaximaTech.api.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaximaTech.api.Data
{
    public class MaximaDbContext : IdentityDbContext
    {
        public MaximaDbContext(DbContextOptions<MaximaDbContext> options)
            : base(options)
        {

        }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Produtos> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>().HasNoKey();
            builder.Entity<IdentityUserRole<string>>().HasNoKey();
            builder.Entity<IdentityUserToken<string>>().HasNoKey();

            builder.Entity<Departamentos>()
                .ToTable("departamento");

            builder.Entity<Produtos>()
                .ToTable("produtos");

            builder.Entity<Produtos>()
                .HasOne(p => p.Departamento)
                //.WithMany(p => p.Produtos)
                //.HasForeignKey(t => t.DepartamentoId)
                ;

            //builder.Entity<Departamentos>()
            //    .HasMany(p => p.Produtos)
            //    .WithOne(p => p.Departamento)
            //    .HasForeignKey(t => t.DepartamentoId);
        }
    }


}
