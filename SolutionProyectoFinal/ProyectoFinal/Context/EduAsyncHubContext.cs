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

        public virtual DbSet<Asistencia> Asistencias { get; set; } = null!;
        public virtual DbSet<Calificacione> Calificaciones { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<EstudianteMaterium> EstudianteMateria { get; set; } = null!;
        public virtual DbSet<Evento> Eventos { get; set; } = null!;
        public virtual DbSet<GradosEscolare> GradosEscolares { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;
        public virtual DbSet<NotaTotal> NotaTotals { get; set; } = null!;
        public virtual DbSet<Noticia> Noticias { get; set; } = null!;
        public virtual DbSet<ProfesorMaterium> ProfesorMateria { get; set; } = null!;
        public virtual DbSet<Profesore> Profesores { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

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
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.Property(e => e.AsistenciaId).HasColumnName("AsistenciaID");

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.FechaAsistencia).HasColumnType("date");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__Asistenci__Estud__5BE2A6F2");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Asistenci__Mater__5CD6CB2B");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK__Asistenci__Profe__5DCAEF64");
            });

            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.HasKey(e => e.CalificacionId)
                    .HasName("PK__Califica__4CF54ABEEEC5C331");

                entity.Property(e => e.CalificacionId).HasColumnName("CalificacionID");

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.FechaPublicacion).HasColumnType("date");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__Calificac__Estud__60A75C0F");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Calificac__Mater__619B8048");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK__Calificac__Profe__628FA481");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasIndex(e => e.UsuarioId, "UQ__Estudian__2B3DE79955BFC579")
                    .IsUnique();

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.GradoId).HasColumnName("GradoID");

                entity.Property(e => e.UsuarioId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UsuarioID");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.GradoId)
                    .HasConstraintName("FK__Estudiant__Grado__534D60F1");

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.Estudiante)
                    .HasForeignKey<Estudiante>(d => d.UsuarioId)
                    .HasConstraintName("FK__Estudiant__Usuar__52593CB8");
            });

            modelBuilder.Entity<EstudianteMaterium>(entity =>
            {
                entity.HasKey(e => e.InscripcionMateriaId)
                    .HasName("PK__Estudian__6352D9CDCBE35943");

                entity.Property(e => e.InscripcionMateriaId).HasColumnName("InscripcionMateriaID");

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.GradoId).HasColumnName("GradoID");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__Estudiant__Estud__6A30C649");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.GradoId)
                    .HasConstraintName("FK__Estudiant__Grado__6C190EBB");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Estudiant__Mater__6B24EA82");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<GradosEscolare>(entity =>
            {
                entity.HasKey(e => e.GradoId)
                    .HasName("PK__GradosEs__5A8DF63407F87D55");

                entity.Property(e => e.GradoId)
                    .ValueGeneratedNever()
                    .HasColumnName("GradoID");

                entity.Property(e => e.NombreGrado)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.NombreMateria)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NotaTotal>(entity =>
            {
                entity.ToTable("NotaTotal");

                entity.HasIndex(e => e.EstudianteId, "UQ__NotaTota__6F7683390C162360")
                    .IsUnique();

                entity.Property(e => e.NotaTotalId).HasColumnName("NotaTotalID");

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.NotaTotal1).HasColumnName("NotaTotal");

                entity.HasOne(d => d.Estudiante)
                    .WithOne(p => p.NotaTotal)
                    .HasForeignKey<NotaTotal>(d => d.EstudianteId)
                    .HasConstraintName("FK__NotaTotal__Estud__66603565");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.NotaTotals)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__NotaTotal__Mater__6754599E");
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<ProfesorMaterium>(entity =>
            {
                entity.HasKey(e => e.AsignacionProfesorId)
                    .HasName("PK__Profesor__86354B59969B0CEF");

                entity.Property(e => e.AsignacionProfesorId).HasColumnName("AsignacionProfesorID");

                entity.Property(e => e.GradoId).HasColumnName("GradoID");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.ProfesorMateria)
                    .HasForeignKey(d => d.GradoId)
                    .HasConstraintName("FK__ProfesorM__Grado__70DDC3D8");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.ProfesorMateria)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__ProfesorM__Mater__6FE99F9F");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.ProfesorMateria)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK__ProfesorM__Profe__6EF57B66");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.ProfesorId)
                    .HasName("PK__Profesor__4DF3F028C195D432");

                entity.HasIndex(e => e.UsuarioId, "UQ__Profesor__2B3DE79991259658")
                    .IsUnique();

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.Property(e => e.UsuarioId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.Profesore)
                    .HasForeignKey<Profesore>(d => d.UsuarioId)
                    .HasConstraintName("FK__Profesore__Usuar__571DF1D5");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK__Roles__F92302D17D3BFAD9");

                entity.Property(e => e.RolId)
                    .ValueGeneratedNever()
                    .HasColumnName("RolID");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__531402F326943E3F")
                    .IsUnique();

                entity.Property(e => e.UsuarioId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UsuarioID");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RolId).HasColumnName("RolID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK__Usuarios__RolID__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
