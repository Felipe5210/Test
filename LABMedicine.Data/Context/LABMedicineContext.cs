using LABMedicine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LABMedicine.Infrastructure.Data
{
    public class labmedicineDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Enfermeiro> Modelos { get; set; }
        public labmedicineDbContext(DbContextOptions<labmedicineDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paciente>()
                .HasIndex(u => u.CpfOuCnpj)
                .IsUnique();

            modelBuilder.Entity<Paciente>()
                .HasIndex(u => u.Email)
                .IsUnique();


            modelBuilder.Entity<Medico>().HasData(
                new Medico
                { 

                
                
                
                }

                );
      

            modelBuilder.Entity<Paciente>().HasData(
                new Paciente
                {
                    id = 1,
                    nomeCompleto = "Koiru Teusda Vueca",
                    Genero = "Masculino",
                    DataDeNascimento = DateTime.Parse("1990-01-01"),
                    CpfOuCnpj = "141.659.360-81",
                    Telefone = "9999-9999",
                    Email = "maria@mail.com",
                    Status = "Ativo"
                },
                new Paciente
                {
                    id = 2,
                    nomeCompleto = "Fulano de Tal",
                    Genero = "Masculino",
                    DataDeNascimento = DateTime.Parse("1985-05-10"),
                    CpfOuCnpj = "123.456.789-00",
                    Telefone = "8888-8888",
                    Email = "fulano@mail.com",
                    Status = "Ativo"
                },
                new Paciente
                {
                    id = 3,
                    nomeCompleto = "Ciclana Silva",
                    Genero = "Feminino",
                    DataDeNascimento = DateTime.Parse("1992-11-20"),
                    CpfOuCnpj = "987.654.321-00",
                    Telefone = "7777-7777",
                    Email = "ciclana@mail.com",
                    Status = "Ativo"
                },
                new Paciente
                {
                    id = 4,
                    nomeCompleto = "Beltrano Pereira",
                    Genero = "Masculino",
                    DataDeNascimento = DateTime.Parse("1978-03-15"),
                    CpfOuCnpj = "567.890.123-00",
                    Telefone = "6666-6666",
                    Email = "beltrano@mail.com",
                    Status = "Inativo"
                },

                new Paciente
                {
                    id = 5,
                    nomeCompleto = "Ana Souza",
                    Genero = "Feminino",
                    DataDeNascimento = DateTime.Parse("1995-07-25"),
                    CpfOuCnpj = "321.654.987-00",
                    Telefone = "5555-5555",
                    Email = "ana@mail.com",
                    Status = "Ativo"
                }

          );
        }
    }
}
