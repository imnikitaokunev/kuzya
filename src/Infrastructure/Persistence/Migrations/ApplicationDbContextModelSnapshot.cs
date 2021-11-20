﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Chat", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Domain.Entities.OnlinerApartment", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OnlinerApartments");
                });

            modelBuilder.Entity("Domain.Entities.OnlinerSetup", b =>
                {
                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<double?>("MaxPrice")
                        .HasColumnType("float");

                    b.Property<double?>("MinPrice")
                        .HasColumnType("float");

                    b.HasKey("ChatId");

                    b.ToTable("OnlinerSetups");
                });

            modelBuilder.Entity("Domain.Entities.OnlinerSetup", b =>
                {
                    b.HasOne("Domain.Entities.Chat", null)
                        .WithOne("OnlinerSetup")
                        .HasForeignKey("Domain.Entities.OnlinerSetup", "ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Chat", b =>
                {
                    b.Navigation("OnlinerSetup")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
