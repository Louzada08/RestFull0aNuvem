﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestFull0aNuvem.Model.Context;

namespace RestFull0aNuvem.Migrations
{
    [DbContext(typeof(BdFoodContext))]
    [Migration("20190218190313_UpdateTabelasRelation2")]
    partial class UpdateTabelasRelation2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestFull0aNuvem.Model.Context.Nullable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Permissoes")
                        .IsRequired();

                    b.Property<decimal>("SalarioBase");

                    b.HasKey("Id");

                    b.ToTable("Funcao");
                });

            modelBuilder.Entity("RestFull0aNuvem.Model.Context.Permissao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("PermissaoId");

                    b.Property<long?>("PermissaoParentId");

                    b.Property<bool>("Permitir");

                    b.Property<string>("Titulo")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("PermissaoId");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("RestFull0aNuvem.Model.Context.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.Property<string>("Senha")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("RestFull0aNuvem.Model.Context.Permissao", b =>
                {
                    b.HasOne("RestFull0aNuvem.Model.Context.Permissao")
                        .WithMany("PermisaoParent")
                        .HasForeignKey("PermissaoId");
                });
#pragma warning restore 612, 618
        }
    }
}