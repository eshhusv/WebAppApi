using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppApi.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acq> Acqs { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Pair> Pairs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localDB)\\local;Initial Catalog=Niggers;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acq>(entity =>
        {
            entity.HasKey(e => e.IdAcq).HasName("PK__Acq__3B745DA91F87608A");

            entity.ToTable("Acq");

            entity.Property(e => e.IdAcq).HasColumnName("in_acq");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IdClientMan).HasColumnName("id_client_man");
            entity.Property(e => e.IdClientWoman).HasColumnName("id_client_woman");
            entity.Property(e => e.ManAgr).HasColumnName("man_agr");
            entity.Property(e => e.WomanAgr).HasColumnName("woman_agr");

            entity.HasOne(d => d.IdClientManNavigation).WithMany(p => p.AcqIdClientManNavigations)
                .HasForeignKey(d => d.IdClientMan)
                .HasConstraintName("FK_Acq_Client1");

            entity.HasOne(d => d.IdClientWomanNavigation).WithMany(p => p.AcqIdClientWomanNavigations)
                .HasForeignKey(d => d.IdClientWoman)
                .HasConstraintName("FK_Acq_Client");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Client__6EC2B6C0230091D8");

            entity.ToTable("Client");

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.BirthDate).HasColumnName("birthDate");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(255)
                .HasColumnName("gender");
            entity.Property(e => e.HasPair).HasColumnName("has_pair");
            entity.Property(e => e.Interest)
                .HasMaxLength(255)
                .HasColumnName("interest");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Surename)
                .HasMaxLength(255)
                .HasColumnName("surename");
        });

        modelBuilder.Entity<Pair>(entity =>
        {
            entity.HasKey(e => e.IdPair).HasName("PK__Pair__2A3B977594154AD2");

            entity.ToTable("Pair");

            entity.Property(e => e.IdPair).HasColumnName("id_Pair");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdClientMan).HasColumnName("id_client_man");
            entity.Property(e => e.IdClientWoman).HasColumnName("id_client_woman");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdClientManNavigation).WithMany(p => p.PairIdClientManNavigations)
                .HasForeignKey(d => d.IdClientMan)
                .HasConstraintName("FK_Pair_Client1");

            entity.HasOne(d => d.IdClientWomanNavigation).WithMany(p => p.PairIdClientWomanNavigations)
                .HasForeignKey(d => d.IdClientWoman)
                .HasConstraintName("FK_Pair_Client");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
