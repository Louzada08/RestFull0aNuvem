﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestFull0aNuvem.Model.Context;

namespace RestFull0aNuvem.Migrations
{
    [DbContext(typeof(BdFoodContext))]
    [Migration("20190211204243_TabelaUsuarioInicio")]
    partial class TabelaUsuarioInicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestFull0aNuvem.Model.Context.Usuario", b =>
                {
                    b.Property<long>("Idpk")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.Property<string>("Senha")
                        .HasMaxLength(15);

                    b.HasKey("Idpk");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}