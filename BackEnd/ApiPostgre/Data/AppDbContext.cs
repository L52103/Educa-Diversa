using Microsoft.EntityFrameworkCore;
using ApiPostgre.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiPostgre.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Definición de los DbSets para cada una de tus entidades
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Multimedia> Multimedia { get; set; }
        public DbSet<PersonaMultimedia> PersonaMultimedia { get; set; }
        public DbSet<Valoracion> Valoraciones { get; set; }
        public DbSet<Foro> Foros { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Persona>().ToTable("personas");
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Usuario>()
                .Property(u => u.TipoUsuario)
                .HasConversion<string>(); //
            modelBuilder.Entity<Categoria>().ToTable("categorias");
            modelBuilder.Entity<Modulo>().ToTable("modulos");
            modelBuilder.Entity<Multimedia>().ToTable("multimedia");
            modelBuilder.Entity<PersonaMultimedia>().ToTable("persona_multimedia"); 
            modelBuilder.Entity<Valoracion>().ToTable("valoraciones");
            modelBuilder.Entity<Foro>().ToTable("foro");
            modelBuilder.Entity<Publicacion>().ToTable("publicacion");


            //  Configuraciones de relaciones y claves primarias compuestas

            // Relacion para PersonaMultimedia (clave primaria compuesta)
            modelBuilder.Entity<PersonaMultimedia>()
                .HasKey(pm => new { pm.CodigoPersona, pm.CodigoMultimedia });

            // Relacion Usuario - Persona (Un usuario tiene una persona)
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.CodigoPersona);

            // Relación Modulo - Categoria (Un módulo pertenece a una categoría)
            modelBuilder.Entity<Modulo>()
                .HasOne(m => m.Categoria)
                .WithMany(c => c.Modulos)
                .HasForeignKey(m => m.CodigoCategoria);

            // Relación Multimedia - Modulo (Una multimedia pertenece a un módulo)
            modelBuilder.Entity<Multimedia>()
                .HasOne(m => m.Modulo)
                .WithMany(mod => mod.Multimedia)
                .HasForeignKey(m => m.CodigoModulo);

            // Relación Multimedia - Persona (Una multimedia tiene un creador)
            modelBuilder.Entity<Multimedia>()
                .HasOne(m => m.Creador)
                .WithMany(p => p.MultimediaCreadas)
                .HasForeignKey(m => m.PersonaCreadora);

            // Relación PersonaMultimedia - Persona
            modelBuilder.Entity<PersonaMultimedia>()
                .HasOne(pm => pm.Persona)
                .WithMany(p => p.MultimediaRelacionadas)
                .HasForeignKey(pm => pm.CodigoPersona);

            // Relación PersonaMultimedia - Multimedia
            modelBuilder.Entity<PersonaMultimedia>()
                .HasOne(pm => pm.Multimedia)
                .WithMany(m => m.PersonasRelacionadas)
                .HasForeignKey(pm => pm.CodigoMultimedia);

            // Relación Valoracion - Persona (Una valoracion está asociada a una persona)
            modelBuilder.Entity<Valoracion>()
                .HasOne(v => v.Persona)
                .WithMany(p => p.Valoraciones)
                .HasForeignKey(v => v.CodigoPersona);

            // Relacion Foro - Persona (Un foro es creado por una persona)
            modelBuilder.Entity<Foro>()
                .HasOne(f => f.Persona)
                .WithMany(p => p.Foros)
                .HasForeignKey(f => f.CodigoPersona);

            // Relación Foro - Modulo (Un foro esta asociado a un módulo)
            modelBuilder.Entity<Foro>()
                .HasOne(f => f.Modulo)
                .WithMany(m => m.Foros)
                .HasForeignKey(f => f.CodigoModulo);

            // Relación Publicacion - Persona (Una publicacion es creada por una persona)
            modelBuilder.Entity<Publicacion>()
                .HasOne(pub => pub.Persona)
                .WithMany(p => p.Publicaciones)
                .HasForeignKey(pub => pub.CodigoPersona);

            // Relación Publicacion - Foro (Una publicacion pertenece a un foro)
            modelBuilder.Entity<Publicacion>()
                .HasOne(pub => pub.Foro)
                .WithMany(f => f.Publicaciones)
                .HasForeignKey(pub => pub.CodigoForo);
        }
    }
}