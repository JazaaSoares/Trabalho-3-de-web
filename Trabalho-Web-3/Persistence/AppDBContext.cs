using Microsoft.EntityFrameworkCore;
using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Persistence
{
    public class AppDbContext: DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Experiencia> Experiencias { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Qualificacao> Qualificacoes { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Contato>().ToTable("Contatos");
            builder.Entity<Contato>().HasKey(p => p.Id);
            builder.Entity<Contato>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Contato>().Property(p => p.Titulo).IsRequired().HasMaxLength(50);

            builder.Entity<Contato>().HasData(
                new Contato
                (
                    titulo: "Facebook",
                    descricao: "http://facebook.com/jaza_soares"
                )
            );

            builder.Entity<Experiencia>().ToTable("Experiencias");
            builder.Entity<Experiencia>().HasKey(p => p.Id);
            builder.Entity<Experiencia>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Experiencia>().Property(p => p.Titulo).IsRequired().HasMaxLength(50);
            builder.Entity<Experiencia>().Property(p => p.Descricao).IsRequired().HasMaxLength(50);
            builder.Entity<Experiencia>().Property(p => p.Data).IsRequired();

            builder.Entity<Experiencia>().HasData(
                new Experiencia
                (
                    titulo: "Trampo 1",
                    descricao: "trabalhando como dev jr na empresa X",
                    data: new DateTime(2022, 4, 23)
                )
            );

            builder.Entity<Projeto>().ToTable("Projetos");
            builder.Entity<Projeto>().HasKey(p => p.Id);
            builder.Entity<Projeto>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Projeto>().Property(p => p.Titulo).IsRequired().HasMaxLength(50);
            builder.Entity<Projeto>().Property(p => p.Link).IsRequired().HasMaxLength(50);

            builder.Entity<Projeto>().HasData(
                new Projeto
                (
                    titulo: "Projeto CRUD Backend",
                    link: "http://www.github.com"
                )
            );

            builder.Entity<Qualificacao>().ToTable("Qualificacoes");
            builder.Entity<Qualificacao>().HasKey(p => p.Id);
            builder.Entity<Qualificacao>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Qualificacao>().Property(p => p.Titulo).IsRequired().HasMaxLength(50);
            builder.Entity<Qualificacao>().Property(p => p.Descricao).IsRequired().HasMaxLength(50);
            builder.Entity<Qualificacao>().Property(p => p.Data).IsRequired();

            builder.Entity<Qualificacao>().HasData(
                new Qualificacao
                (
                    titulo: "Curso 1",
                    descricao: "Curso de .net do zero ao especialista",
                    data: new DateTime(2022, 03, 09)
                )
            );
        }
    }
}
