﻿// <auto-generated />
using DataReadApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataWriteAPI.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    partial class WriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DataReadApi.Models.Devices.BaseDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("ipAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BaseDevice");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseDevice");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DataReadApi.Models.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("baseDeviceId")
                        .HasColumnType("int");

                    b.Property<bool>("isReadable")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isWritable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("tagName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("baseDeviceId");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("DataReadApi.Models.Devices.PLCDevice", b =>
                {
                    b.HasBaseType("DataReadApi.Models.Devices.BaseDevice");

                    b.HasDiscriminator().HasValue("PLCDevice");
                });

            modelBuilder.Entity("DataReadApi.Models.Devices.RTUDevice", b =>
                {
                    b.HasBaseType("DataReadApi.Models.Devices.BaseDevice");

                    b.Property<int>("port")
                        .HasColumnType("int");

                    b.Property<byte>("slaveId")
                        .HasColumnType("tinyint unsigned");

                    b.HasDiscriminator().HasValue("RTUDevice");
                });

            modelBuilder.Entity("DataReadApi.Models.Register", b =>
                {
                    b.HasOne("DataReadApi.Models.Devices.BaseDevice", null)
                        .WithMany("registers")
                        .HasForeignKey("baseDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataReadApi.Models.Devices.BaseDevice", b =>
                {
                    b.Navigation("registers");
                });
#pragma warning restore 612, 618
        }
    }
}
