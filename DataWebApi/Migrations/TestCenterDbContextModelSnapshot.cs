﻿// <auto-generated />
using System;
using DataWebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataWebApi.Migrations
{
    [DbContext(typeof(TestCenterDbContext))]
    partial class TestCenterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataWebApi.Models.BaseProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("TestCenterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestCenterId");

                    b.ToTable("BaseProcess");
                });

            modelBuilder.Entity("DataWebApi.Models.Devices.BaseDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BaseProcessId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("ipAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BaseProcessId");

                    b.ToTable("BaseDevice");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseDevice");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DataWebApi.Models.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BaseDeviceId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isReadable")
                        .HasColumnType("bit");

                    b.Property<bool>("isWritable")
                        .HasColumnType("bit");

                    b.Property<string>("tagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BaseDeviceId");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("DataWebApi.Models.TestCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("TestCenter");
                });

            modelBuilder.Entity("DataWebApi.Models.Devices.PLCDevice", b =>
                {
                    b.HasBaseType("DataWebApi.Models.Devices.BaseDevice");

                    b.HasDiscriminator().HasValue("PLCDevice");
                });

            modelBuilder.Entity("DataWebApi.Models.Devices.RTUDevice", b =>
                {
                    b.HasBaseType("DataWebApi.Models.Devices.BaseDevice");

                    b.HasDiscriminator().HasValue("RTUDevice");
                });

            modelBuilder.Entity("DataWebApi.Models.BaseProcess", b =>
                {
                    b.HasOne("DataWebApi.Models.TestCenter", null)
                        .WithMany("processes")
                        .HasForeignKey("TestCenterId");
                });

            modelBuilder.Entity("DataWebApi.Models.Devices.BaseDevice", b =>
                {
                    b.HasOne("DataWebApi.Models.BaseProcess", null)
                        .WithMany("devices")
                        .HasForeignKey("BaseProcessId");
                });

            modelBuilder.Entity("DataWebApi.Models.Register", b =>
                {
                    b.HasOne("DataWebApi.Models.Devices.BaseDevice", null)
                        .WithMany("registers")
                        .HasForeignKey("BaseDeviceId");
                });

            modelBuilder.Entity("DataWebApi.Models.BaseProcess", b =>
                {
                    b.Navigation("devices");
                });

            modelBuilder.Entity("DataWebApi.Models.Devices.BaseDevice", b =>
                {
                    b.Navigation("registers");
                });

            modelBuilder.Entity("DataWebApi.Models.TestCenter", b =>
                {
                    b.Navigation("processes");
                });
#pragma warning restore 612, 618
        }
    }
}
