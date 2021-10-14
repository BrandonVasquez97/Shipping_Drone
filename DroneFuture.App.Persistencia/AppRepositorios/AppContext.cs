using Microsoft.EntityFrameworkCore;
using DroneFuture.App.Dominio;

namespace DroneFuture.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas{get;set;}
        public DbSet<Cliente> Clientes{get;set;}
        public DbSet<Encargado> Encargados{get;set;}
        public DbSet<Empresa> Empresas{get;set;}
        public DbSet<EstadoPedido> EstadoPedidos{get;set;}
        public DbSet<PaquetePedido> PaquetePedidos{get;set;}

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = DroneFutureDataFinal");
            }
        }
    }
}