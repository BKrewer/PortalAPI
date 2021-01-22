﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalAPI.Data;

namespace PortalAPI.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20200614222535_final-v2")]
    partial class finalv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PortalAPI.Models.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CEP");

                    b.Property<string>("City");

                    b.Property<string>("Complement");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PortalAPI.Models.Donation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicantId");

                    b.Property<string>("AuthorId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("PortalAPI.Models.Item", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("DonationId");

                    b.Property<float>("Height");

                    b.Property<float>("Length");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Value");

                    b.Property<float>("Weight");

                    b.Property<float>("Width");

                    b.HasKey("Id");

                    b.HasIndex("DonationId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("PortalAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Role");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PortalAPI.Models.Address", b =>
                {
                    b.HasOne("PortalAPI.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PortalAPI.Models.Donation", b =>
                {
                    b.HasOne("PortalAPI.Models.User", "User")
                        .WithMany("Donations")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("PortalAPI.Models.Item", b =>
                {
                    b.HasOne("PortalAPI.Models.Donation", "Donation")
                        .WithMany("Items")
                        .HasForeignKey("DonationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}