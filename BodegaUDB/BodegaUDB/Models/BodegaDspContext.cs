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

    public virtual DbSet<CategoriaPasillo> CategoriaPasillos { get; set; }

    public virtual DbSet<CategoriaPerecedero> CategoriaPerecederos { get; set; }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<DetalleEmpleado> DetalleEmpleados { get; set; }

    public virtual DbSet<DetalleProducto> DetalleProductos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Lote> Lotes { get; set; }

    public virtual DbSet<Pasillo> Pasillos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<StockProducto> StockProductos { get; set; }

    public virtual DbSet<UserRol> UserRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PCHOME\\SQLEXPRESS; Database=Bodega_DSP; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaPasillo>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__4BD51FA563F0579A");

            entity.ToTable("CATEGORIA_PASILLO");

            entity.HasIndex(e => e.Nombre, "UQ__CATEGORI__B21D0AB9E32FFD6E").IsUnique();

            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<CategoriaPerecedero>(entity =>
        {
            entity.HasKey(e => e.IdPerecedero).HasName("PK__CATEGORI__410BC5385647BB29");

            entity.ToTable("CATEGORIA_PERECEDERO");

            entity.HasIndex(e => e.Nombre, "UQ__CATEGORI__B21D0AB977CF146B").IsUnique();

            entity.Property(e => e.IdPerecedero).HasColumnName("ID_PERECEDERO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__4BD51FA53650F34B");

            entity.ToTable("CATEGORIA_PRODUCTO");

            entity.HasIndex(e => e.Nombre, "UQ__CATEGORI__B21D0AB91E084A46").IsUnique();

            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdPerecedero).HasColumnName("ID_PERECEDERO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdPerecederoNavigation).WithMany(p => p.CategoriaProductos)
                .HasForeignKey(d => d.IdPerecedero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_perecedero_categoria");
        });

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

        modelBuilder.Entity<DetalleProducto>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DETALLE___B4F46A578F140B04");

            entity.ToTable("DETALLE_PRODUCTO");

            entity.HasIndex(e => e.IdProducto, "UQ__DETALLE___88BD0356FA820E20").IsUnique();

            entity.Property(e => e.IdDetalle).HasColumnName("ID_DETALLE");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.FechaCaducidad).HasColumnName("FECHA_CADUCIDAD");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdProductoNavigation).WithOne(p => p.DetalleProducto)
                .HasForeignKey<DetalleProducto>(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Detalle_producto");
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

        modelBuilder.Entity<Lote>(entity =>
        {
            entity.HasKey(e => e.IdLote).HasName("PK__LOTE__994D3FD975BE16BE");

            entity.ToTable("LOTE");

            entity.HasIndex(e => e.NumSerie, "UQ__LOTE__FC48906CB109E54E").IsUnique();

            entity.Property(e => e.IdLote).HasColumnName("ID_LOTE");
            entity.Property(e => e.FechaIngreso).HasColumnName("FECHA_INGRESO");
            entity.Property(e => e.FechaProduccion).HasColumnName("FECHA_PRODUCCION");
            entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");
            entity.Property(e => e.NumSerie).HasColumnName("NUM_SERIE");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Lotes)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_proveedor_lote");
        });

        modelBuilder.Entity<Pasillo>(entity =>
        {
            entity.HasKey(e => e.IdPasillo).HasName("PK__PASILLO__83F2AACA76D42D88");

            entity.ToTable("PASILLO");

            entity.Property(e => e.IdPasillo).HasColumnName("ID_PASILLO");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Pasillos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_categoria_pasillo");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__PRODUCTO__88BD0357F227F180");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.CategoriaProducto).HasColumnName("CATEGORIA_PRODUCTO");
            entity.Property(e => e.SerieLote).HasColumnName("SERIE_LOTE");

            entity.HasOne(d => d.CategoriaProductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_categoria_producto");

            entity.HasOne(d => d.SerieLoteNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.SerieLote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Lote_producto");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__PROVEEDO__733DB4C4FF28FFE8");

            entity.ToTable("PROVEEDOR");

            entity.HasIndex(e => e.Correo, "UQ__PROVEEDO__264F33C83E0947AE").IsUnique();

            entity.HasIndex(e => e.Telefono, "UQ__PROVEEDO__D6F1694504C9F99D").IsUnique();

            entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__203B0F68D763AB95");

            entity.ToTable("ROL");

            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<StockProducto>(entity =>
        {
            entity.HasKey(e => e.IdStock).HasName("PK__STOCK_PR__C261F5CDE5C88419");

            entity.ToTable("STOCK_PRODUCTO");

            entity.HasIndex(e => e.IdPasillo, "UQ__STOCK_PR__83F2AACB89F08DD8").IsUnique();

            entity.HasIndex(e => e.Sku, "UQ__STOCK_PR__CA1ECF0DA259C792").IsUnique();

            entity.Property(e => e.IdStock).HasColumnName("ID_STOCK");
            entity.Property(e => e.IdPasillo).HasColumnName("ID_PASILLO");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.Sku)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("SKU");

            entity.HasOne(d => d.IdPasilloNavigation).WithOne(p => p.StockProducto)
                .HasForeignKey<StockProducto>(d => d.IdPasillo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pasillo_producto");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.StockProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_stock");
        });

        modelBuilder.Entity<UserRol>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__USER_ROL__FDFF35BFDA34B4CC");

            entity.ToTable("USER_ROL");

            entity.HasIndex(e => e.IdEmpleado, "UQ__USER_ROL__922CA268D591D598").IsUnique();

            entity.Property(e => e.IdAsignacion).HasColumnName("ID_ASIGNACION");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithOne(p => p.UserRol)
                .HasForeignKey<UserRol>(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleado_rol");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserRols)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
