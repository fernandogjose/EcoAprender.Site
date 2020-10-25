using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Comunicado : Base
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public bool Confirmar { get; set; }

        public virtual ICollection<ComunicadoConfirmarUsuario> ComunicadoConfirmarUsuarios { get; set; }

        public virtual ICollection<ComunicadoLeituraUsuario> ComunicadoLeituraUsuarios { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }

        public Comunicado()
        {
            Data = DateTime.Now.Add(TimeSpan.FromDays(1));
        }
    }
}
