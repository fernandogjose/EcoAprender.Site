using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Medicamento : Base
    {
        public string Remedio { get; set; }

        public string Dose { get; set; }

        public string Horario { get; set; }

        public DateTime De { get; set; }

        public DateTime Ate { get; set; }

        public int AlunoId { get; set; }

        public int EscolaId { get; set; }

        [NotMapped]
        public int UsuarioId { get; set; }
    }
}
