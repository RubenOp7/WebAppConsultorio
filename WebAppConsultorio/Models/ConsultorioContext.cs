using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppConsultorio.Models
{
    public partial class ConsultorioContext : DbContext
    {
        public ConsultorioContext()
        {
        }

        public ConsultorioContext(DbContextOptions<ConsultorioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<ExamenParasitologium> ExamenParasitologia { get; set; } = null!;
        public virtual DbSet<ExamenUroanalisi> ExamenUroanalises { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctor__F838DB3E6CB83319");

                entity.ToTable("Doctor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExamenParasitologium>(entity =>
            {
                entity.HasKey(e => e.IdExamenParasito)
                    .HasName("PK__ExamenPa__EB60C95FEF604C2A");

                entity.Property(e => e.AncylostomaDondenale)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AscarisLumbricoides)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Consistencia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EntamoebaColi)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EntamoebaHistolitica)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EnterabiusVermicular)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.GiardiaLamblia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HymenolepisDiminuta)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HymenolepisNana)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NecatorAmericano)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TaeniaSaguiata)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TaeniaSalium)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TrichomonasHomunis)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TrichurisTrichura)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.ExamenParasitologia)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorExamenParasito");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.ExamenParasitologia)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteExamenParasito");
            });

            modelBuilder.Entity<ExamenUroanalisi>(entity =>
            {
                entity.HasKey(e => e.IdExamenUro)
                    .HasName("PK__ExamenUr__7C3ED5AD00654E88");

                entity.ToTable("ExamenUroanalisis");

                entity.Property(e => e.Acascorbico)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ACAscorbico");

                entity.Property(e => e.Aspecto)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bilirrubinas)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CelulasEpiteliales)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cilindros)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CuerposCetonicos)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Entrocitos480)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.GravedadEspecifica)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Leucocitos480)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LeucocitosGrumos)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nitritos)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Olor)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ph)
                    .HasColumnType("decimal(3, 1)")
                    .HasColumnName("PH");

                entity.Property(e => e.Reaccion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SangreOculta)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sedimento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SustanciasProteicas)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SustanciasReductoras)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Urobilinogeno)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.ExamenUroanalisis)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorExamen");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.ExamenUroanalisis)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteExamen");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__C93DB49B23C3AF5B");

                entity.ToTable("Paciente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
