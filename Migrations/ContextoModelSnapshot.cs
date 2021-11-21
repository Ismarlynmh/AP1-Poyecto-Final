﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prueba_Ismarlin_Proyecto.DAL;

namespace Prueba_Ismarlin_Proyecto.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Compras", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDeCompra")
                        .HasColumnType("TEXT");

                    b.Property<double>("ITBIS")
                        .HasColumnType("REAL");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompraId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.ComprasDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompraId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.ToTable("ComprasDetalle");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Empleados", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Sueldo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmpleadoId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<int>("Inventario")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MarcaProducto")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PrecioDeCompra")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PrecioDeVenta")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SuplidoresSuplidorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductoId");

                    b.HasIndex("SuplidoresSuplidorId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Suplidores", b =>
                {
                    b.Property<int>("SuplidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ciudad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompania")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreSuplidor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SuplidorId");

                    b.ToTable("Suplidores");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contrasena")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Apellidos = "Admin",
                            Cedula = "88888888888",
                            Celular = "8888888888",
                            Contrasena = "Admin",
                            Direccion = "SFM",
                            Email = "admin123@gmail.com",
                            FechaIngreso = new DateTime(2021, 11, 21, 17, 30, 54, 903, DateTimeKind.Local).AddTicks(7406),
                            NombreUsuario = "Admin",
                            Nombres = "Admin",
                            Sexo = "Femenino",
                            Telefono = "8888888888",
                            TipoUsuario = "Administrador"
                        });
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("TEXT");

                    b.Property<double>("ITBIS")
                        .HasColumnType("REAL");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VentaId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.VentasDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VentaId");

                    b.ToTable("VentasDetalle");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Compras", b =>
                {
                    b.HasOne("Prueba_Ismarlin_Proyecto.Entidades.Usuarios", null)
                        .WithMany("Compras")
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.ComprasDetalle", b =>
                {
                    b.HasOne("Prueba_Ismarlin_Proyecto.Entidades.Compras", null)
                        .WithMany("Detalle")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Empleados", b =>
                {
                    b.HasOne("Prueba_Ismarlin_Proyecto.Entidades.Usuarios", null)
                        .WithMany("Empleados")
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Productos", b =>
                {
                    b.HasOne("Prueba_Ismarlin_Proyecto.Entidades.Suplidores", null)
                        .WithMany("Productos")
                        .HasForeignKey("SuplidoresSuplidorId");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.VentasDetalle", b =>
                {
                    b.HasOne("Prueba_Ismarlin_Proyecto.Entidades.Ventas", null)
                        .WithMany("Detalle")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Compras", b =>
                {
                    b.Navigation("Detalle");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Suplidores", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Usuarios", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Prueba_Ismarlin_Proyecto.Entidades.Ventas", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
