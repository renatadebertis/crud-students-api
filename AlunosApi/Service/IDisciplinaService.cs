using AlunosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Service
{
    public interface IDisciplinaService
    {
        Task<List<Disciplina>> GetDisciplinas();
    }
}
