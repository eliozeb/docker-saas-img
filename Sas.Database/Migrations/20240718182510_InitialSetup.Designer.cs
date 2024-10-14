﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sas.Database;

#nullable disable

namespace Sas.Database.Migrations
{
    [DbContext(typeof(SasDbContext))]
    [Migration("20240718182510_InitialSetup")]
    partial class InitialSetup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sas.Database.Entities.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlertType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConfigDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("AlertType", "Id");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("Sas.Database.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BatteryStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeviceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeviceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationDescriptor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "DeviceID", "Id");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            BatteryStatus = "Status1",
                            CreatedAt = new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(470),
                            DeviceID = new Guid("164332cc-30ae-4d4d-8297-9c6d056ebdad"),
                            DeviceName = "Curo 2 staff Fob",
                            LocationDescriptor = "Device Descriptor 1",
                            Status = "Live",
                            TenantId = 100
                        },
                        new
                        {
                            Id = 101,
                            BatteryStatus = "Status2",
                            CreatedAt = new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(488),
                            DeviceID = new Guid("348477a4-9933-42c1-9cc0-4deca317c62c"),
                            DeviceName = "Curo 2 Nurse Fob",
                            LocationDescriptor = "Device Descriptor 2",
                            Status = "Live",
                            TenantId = 100
                        });
                });

            modelBuilder.Entity("Sas.Database.Entities.DeviceFault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfigDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("UpdatedAt", "Id");

                    b.ToTable("DeviceFaults");
                });

            modelBuilder.Entity("Sas.Database.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("EventType", "Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Sas.Database.Entities.HubConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DetectedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ResolvedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("ResolvedAt", "Id");

                    b.ToTable("HubConfigurations");
                });

            modelBuilder.Entity("Sas.Database.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subscription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TenantName", "Id");

                    b.ToTable("Tenants");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            CreatedAt = new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(661),
                            Subscription = "Standard",
                            TenantID = new Guid("cfdc8429-3806-4914-9057-c5fb371c94cd"),
                            TenantName = "CloudSphere"
                        },
                        new
                        {
                            Id = 101,
                            CreatedAt = new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(720),
                            Subscription = "Standard",
                            TenantID = new Guid("71c2908a-3074-48a4-bdc4-bac348398487"),
                            TenantName = "Datastream"
                        },
                        new
                        {
                            Id = 102,
                            CreatedAt = new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(732),
                            Subscription = "Premium",
                            TenantID = new Guid("2bede55d-86a6-4b03-91c6-155e4c30c093"),
                            TenantName = "Bluewave"
                        },
                        new
                        {
                            Id = 103,
                            CreatedAt = new DateTime(2024, 7, 18, 18, 25, 10, 408, DateTimeKind.Utc).AddTicks(743),
                            Subscription = "Premium",
                            TenantID = new Guid("a0df0f17-e5ad-4bfc-a3bb-2c15b302e3f3"),
                            TenantName = "AscendTech"
                        });
                });

            modelBuilder.Entity("Sas.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("LastName", "FirstName", "Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Sas.Database.Entities.Alert", b =>
                {
                    b.HasOne("Sas.Database.Entities.Device", "Device")
                        .WithMany("AlertUpdates")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("Sas.Database.Entities.Device", b =>
                {
                    b.HasOne("Sas.Database.Entities.Tenant", "Tenant")
                        .WithMany("DeviceUpdates")
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Sas.Database.Entities.DeviceFault", b =>
                {
                    b.HasOne("Sas.Database.Entities.Device", "Device")
                        .WithMany("DeviceFaultUpdates")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("Sas.Database.Entities.Event", b =>
                {
                    b.HasOne("Sas.Database.Entities.Device", "Device")
                        .WithMany("EventUpdates")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("Sas.Database.Entities.HubConfiguration", b =>
                {
                    b.HasOne("Sas.Database.Entities.Device", "Device")
                        .WithMany("HubConfigurationUpdates")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("Sas.Database.Entities.User", b =>
                {
                    b.HasOne("Sas.Database.Entities.Tenant", "Tenant")
                        .WithMany("UserUpdates")
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Sas.Database.Entities.Device", b =>
                {
                    b.Navigation("AlertUpdates");

                    b.Navigation("DeviceFaultUpdates");

                    b.Navigation("EventUpdates");

                    b.Navigation("HubConfigurationUpdates");
                });

            modelBuilder.Entity("Sas.Database.Entities.Tenant", b =>
                {
                    b.Navigation("DeviceUpdates");

                    b.Navigation("UserUpdates");
                });
#pragma warning restore 612, 618
        }
    }
}
