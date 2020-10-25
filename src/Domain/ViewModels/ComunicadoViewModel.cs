using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class ComunicadoViewModel
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public bool Confirmar { get; set; }

        public IList<ComunicadoConfirmarUsuarioViewModel> ComunicadoConfirmarUsuarios { get; set; }
    }
}