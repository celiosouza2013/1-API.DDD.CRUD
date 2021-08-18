using API.DDD.CRUD.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DDD.CRUD.INFRA.EF.Context
{
    public class DataContext : DbContext
    {
        public DataContext() 
        {            
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }        

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DBTest");
        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            //Exemplos
            //modelBuilder.Entity<Cliente>().HasKey(m => m.Id);           
            //modelBuilder.Entity<Cliente>().HasOne(m => m.Telefone).WithMany().HasForeignKey(u => u.Telefone);            
            //modelBuilder.Entity<Cliente>().Property(t => t.Cpf).IsRequired();
            //modelBuilder.Entity<Cliente>().Property(t => t.Nome).IsRequired().HasMaxLength(120);
            //modelBuilder.Entity<Cliente>().Property(t => t.DataNascimento).IsRequired();
            //modelBuilder.Entity<Cliente>().Property(t => t.DataHoraInclusao).IsRequired();
            //modelBuilder.Entity<Cliente>().ToTable("DMVPPR", "SchCUD");
            //modelBuilder.Entity<Cliente>().Property(t => t.Id).HasColumnName("DmvPprIdf");
            //modelBuilder.Entity<Cliente>().Property(t => t.Cpf).HasColumnName("DmvPprCPF");
            //modelBuilder.Entity<Cliente>().Property(t => t.Email).HasColumnName("DmvPprNom");
            //modelBuilder.Entity<Cliente>().Property(t => t.DataNascimento).HasColumnName("DmvPprDatNas");
            //modelBuilder.Entity<Cliente>().Property(t => t.DataHoraInclusao).HasColumnName("DmcPprIclDat");
        }
    }
}
