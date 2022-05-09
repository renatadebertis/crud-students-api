using AlunosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Service
{
    public interface INotasService
    {
        Task<IEnumerable<Notas>> GetNotasByAluno(int idAluno);

        Task CreateNotas(Notas notas);

        Task UpdateNotas(Notas notas);
    }
}
