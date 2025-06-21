using Microsoft.EntityFrameworkCore;
using ApiPostgre.Models;

namespace ApiPostgre.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        
        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Modulo> Modulos => Set<Modulo>();
        public DbSet<Multimedia> Multimedia => Set<Multimedia>();
        public DbSet<PersonaMultimedia> PersonaMultimedia => Set<PersonaMultimedia>();
        public DbSet<Valoracion> Valoraciones => Set<Valoracion>();
        public DbSet<Foro> Foros => Set<Foro>();
        public DbSet<Publicacion> Publicaciones => Set<Publicacion>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonaMultimedia>()
                .HasKey(pm => new { pm.CodigoPersona, pm.CodigoMultimedia });

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.CodigoPersona);

            modelBuilder.Entity<Modulo>()
                .HasOne(m => m.Categoria)
                .WithMany(c => c.Modulos)
                .HasForeignKey(m => m.CodigoCategoria);

            modelBuilder.Entity<Multimedia>()
                .HasOne(m => m.Modulo)
                .WithMany(mod => mod.Multimedia)
                .HasForeignKey(m => m.CodigoModulo);

            modelBuilder.Entity<Multimedia>()
                .HasOne(m => m.Creador)
                .WithMany(p => p.MultimediaCreadas)
                .HasForeignKey(m => m.PersonaCreadora);

            modelBuilder.Entity<PersonaMultimedia>()
                .HasOne(pm => pm.Persona)
                .WithMany(p => p.MultimediaRelacionadas)
                .HasForeignKey(pm => pm.CodigoPersona);

            modelBuilder.Entity<PersonaMultimedia>()
                .HasOne(pm => pm.Multimedia)
                .WithMany(m => m.PersonasRelacionadas)
                .HasForeignKey(pm => pm.CodigoMultimedia);

            modelBuilder.Entity<Valoracion>()
                .HasOne(v => v.Persona)
                .WithMany(p => p.Valoraciones)
                .HasForeignKey(v => v.CodigoPersona);

            modelBuilder.Entity<Foro>()
                .HasOne(f => f.Persona)
                .WithMany(p => p.Foros)
                .HasForeignKey(f => f.CodigoPersona);

            modelBuilder.Entity<Foro>()
                .HasOne(f => f.Modulo)
                .WithMany(m => m.Foros)
                .HasForeignKey(f => f.CodigoModulo);

            modelBuilder.Entity<Publicacion>()
                .HasOne(pub => pub.Persona)
                .WithMany(p => p.Publicaciones)
                .HasForeignKey(pub => pub.CodigoPersona);

            modelBuilder.Entity<Publicacion>()
                .HasOne(pub => pub.Foro)
                .WithMany(f => f.Publicaciones)
                .HasForeignKey(pub => pub.CodigoForo);
        }
    }
}
