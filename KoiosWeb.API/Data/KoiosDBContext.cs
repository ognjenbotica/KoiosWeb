﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiosWeb.API.Data;

public partial class KoiosDBContext : DbContext
{
    public KoiosDBContext(DbContextOptions<KoiosDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComputerHardware> ComputerHardwares { get; set; }

    public virtual DbSet<HardwareSpec> HardwareSpecs { get; set; }

    public virtual DbSet<HardwareType> HardwareTypes { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<OfferItem> OfferItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComputerHardware>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Computer__3214EC0793FA0338");

            entity.ToTable("ComputerHardware");

            entity.Property(e => e.Brand)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Type).WithMany(p => p.ComputerHardwares)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ComputerH__TypeI__4BAC3F29");
        });

        modelBuilder.Entity<HardwareSpec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hardware__3214EC07C479D231");

            entity.Property(e => e.SpecKey)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SpecValue)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Hardware).WithMany(p => p.HardwareSpecs)
                .HasForeignKey(d => d.HardwareId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__HardwareS__Hardw__4E88ABD4");
        });

        modelBuilder.Entity<HardwareType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hardware__3214EC0773CCE7D9");

            entity.HasIndex(e => e.TypeName, "UQ__Hardware__D4E7DFA8A9CFB334").IsUnique();

            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Offer__3214EC071E93E8E6");

            entity.ToTable("Offer");

            entity.Property(e => e.DateChanged).HasColumnType("datetime");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
        });

        modelBuilder.Entity<OfferItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OfferIte__3214EC07719CAC56");

            entity.ToTable("OfferItem");

            entity.HasOne(d => d.ComputerHardware).WithMany(p => p.OfferItems)
                .HasForeignKey(d => d.ComputerHardwareId)
                .HasConstraintName("FK__OfferItem__Compu__6A30C649");

            entity.HasOne(d => d.Offer).WithMany(p => p.OfferItems)
                .HasForeignKey(d => d.OfferId)
                .HasConstraintName("FK__OfferItem__Offer__6B24EA82");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}