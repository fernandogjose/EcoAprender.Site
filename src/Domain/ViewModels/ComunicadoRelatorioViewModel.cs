using System;

namespace Domain.ViewModels
{
    public class ComunicadoRelatorioViewModel
    {
        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; }

        public string ComunicadoTitulo { get; set; }

        public DateTime? DataLeitura { get; set; }

        public DateTime? DataConfirmado { get; set; }

        public bool PedirConfirmacao { get; set; }
    }
}