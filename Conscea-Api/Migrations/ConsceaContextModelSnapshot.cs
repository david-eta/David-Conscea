﻿// <auto-generated />
using System;
using Conscea_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsceaApi.Migrations
{
    [DbContext(typeof(ConsceaContext))]
    partial class ConsceaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Conscea_Api.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ShaDigest")
                        .IsRequired()
                        .HasColumnType("varbinary(32)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasFilter("[Phone] IS NOT NULL");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Conscea_Api.Models.CertArchive", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("CertInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CertifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpireDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("AccountId", "CertInfoId", "CertifiedDate");

                    b.HasIndex("CertInfoId");

                    b.ToTable("CertArchive", (string)null);
                });

            modelBuilder.Entity("Conscea_Api.Models.CertInfo", b =>
                {
                    b.Property<string>("CertId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Expire")
                        .HasColumnType("bit");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CertId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CertInfo", (string)null);
                });

            modelBuilder.Entity("Conscea_Api.Models.CertArchive", b =>
                {
                    b.HasOne("Conscea_Api.Models.Account", "Account")
                        .WithMany("CertArchives")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conscea_Api.Models.CertInfo", "CertInfo")
                        .WithMany("CertArchives")
                        .HasForeignKey("CertInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("CertInfo");
                });

            modelBuilder.Entity("Conscea_Api.Models.Account", b =>
                {
                    b.Navigation("CertArchives");
                });

            modelBuilder.Entity("Conscea_Api.Models.CertInfo", b =>
                {
                    b.Navigation("CertArchives");
                });
#pragma warning restore 612, 618
        }
    }
}
