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
        public virtual DbSet<GradosEscolare> GradosEscolares { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;
        public virtual DbSet<NotaTotal> NotaTotals { get; set; } = null!;
        public virtual DbSet<ProfesorMaterium> ProfesorMateria { get; set; } = null!;
        public virtual DbSet<Profesore> Profesores { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
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
                    .HasName("PK__Califica__4CF54ABE557A31BB");

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
                entity.HasIndex(e => e.UsuarioId, "UQ__Estudian__2B3DE799F0DE6BD5")
                    .IsUnique();

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.GradoId).HasColumnName("GradoID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

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
                    .HasName("PK__Estudian__6352D9CDF6AF0029");

                entity.Property(e => e.InscripcionMateriaId).HasColumnName("InscripcionMateriaID");

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.GradoId).HasColumnName("GradoID");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__Estudiant__Estud__75A278F5");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.GradoId)
                    .HasConstraintName("FK__Estudiant__Grado__778AC167");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.EstudianteMateria)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Estudiant__Mater__76969D2E");
            });

            modelBuilder.Entity<GradosEscolare>(entity =>
            {
                entity.HasKey(e => e.GradoId)
                    .HasName("PK__GradosEs__5A8DF634CF65C76B");

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

                entity.HasIndex(e => e.EstudianteId, "UQ__NotaTota__6F7683390A250FC0")
                    .IsUnique();

                entity.Property(e => e.NotaTotalId).HasColumnName("NotaTotalID");

                entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.NotaTotal1).HasColumnName("NotaTotal");

                entity.HasOne(d => d.Estudiante)
                    .WithOne(p => p.NotaTotal)
                    .HasForeignKey<NotaTotal>(d => d.EstudianteId)
                    .HasConstraintName("FK__NotaTotal__Estud__71D1E811");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.NotaTotals)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__NotaTotal__Mater__72C60C4A");
            });

            modelBuilder.Entity<ProfesorMaterium>(entity =>
            {
                entity.HasKey(e => e.AsignacionProfesorId)
                    .HasName("PK__Profesor__86354B59F24CA048");

                entity.Property(e => e.AsignacionProfesorId).HasColumnName("AsignacionProfesorID");

                entity.Property(e => e.GradoId).HasColumnName("GradoID");

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.ProfesorMateria)
                    .HasForeignKey(d => d.GradoId)
                    .HasConstraintName("FK__ProfesorM__Grado__7C4F7684");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.ProfesorMateria)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__ProfesorM__Mater__7B5B524B");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.ProfesorMateria)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK__ProfesorM__Profe__7A672E12");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.ProfesorId)
                    .HasName("PK__Profesor__4DF3F02859B3D6CC");

                entity.HasIndex(e => e.UsuarioId, "UQ__Profesor__2B3DE7994BCA4537")
                    .IsUnique();

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.Profesore)
                    .HasForeignKey<Profesore>(d => d.UsuarioId)
                    .HasConstraintName("FK__Profesore__Usuar__571DF1D5");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK__Roles__F92302D1D1E8698B");

                entity.Property(e => e.RolId)
                    .ValueGeneratedNever()
                    .HasColumnName("RolID");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__531402F3947492C0")
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
                    .HasConstraintName("FK__Usuarios__RolID__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
