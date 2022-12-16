﻿// <auto-generated />
using Banco.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Banco.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221216175201_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Banco.Dominios.ContaCorrente", b =>
                {
                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<string>("Titular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Numero");

                    b.ToTable("ContaCorrete");
                });
#pragma warning restore 612, 618
        }
    }
}
