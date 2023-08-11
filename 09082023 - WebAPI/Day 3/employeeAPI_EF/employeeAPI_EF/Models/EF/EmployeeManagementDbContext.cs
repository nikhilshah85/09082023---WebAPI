using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace employeeAPI_EF.Models.EF;

public partial class EmployeeManagementDbContext : DbContext
{
    public EmployeeManagementDbContext()
    {
    }

    public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptDetail> DeptDetails { get; set; }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=employeeManagementDB;integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptDetail>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__deptDeta__BE2D3F555ABC870D");

            entity.ToTable("deptDetails");

            entity.Property(e => e.DeptNo)
                .ValueGeneratedNever()
                .HasColumnName("deptNo");
            entity.Property(e => e.DeptHead)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptHead");
            entity.Property(e => e.DeptName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptName");
        });

        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__employee__AFB33592CDACBB59");

            entity.ToTable("employeeDetails");

            entity.Property(e => e.EmpNo)
                .ValueGeneratedNever()
                .HasColumnName("empNo");
            entity.Property(e => e.EmpCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empCity");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empDesignation");
            entity.Property(e => e.EmpIsPermenant).HasColumnName("empIsPermenant");
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.EmpSalary).HasColumnName("empSalary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
