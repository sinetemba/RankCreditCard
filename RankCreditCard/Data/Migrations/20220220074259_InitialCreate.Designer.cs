﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RankCreditCard.Data;

namespace RankCreditCard.Data.Migrations
{
    [DbContext(typeof(RankCreditCardContext))]
    [Migration("20220220074259_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("RankCreditCard.Models.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CCVNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardHolderName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExpiryMonth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExpiryYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Provider")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });
#pragma warning restore 612, 618
        }
    }
}