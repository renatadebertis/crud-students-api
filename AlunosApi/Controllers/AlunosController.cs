using AlunosApi.Models;
using AlunosApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;
        private IDisciplinaService _disciplinaService;
        private INotasService _notasService;

        public AlunosController(IAlunoService alunoService, INotasService notasService, IDisciplinaService disciplinaService)
        {
            _alunoService = alunoService;
            _notasService = notasService;
            _disciplinaService = disciplinaService;
        }

        [HttpGet]

        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();

                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }

        [HttpGet("AlunosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>>
            GetAlunosByName([FromQuery] string nome)

        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);

                if (alunos.Count() == 0)
                    return NotFound($"Não existem alunos com o critério {nome}");

                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter aluno");
            }
        }

        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);

                if (aluno == null)
                    return NotFound($"Não existe aluno com o Id= {id}");

                List<Disciplina> listDisciplinas = await _disciplinaService.GetDisciplinas();
                var listNotas = await _notasService.GetNotasByAluno(id);

                aluno.ListaNotas = new List<Notas>();

                foreach (Notas nota in listNotas)
                {
                    nota.Disciplina = listDisciplinas.Find(d => d.Id == nota.IdDisciplina)?.Descricao;
                    aluno.ListaNotas.Add(nota);
                }

                return Ok(aluno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter aluno");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);

               var listDisciplinas =  await _disciplinaService.GetDisciplinas();
               
               foreach (Disciplina d in listDisciplinas )
                {
                    Notas notas = new Notas();
                    notas.IdAluno = aluno.Id;
                    notas.IdDisciplina = d.Id;
                    notas.valor = 0;

                    await _notasService.CreateNotas(notas);
                }

                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aluno aluno )
        {
            try
            {
                if(aluno.Id == id)
                {
                    await _alunoService.UpdateAluno(aluno);

                    foreach(Notas n in aluno.ListaNotas)
                    {
                        await _notasService.UpdateNotas(n);
                    }

                    return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if(aluno != null)
                {
                   await _alunoService.DeleteAluno(aluno);
                   return Ok($"Aluno de id={id} foi excluído com sucesso");
                }
                else
                {
                    return NotFound($"Aluno com id={id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

    }
}
