using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Video : Base
    {
        public DateTime Data { get; set; }

        public string Titulo { get; set; }
        
        public string Descricao { get; set; }
        
        public string Embed { get; set; }

        public string Grupo { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }

        [NotMapped]
        public IEnumerable<Grupo> Grupos { get; set; }
    }
}
