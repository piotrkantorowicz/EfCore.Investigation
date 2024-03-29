﻿// <auto-generated />
using System;
using EfCore.Investigation.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCore.Investigation.Migrations
{
    [DbContext(typeof(BudgetSharingDbContext))]
    [Migration("20240208035303_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("BudgetSharing")
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfCore.Investigation.Domain.BudgetPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId")
                        .IsUnique();

                    b.ToTable("BudgetPermissions", "BudgetSharing");
                });

            modelBuilder.Entity("EfCore.Investigation.Domain.BudgetPermission", b =>
                {
                    b.OwnsMany("EfCore.Investigation.Domain.Permission", "Permissions", b1 =>
                        {
                            b1.Property<Guid>("BudgetPermissionId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("ParticipantId")
                                .HasColumnType("uuid");

                            b1.Property<int>("PermissionType")
                                .HasColumnType("integer");

                            b1.HasKey("BudgetPermissionId", "Id");

                            b1.ToTable("Permission", "BudgetSharing");

                            b1.WithOwner()
                                .HasForeignKey("BudgetPermissionId");
                        });

                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
