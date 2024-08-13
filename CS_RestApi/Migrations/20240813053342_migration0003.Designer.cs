﻿// <auto-generated />
using System;
using CS_RestApi.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CS_RestApi.Migrations
{
    [DbContext(typeof(AzureContext))]
    [Migration("20240813053342_migration0003")]
    partial class migration0003
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CS_RestApi.DAL.Entities.Order", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderNumber"));

                    b.Property<DateTime>("OrderCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderCustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.HasKey("OrderNumber")
                        .HasName("PK_OrderNumber");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CS_RestApi.DAL.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderItemAmount")
                        .HasColumnType("int");

                    b.Property<string>("OrderItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OrderItemSinglePrice")
                        .HasColumnType("float");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId")
                        .HasName("PK_OrderItemId");

                    b.HasIndex("OrderNumber");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("CS_RestApi.DAL.Entities.OrderItem", b =>
                {
                    b.HasOne("CS_RestApi.DAL.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_OrderItem_Order");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CS_RestApi.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
