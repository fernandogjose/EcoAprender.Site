using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Atividade : Base
    {
        public Atividade()
        {
            Data = DateTime.Now;
        }

        public DateTime Data { get; set; }

        [NotMapped]
        public List<string> Fotos { get; set; }

        [NotMapped]
        public string Arquivo { get; set; }

        public string Titulo { get; set; }

        public string Resumo { get; set; }

        public string Completa { get; set; }

        public string CompletaApp { get; set; }

        public string FotoCapa { get; set; }

        public string FotoResumo { get; set; }

        public string Link { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public int Grupo { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }

        public int? GrupoId { get; set; }

        public virtual Grupo GrupoRelacionamento { get; set; }

        [NotMapped]
        public IEnumerable<Grupo> Grupos { get; set; }
    }
}
