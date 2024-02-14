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

        public virtual DbSet<Asistencium> Asistencia { get; set; } = null!;
        public virtual DbSet<Calificacione> Calificaciones { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Mensaje> Mensajes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuariosCurso> UsuariosCursos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ADALBERTO\\SQLEXPRESS;Database=EduAsyncHub;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asistencium>(entity =>
            {
                entity.HasKey(e => e.AsistenciaId)
                    .HasName("PK__Asistenc__72710F4516C37E3E");

                entity.Property(e => e.AsistenciaId).HasColumnName("AsistenciaID");

                entity.Property(e => e.CursoId).HasColumnName("CursoID");

                entity.Property(e => e.EstadoAsistencia).HasMaxLength(50);

                entity.Property(e => e.FechaAsistencia).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.CursoId)
                    .HasConstraintName("FK__Asistenci__Curso__5629CD9C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Asistenci__UserI__5535A963");
            });

            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.HasKey(e => e.CalificacionId)
                    .HasName("PK__Califica__4CF54ABEAC89619B");

                entity.Property(e => e.CalificacionId).HasColumnName("CalificacionID");

                entity.Property(e => e.CursoId).HasColumnName("CursoID");

                entity.Property(e => e.PeriodoEvaluacion).HasMaxLength(2);

                entity.Property(e => e.TipoEvaluacion).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ValorCalificacion).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.CursoId)
                    .HasConstraintName("FK__Calificac__Curso__59FA5E80");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Calificac__UserI__59063A47");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.CursoId).HasColumnName("CursoID");

                entity.Property(e => e.NombreCurso).HasMaxLength(100);
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.Property(e => e.MensajeId).HasColumnName("MensajeID");

                entity.Property(e => e.CursoId).HasColumnName("CursoID");

                entity.Property(e => e.FechaHoraPublicacion).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.CursoId)
                    .HasConstraintName("FK__Mensajes__CursoI__4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Mensajes__UserID__4D94879B");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Usuarios__1788CCAC5DE57D5C");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Contraseña).HasMaxLength(100);

                entity.Property(e => e.CorreoElectronico).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Rol).HasMaxLength(50);
            });

            modelBuilder.Entity<UsuariosCurso>(entity =>
            {
                entity.HasKey(e => e.UsuarioCursoId)
                    .HasName("PK__Usuarios__1BE004E66BE5695C");

                entity.ToTable("Usuarios_Cursos");

                entity.Property(e => e.UsuarioCursoId).HasColumnName("UsuarioCursoID");

                entity.Property(e => e.CursoId).HasColumnName("CursoID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.UsuariosCursos)
                    .HasForeignKey(d => d.CursoId)
                    .HasConstraintName("FK__Usuarios___Curso__52593CB8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsuariosCursos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Usuarios___UserI__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
