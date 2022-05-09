using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Models
{
    [Table("Notas")]
    public class Notas
    {
        [Key]
        public int IdNotas { get; set; }

        [ForeignKey("IdAluno")]
        public int IdAluno { get; set; }

        [ForeignKey("IdDisciplina")]
        public int IdDisciplina { get; set; }

        public double valor { get; set; }

        [NotMapped]
        public string Disciplina { get; set; }

    }
}
