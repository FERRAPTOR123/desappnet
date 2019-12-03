
using Microsoft.EntityFrameworkCore;
using proyecto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace proyecto.Data 
{
    public class proyectoContext : IdentityDbContext<User>
    {
        public proyectoContext(DbContextOptions<proyectoContext> options) : base(options) 
        {
        }

        public DbSet<Autores> Autores {get; set;}        
        public DbSet<Generos> Generos {get; set;}
        public DbSet<Titulos> Titulos {get; set;}
        public DbSet<Editorial> Editorial {get; set;}
        public DbSet<Imprenta> Imprenta {get; set;}
        public DbSet<User> User {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Editorial>().HasKey(c => new {c.ImprentaID, c.TituloID});
            }
       
    } 
}