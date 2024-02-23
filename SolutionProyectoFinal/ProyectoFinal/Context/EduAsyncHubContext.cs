using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoFinal.Models;

namespace ProyectoFinal.Context
{
    public partial class EduAsyncHubContext : DbContext
    {
        public EduAsyncHubContext()
        {
        }

        public EduAsyncHubContext(DbContextOptions<EduAsyncHubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignacione> Asignaciones { get; set; } = null!;
        public virtual DbSet<Asistencium> Asistencia { get; set; } = null!;
        public virtual DbSet<Auditorium> Auditoria { get; set; } = null!;
        public virtual DbSet<Calificacione> Calificaciones { get; set; } = null!;
        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;
        public virtual DbSet<Mensaje> Mensajes { get; set; } = null!;
        public virtual DbSet<Profesore> Profesores { get; set; } = null!;
        public virtual DbSet<RespuestasEstudiante> RespuestasEstudiantes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignacione>(entity =>
            {
                entity.HasKey(e => e.AsignacionId)
                    .HasName("PK__Asignaci__D82B5BB778CB92D6");

                entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.FechaPublicacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Asignaciones)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Asignacio__Mater__7B5B524B");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Asignaciones)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK__Asignacio__Profe__7C4F7684");
            });

            modelBuilder.Entity<Asistencium>(entity =>
            {
                entity.HasKey(e => e.AsistenciaId)
                    .HasName("PK__Asistenc__72710F45876CB01A");

                entity.Property(e => e.AsistenciaId).HasColumnName("AsistenciaID");

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.FechaAsistencia).HasColumnType("date");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__Asistenci__Estud__02FC7413");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Asistenci__Mater__03F0984C");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK__Asistenci__Profe__04E4BC85");
            });

            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.HasKey(e => e.AuditoriaId)
                    .HasName("PK__Auditori__095694E3B4876E7C");

                entity.Property(e => e.AuditoriaId).HasColumnName("AuditoriaID");

                entity.Property(e => e.Accion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Auditoria__Usuar__0D7A0286");
            });

            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.HasKey(e => e.CalificacionId)
                    .HasName("PK__Califica__4CF54ABE1440523D");

                entity.Property(e => e.CalificacionId).HasColumnName("CalificacionID");

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.FechaPublicacion).HasColumnType("date");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__Calificac__Estud__07C12930");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Calificac__Mater__08B54D69");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK__Calificac__Profe__09A971A2");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.Property(e => e.CarreraId)
                    .ValueGeneratedNever()
                    .HasColumnName("CarreraID");

                entity.Property(e => e.NombreCarrera)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasMany(d => d.Materia)
                    .WithMany(p => p.Carreras)
                    .UsingEntity<Dictionary<string, object>>(
                        "CarrerasMateria",
                        l => l.HasOne<Materia>().WithMany().HasForeignKey("MateriaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CarrerasM__Mater__6FE99F9F"),
                        r => r.HasOne<Carrera>().WithMany().HasForeignKey("CarreraId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CarrerasM__Carre__6EF57B66"),
                        j =>
                        {
                            j.HasKey("CarreraId", "MateriaId").HasName("PK__Carreras__3E93A85989CF6D46");

                            j.ToTable("CarrerasMaterias");

                            j.IndexerProperty<int>("CarreraId").HasColumnName("CarreraID");

                            j.IndexerProperty<int>("MateriaId").HasColumnName("MateriaID");
                        });
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasIndex(e => e.UsuarioId, "UQ__Estudian__2B3DE7990CEE35E8")
                    .IsUnique();

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.CarreraId).HasColumnName("CarreraID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.CarreraId)
                    .HasConstraintName("FK__Estudiant__Carre__66603565");

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.Estudiante)
                    .HasForeignKey<Estudiante>(d => d.UsuarioId)
                    .HasConstraintName("FK__Estudiant__Usuar__656C112C");

                entity.HasMany(d => d.Materia)
                    .WithMany(p => p.Estudiantes)
                    .UsingEntity<Dictionary<string, object>>(
                        "EstudianteMaterium",
                        l => l.HasOne<Materia>().WithMany().HasForeignKey("MateriaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Estudiant__Mater__778AC167"),
                        r => r.HasOne<Estudiante>().WithMany().HasForeignKey("EstudianteId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Estudiant__Estud__76969D2E"),
                        j =>
                        {
                            j.HasKey("EstudianteId", "MateriaId").HasName("PK__Estudian__6FA69AE026A546F9");

                            j.ToTable("EstudianteMateria");

                            j.IndexerProperty<int>("EstudianteId").HasColumnName("EstudianteID");

                            j.IndexerProperty<int>("MateriaId").HasColumnName("MateriaID");
                        });
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.NombreMateria)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.Property(e => e.MensajeId).HasColumnName("MensajeID");

                entity.Property(e => e.FechaEnvio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mensaje1)
                    .HasColumnType("text")
                    .HasColumnName("Mensaje");

                entity.Property(e => e.SeccionId).HasColumnName("SeccionID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mensajes__Usuari__17036CC0");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.ProfesorId)
                    .HasName("PK__Profesor__4DF3F0288D391F2D");

                entity.HasIndex(e => e.UsuarioId, "UQ__Profesor__2B3DE7998543D754")
                    .IsUnique();

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.Profesore)
                    .HasForeignKey<Profesore>(d => d.UsuarioId)
                    .HasConstraintName("FK__Profesore__Usuar__6A30C649");

                entity.HasMany(d => d.Materia)
                    .WithMany(p => p.Profesors)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProfesorMaterium",
                        l => l.HasOne<Materia>().WithMany().HasForeignKey("MateriaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProfesorM__Mater__73BA3083"),
                        r => r.HasOne<Profesore>().WithMany().HasForeignKey("ProfesorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProfesorM__Profe__72C60C4A"),
                        j =>
                        {
                            j.HasKey("ProfesorId", "MateriaId").HasName("PK__Profesor__4D23E9F0F0A57D41");

                            j.ToTable("ProfesorMateria");

                            j.IndexerProperty<int>("ProfesorId").HasColumnName("ProfesorID");

                            j.IndexerProperty<int>("MateriaId").HasColumnName("MateriaID");
                        });
            });

            modelBuilder.Entity<RespuestasEstudiante>(entity =>
            {
                entity.HasKey(e => e.RespuestaId)
                    .HasName("PK__Respuest__31F7FC315DCB133A");

                entity.Property(e => e.RespuestaId).HasColumnName("RespuestaID");

                entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");

                entity.Property(e => e.ComentariosProfesor).HasColumnType("text");

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.Respuesta).HasColumnType("text");

                entity.HasOne(d => d.Asignacion)
                    .WithMany(p => p.RespuestasEstudiantes)
                    .HasForeignKey(d => d.AsignacionId)
                    .HasConstraintName("FK__Respuesta__Asign__00200768");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.RespuestasEstudiantes)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__Respuesta__Estud__7F2BE32F");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK__Roles__F92302D11CF8489E");

                entity.Property(e => e.RolId)
                    .ValueGeneratedNever()
                    .HasColumnName("RolID");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__531402F343DA2E8C")
                    .IsUnique();

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionBreve)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FotoPerfil)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Habilidades)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Intereses)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RolId).HasColumnName("RolID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK__Usuarios__RolID__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
