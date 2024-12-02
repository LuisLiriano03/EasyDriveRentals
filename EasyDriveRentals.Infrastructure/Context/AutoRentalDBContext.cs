using EasyDriveRentals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyDriveRentals.Infrastructure.Context;

public partial class AutoRentalDBContext : DbContext
{
    public AutoRentalDBContext()
    {
    }

    public AutoRentalDBContext(DbContextOptions<AutoRentalDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<GenderInfo> GenderInfos { get; set; } = null!;
    public virtual DbSet<Menu> Menus { get; set; } = null!;
    public virtual DbSet<Rol> Rols { get; set; } = null!;
    public virtual DbSet<RolMenu> RolMenus { get; set; } = null!;
    public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.AppliedDiscount).HasColumnType("decimal(5, 2)");

            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.DateOfBirth).HasColumnType("date");

            entity.Property(e => e.DriverLicenseNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.IdNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IdPhoto)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.IdType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.IsVip)
                .HasColumnName("IsVIP")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.LicenseExpiryDate).HasColumnType("date");

            entity.Property(e => e.LicenseIssuingCountry)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PasswordHash)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.PhotoAdditionalDocument)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.PhotoDriverLicense)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.PhotoPassport)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.RegistrationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.RentalFrequency).HasDefaultValueSql("((0))");

            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Gender)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Customer__Gender__5FB337D6");

            entity.HasOne(d => d.Rol)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Customer__RolId__60A75C0F");
        });

        modelBuilder.Entity<GenderInfo>(entity =>
        {
            entity.HasKey(e => e.GenderId)
                .HasName("PK__GenderIn__4E24E9F77EB240E2");

            entity.ToTable("GenderInfo");

            entity.Property(e => e.GenderName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.ActionPage)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Controller)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.DescriptionMenu)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IconMenu)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.ParentMenu)
                .WithMany(p => p.InverseParentMenu)
                .HasForeignKey(d => d.ParentMenuId)
                .HasConstraintName("FK__Menu__ParentMenu__49C3F6B7");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("Rol");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.Property(e => e.NameRol)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RegistrationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<RolMenu>(entity =>
        {
            entity.ToTable("RolMenu");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Menu)
                .WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK__RolMenu__MenuId__52593CB8");

            entity.HasOne(d => d.Rol)
                .WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__RolMenu__RolId__5165187F");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__UserInfo__1788CC4CEEDEA761");

            entity.ToTable("UserInfo");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IdNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            entity.Property(e => e.PasswordHash)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RegistrationDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Gender)
                .WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__UserInfo__Gender__59063A47");

            entity.HasOne(d => d.Rol)
                .WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__UserInfo__RolId__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
