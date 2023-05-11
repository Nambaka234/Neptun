using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hotel_neptun2.database;

public partial class NeptunContext : DbContext
{
    public NeptunContext()
    {
    }

    public NeptunContext(DbContextOptions<NeptunContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassNomera> ClassNomeras { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Clientnomer> Clientnomers { get; set; }

    public virtual DbSet<Dolgnosty> Dolgnosties { get; set; }

    public virtual DbSet<NomeraOtel> NomeraOtels { get; set; }

    public virtual DbSet<Sotrudniki> Sotrudnikis { get; set; }

    public virtual DbSet<StatusNomera> StatusNomeras { get; set; }

    public virtual DbSet<TypeNomera> TypeNomeras { get; set; }

    public virtual DbSet<Zapisi> Zapisis { get; set; }

    public virtual DbSet<Zayavki> Zayavkis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Database=Neptun;Username=postgres;password=20053");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassNomera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("class_nomera_pk");

            entity.ToTable("class_nomera");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pk");

            entity.ToTable("clients");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(1000)
                .HasColumnName("adress");
            entity.Property(e => e.DataBirthday)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_birthday");
            entity.Property(e => e.DataProgivaniya)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_progivaniya");
            entity.Property(e => e.Email)
                .HasMaxLength(225)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PassportDannie)
                .HasMaxLength(1000)
                .HasColumnName("passport_dannie");
            entity.Property(e => e.Patronyc)
                .HasMaxLength(50)
                .HasColumnName("patronyc");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Clientnomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clientnomers_pk");

            entity.ToTable("clientnomers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClassNomera)
                .HasMaxLength(100)
                .HasColumnName("class_nomera");
            entity.Property(e => e.Cost)
                .HasPrecision(19, 4)
                .HasColumnName("cost");
            entity.Property(e => e.Mainimagepath)
                .HasMaxLength(100)
                .HasColumnName("mainimagepath");
            entity.Property(e => e.Nomer)
                .HasMaxLength(100)
                .HasColumnName("nomer");
            entity.Property(e => e.StatusNomera)
                .HasMaxLength(100)
                .HasColumnName("status_nomera");
        });

        modelBuilder.Entity<Dolgnosty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dolgnosty_pk");

            entity.ToTable("dolgnosty");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<NomeraOtel>(entity =>
        {
            entity.HasKey(e => e.IdNomera).HasName("newtable_pk");

            entity.ToTable("nomera_otel");

            entity.Property(e => e.IdNomera)
                .ValueGeneratedNever()
                .HasColumnName("id_nomera");
            entity.Property(e => e.Cost)
                .HasPrecision(19, 4)
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.IdClassNomera).HasColumnName("id_class_nomera");
            entity.Property(e => e.Mainimagepeth)
                .HasMaxLength(1000)
                .HasColumnName("mainimagepeth");
            entity.Property(e => e.Nomer)
                .HasMaxLength(100)
                .HasColumnName("nomer");
            entity.Property(e => e.PromegutokZanyat).HasColumnName("promegutok_zanyat");

            entity.HasOne(d => d.IdClassNomeraNavigation).WithMany(p => p.NomeraOtels)
                .HasForeignKey(d => d.IdClassNomera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("nomera_otel_fk");
        });

        modelBuilder.Entity<Sotrudniki>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sotrudniki_pk");

            entity.ToTable("sotrudniki");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(1000)
                .HasColumnName("adress");
            entity.Property(e => e.DataBirthday)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_birthday");
            entity.Property(e => e.DataPriemaNaRabotu)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_priema_na_rabotu");
            entity.Property(e => e.DataUvolneniya)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_uvolneniya");
            entity.Property(e => e.Email)
                .HasMaxLength(225)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.IdDolgnosti).HasColumnName("id_dolgnosti");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.HasOne(d => d.IdDolgnostiNavigation).WithMany(p => p.Sotrudnikis)
                .HasForeignKey(d => d.IdDolgnosti)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sotrudniki_fk");
        });

        modelBuilder.Entity<StatusNomera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_nomera_pk");

            entity.ToTable("status_nomera");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TypeNomera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_nomera_pk");

            entity.ToTable("type_nomera");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Zapisi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("zapisi_pk");

            entity.ToTable("zapisi");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CostNomera)
                .HasColumnType("money")
                .HasColumnName("cost_nomera");
            entity.Property(e => e.DateViezda).HasColumnName("date_viezda");
            entity.Property(e => e.DateZaezda).HasColumnName("date_zaezda");
            entity.Property(e => e.IdKlienta).HasColumnName("id_klienta");
            entity.Property(e => e.IdMenegera).HasColumnName("id_menegera");
            entity.Property(e => e.IdNomera).HasColumnName("id_nomera");

            entity.HasOne(d => d.IdKlientaNavigation).WithMany(p => p.Zapisis)
                .HasForeignKey(d => d.IdKlienta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zapisi_fk_1");

            entity.HasOne(d => d.IdMenegeraNavigation).WithMany(p => p.Zapisis)
                .HasForeignKey(d => d.IdMenegera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zapisi_fk");
        });

        modelBuilder.Entity<Zayavki>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("zayavki_pk");

            entity.ToTable("zayavki");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CategoriyaNomera)
                .HasMaxLength(100)
                .HasColumnName("categoriya_nomera");
            entity.Property(e => e.DataBirthday)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_birthday");
            entity.Property(e => e.DataViezda)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_viezda");
            entity.Property(e => e.DataZaezda)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_zaezda");
            entity.Property(e => e.Email)
                .HasMaxLength(225)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.KolVoProgivaushih)
                .HasMaxLength(100)
                .HasColumnName("kol-vo_progivaushih");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Nomer)
                .HasMaxLength(100)
                .HasColumnName("nomer");
            entity.Property(e => e.Patronimyc)
                .HasMaxLength(100)
                .HasColumnName("patronimyc");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.StatusZaprosa)
                .HasMaxLength(100)
                .HasColumnName("status_zayavki");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
