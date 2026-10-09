using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TiendawebAPI.Models;

public partial class TiendaPooContext : DbContext
{
    public TiendaPooContext()
    {
    }

    public TiendaPooContext(DbContextOptions<TiendaPooContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=NuevaClaveSegura_2026!;database=tienda_poo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.6.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PRIMARY");

            entity.ToTable("detalle_facturas");

            entity.HasIndex(e => e.IdFactura, "id_factura");

            entity.HasIndex(e => e.IdProducto, "id_producto");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdFactura).HasColumnName("id_factura");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");
            entity.Property(e => e.Subtotal)
                .HasPrecision(10, 2)
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("detalle_facturas_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("detalle_facturas_ibfk_2");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.HasIndex(e => e.IdPuesto, "id_puesto");

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaContratacion).HasColumnName("fecha_contratacion");
            entity.Property(e => e.IdPuesto).HasColumnName("id_puesto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("empleados_ibfk_1");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PRIMARY");

            entity.ToTable("facturas");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.HasIndex(e => e.IdEmpleado, "id_empleado");

            entity.Property(e => e.IdFactura).HasColumnName("id_factura");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("facturas_ibfk_1");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("facturas_ibfk_2");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarcas).HasName("PRIMARY");

            entity.ToTable("marcas");

            entity.Property(e => e.IdMarcas).HasColumnName("id_marcas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProductos).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.IdMarca, "id_marca");

            entity.Property(e => e.IdProductos).HasColumnName("id_productos");
            entity.Property(e => e.IdMarca).HasColumnName("id_marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("productos_ibfk_1");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.IdPuestos).HasName("PRIMARY");

            entity.ToTable("puestos");

            entity.Property(e => e.IdPuestos).HasColumnName("id_puestos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.SalarioBase).HasColumnName("salario_base");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
