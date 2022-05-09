using AlunosApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Context
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Notas> Notas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Joana Siqueira",
                    Email = "joana@gmail.com",
                    Idade = 23
                },

                new Aluno
                {
                    Id = 2,
                    Nome = "Carolina Nascimento",
                    Email = "carolina@gmail.com",
                    Idade = 34
                }
            );

            /*modelBuilder.Entity<Disciplina>().HasData(
                new Disciplina
                {
                    Id = 1,
                    Descricao = "Matemática"
                },

                new Disciplina
                {
                    Id = 2,
                    Descricao = "Inglês"
                }
            );

            modelBuilder.Entity<Notas>().HasData(

                new Notas
                {
                    IdNotas = 1,
                    IdAluno = 1,
                    IdDisciplina = 2
                },

                new Notas
                {
                    IdNotas = 2,
                    IdAluno = 1,
                    IdDisciplina = 1
                },

                new Notas
                {
                    IdNotas = 3,
                    IdAluno = 2,
                    IdDisciplina = 2
                },

                new Notas
                {
                    IdNotas = 4,
                    IdAluno = 2,
                    IdDisciplina = 1
                }
            );*/
        }
    }
}
