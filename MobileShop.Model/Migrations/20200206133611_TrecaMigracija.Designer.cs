﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobileShop.Model;

namespace MobileShop.Model.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200206133611_TrecaMigracija")]
    partial class TrecaMigracija
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MobileShop.Model.Database.Artikli", b =>
                {
                    b.Property<int>("ArtikalId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena");

                    b.Property<string>("Naziv");

                    b.Property<string>("Sifra");

                    b.Property<byte[]>("Slika");

                    b.Property<byte[]>("SlikaThumb");

                    b.Property<bool?>("Status");

                    b.HasKey("ArtikalId");

                    b.ToTable("Artikli");
                });

            modelBuilder.Entity("MobileShop.Model.Database.Dobavljaci", b =>
                {
                    b.Property<int>("DobavljacId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("KontaktOsoba");

                    b.Property<string>("Napomena");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Status");

                    b.Property<string>("Telefon");

                    b.Property<string>("Web");

                    b.Property<string>("ZiroRacuni");

                    b.HasKey("DobavljacId");

                    b.ToTable("Dobavljaci");
                });

            modelBuilder.Entity("MobileShop.Model.Database.Klijenti", b =>
                {
                    b.Property<int>("KlijentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRegistracije");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("LozinkaHash");

                    b.Property<string>("LozinkaSalt");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("KlijentId");

                    b.ToTable("Klijenti");
                });

            modelBuilder.Entity("MobileShop.Model.Database.Korisnici", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("LozinkaHash");

                    b.Property<string>("LozinkaSalt");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("KorisnikId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("MobileShop.Model.Database.KorisniciUloge", b =>
                {
                    b.Property<int>("KorisnikUlogaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIzmjene");

                    b.Property<int>("KorisnikId");

                    b.Property<int>("UlogaId");

                    b.HasKey("KorisnikUlogaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UlogaId");

                    b.ToTable("KorisniciUloge");
                });

            modelBuilder.Entity("MobileShop.Model.Database.Nabavka", b =>
                {
                    b.Property<int>("NabavkaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojNabavke");

                    b.Property<DateTime>("Datum");

                    b.Property<int>("DobavljacId");

                    b.Property<decimal>("IznosRacuna");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Napomena");

                    b.Property<decimal>("Pdv");

                    b.Property<int>("SkladisteId");

                    b.HasKey("NabavkaId");

                    b.HasIndex("DobavljacId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Nabavka");
                });

            modelBuilder.Entity("MobileShop.Model.Database.NabavkaStavke", b =>
                {
                    b.Property<int>("NabavkaStavkeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtikalId");

                    b.Property<decimal>("Cijena");

                    b.Property<int>("Kolicina");

                    b.Property<int>("NabavkaId");

                    b.HasKey("NabavkaStavkeId");

                    b.HasIndex("ArtikalId");

                    b.HasIndex("NabavkaId");

                    b.ToTable("NabavkaStavke");
                });

            modelBuilder.Entity("MobileShop.Model.Database.Narudzba", b =>
                {
                    b.Property<int>("NarudzbaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojNarudzbe");

                    b.Property<DateTime>("Datum");

                    b.Property<decimal>("IznosBezPdv");

                    b.Property<decimal>("IznosSaPdv");

                    b.Property<int>("KlijentId");

                    b.Property<int?>("KorisniciKorisnikId");

                    b.Property<bool?>("Otkazano");

                    b.Property<int>("SkladisteId");

                    b.Property<bool>("Status");

                    b.HasKey("NarudzbaId");

                    b.HasIndex("KlijentId");

                    b.HasIndex("KorisniciKorisnikId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("MobileShop.Model.Database.NarudzbaStavke", b =>
                {
                    b.Property<int>("NarudzbaStavkaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtikalId");

                    b.Property<decimal>("Cijena");

                    b.Property<int>("Kolicina");

                    b.Property<int>("NarudzbaId");

                    b.Property<decimal?>("Popust");

                    b.Property<int>("ProizvodId");

                    b.HasKey("NarudzbaStavkaId");

                    b.HasIndex("ArtikalId");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("NarudzbaStavke");
                });

            modelBuilder.Entity("MobileShop.Model.Database.Ocjene", b =>
                {
                    b.Property<int>("OcjenaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtikalId");

                    b.Property<DateTime>("Datum");

                    b.Property<int>("KlijentId");

                    b.Property<int>("Ocjena");

                    b.HasKey("OcjenaId");

                    b.HasIndex("ArtikalId");

                    b.HasIndex("KlijentId");

                    b.ToTable("Ocjene");
                });

            modelBuilder.Entity("MobileShop.Model.Database.Skladista", b =>
                {
                    b.Property<int>("SkladisteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("SkladisteId");

                    b.ToTable("Skladista");
                });

            modelBuilder.Entity("MobileShop.Model.Database.Uloge", b =>
                {
                    b.Property<int>("UlogaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("UlogaId");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("MobileShop.Model.Database.KorisniciUloge", b =>
                {
                    b.HasOne("MobileShop.Model.Database.Korisnici", "Korisnik")
                        .WithMany("KorisniciUloge")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Model.Database.Uloge", "Uloga")
                        .WithMany("KorisniciUloge")
                        .HasForeignKey("UlogaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MobileShop.Model.Database.Nabavka", b =>
                {
                    b.HasOne("MobileShop.Model.Database.Dobavljaci", "Dobavljac")
                        .WithMany("Nabavka")
                        .HasForeignKey("DobavljacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Model.Database.Korisnici", "Korisnik")
                        .WithMany("Nabavka")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Model.Database.Skladista", "Skladiste")
                        .WithMany("Nabavka")
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MobileShop.Model.Database.NabavkaStavke", b =>
                {
                    b.HasOne("MobileShop.Model.Database.Artikli", "Artikal")
                        .WithMany("NabavkaStavke")
                        .HasForeignKey("ArtikalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Model.Database.Nabavka", "Nabavka")
                        .WithMany("NabavkaStavke")
                        .HasForeignKey("NabavkaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MobileShop.Model.Database.Narudzba", b =>
                {
                    b.HasOne("MobileShop.Model.Database.Klijenti", "Klijent")
                        .WithMany("Narudzbe")
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Model.Database.Korisnici")
                        .WithMany("Narudzba")
                        .HasForeignKey("KorisniciKorisnikId");

                    b.HasOne("MobileShop.Model.Database.Skladista", "Skladiste")
                        .WithMany("Narudzba")
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MobileShop.Model.Database.NarudzbaStavke", b =>
                {
                    b.HasOne("MobileShop.Model.Database.Artikli", "Artikal")
                        .WithMany("NarudzbaStavke")
                        .HasForeignKey("ArtikalId");

                    b.HasOne("MobileShop.Model.Database.Narudzba", "Narudzba")
                        .WithMany("NarudzbaStavke")
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MobileShop.Model.Database.Ocjene", b =>
                {
                    b.HasOne("MobileShop.Model.Database.Artikli", "Artikal")
                        .WithMany("Ocjene")
                        .HasForeignKey("ArtikalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Model.Database.Klijenti", "Klijent")
                        .WithMany("Ocjene")
                        .HasForeignKey("KlijentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
