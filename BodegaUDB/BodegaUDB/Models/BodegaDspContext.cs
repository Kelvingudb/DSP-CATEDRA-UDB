using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BodegaUDB.Models;

public partial class BodegaDspContext : DbContext
{
    public BodegaDspContext()
    {
    }

    public BodegaDspContext(DbContextOptions<BodegaDspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleEmpleado> DetalleEmpleados { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DETALLE___B4F46A57D06E044D");

            entity.ToTable("DETALLE_EMPLEADO");

            entity.HasIndex(e => e.Correo, "UQ__DETALLE___264F33C8456BB8EB").IsUnique();

            entity.HasIndex(e => e.Dui, "UQ__DETALLE___C03671B97ABBA16B").IsUnique();

            entity.HasIndex(e => e.Telefono, "UQ__DETALLE___D6F16945B40D615A").IsUnique();

            entity.Property(e => e.IdDetalle).HasColumnName("ID_DETALLE");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Dui)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("DUI");
            entity.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__EMPLEADO__922CA269D8CCD6FD");

            entity.ToTable("EMPLEADO");

            entity.HasIndex(e => e.IdDetalleEmpleado, "UQ__EMPLEADO__A385A34902137288").IsUnique();

            entity.HasIndex(e => e.Usuario, "UQ__EMPLEADO__E251F4847BFA374F").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.IdDetalleEmpleado).HasColumnName("ID_DETALLE_EMPLEADO");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Usuario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("USUARIO");

            entity.HasOne(d => d.IdDetalleEmpleadoNavigation).WithOne(p => p.Empleado)
                .HasForeignKey<Empleado>(d => d.IdDetalleEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_empleado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
