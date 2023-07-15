using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models;

public partial class DbPruebasContext : DbContext
{
    public DbPruebasContext()
    {
    }

    public DbPruebasContext(DbContextOptions<DbPruebasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbEmpledo> TbEmpledos { get; set; }

    public virtual DbSet<TbTarea> TbTareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local);Database=DbPruebas;User ID=sa;Password=sicairos123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;TrustServerCertificate=True;MultiSubnetFailover=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbEmpledo>(entity =>
        {
            entity.HasKey(e => e.EmpleadoPkId);

            entity.ToTable("tbEmpledos");

            entity.Property(e => e.Correo)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Direccion)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Nombre)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Telefono)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        });

        modelBuilder.Entity<TbTarea>(entity =>
        {
            entity.HasKey(e => e.TareaPkId);

            entity.ToTable("tbTareas");

            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
