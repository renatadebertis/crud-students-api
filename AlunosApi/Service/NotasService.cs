using AlunosApi.Context;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Service
{
    public class NotasService : INotasService
    {
        private readonly AppDbContext _context;

        public NotasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notas>> GetNotasByAluno(int idAluno)
        {
            List<Notas> notas = await _context.Notas.Where(n => n.IdAluno == idAluno).ToListAsync();
            return notas;
        }

        public async Task CreateNotas(Notas notas)
        {
            _context.Notas.Add(notas);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNotas(Notas notas)
        {
            _context.Entry(notas).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
