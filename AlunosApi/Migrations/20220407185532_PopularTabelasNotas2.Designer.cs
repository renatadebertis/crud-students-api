// <auto-generated />
using System;
using AlunosApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlunosApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220407185532_PopularTabelasNotas2")]
    partial class PopularTabelasNotas2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlunosApi.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "joana@gmail.com",
                            Idade = 23,
                            Nome = "Joana Siqueira"
                        },
                        new
                        {
                            Id = 2,
                            Email = "carolina@gmail.com",
                            Idade = 34,
                            Nome = "Carolina Nascimento"
                        });
                });

            modelBuilder.Entity("AlunosApi.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("AlunosApi.Models.Notas", b =>
                {
                    b.Property<int>("IdNotas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("IdAluno")
                        .HasColumnType("int");

                    b.Property<int>("IdDisciplina")
                        .HasColumnType("int");

                    b.HasKey("IdNotas");

                    b.HasIndex("AlunoId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("AlunosApi.Models.Notas", b =>
                {
                    b.HasOne("AlunosApi.Models.Aluno", null)
                        .WithMany("ListaNotas")
                        .HasForeignKey("AlunoId");
                });

            modelBuilder.Entity("AlunosApi.Models.Aluno", b =>
                {
                    b.Navigation("ListaNotas");
                });
#pragma warning restore 612, 618
        }
    }
}
