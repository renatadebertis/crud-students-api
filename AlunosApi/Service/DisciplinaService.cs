using AlunosApi.Context;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Service
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly AppDbContext _context;

        public DisciplinaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Disciplina>> GetDisciplinas()
        {
            try
            {
                return await _context.Disciplinas.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
