using Microsoft.EntityFrameworkCore;
using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Persistence
{
    public class AppDbContext: DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        //public DbSet<Experiencia> Experiencias { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Contato>().ToTable("Contatos");
            builder.Entity<Contato>().HasKey(p => p.Id);
            builder.Entity<Contato>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Contato>().Property(p => p.Titulo).IsRequired().HasMaxLength(50);

            // No seu DbContext ou na configuração de entidades
            builder.Entity<Contato>().HasData(
                new Contato
                (
                    titulo: "Facebook",
                    descricao: "http://facebook.com/jaza_soares"
                )
            );

            //builder.Entity<Contato>().ToTable("Experiencias");
            //builder.Entity<Contato>().HasKey(p => p.Id);
            //builder.Entity<Contato>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Contato>().Property(p => p.Titulo).IsRequired().HasMaxLength(50);
            //builder.Entity<Contato>().Property(p => p.Descricao).IsRequired().HasMaxLength(50);

        }
    }
}
