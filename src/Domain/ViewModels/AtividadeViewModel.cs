using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class AtividadeViewModel : Base
    {
        public DateTime Data { get; set; }

        public string Titulo { get; set; }

        public string Resumo { get; set; }

        public string Completa { get; set; }

        public string CompletaApp { get; set; }

        public string CompletaAppFormatada { get; set; }

        public string FotoCapa { get; set; }

        public string FotoResumo { get; set; }

        public string Link { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public int Grupo { get; set; }

        public int EscolaId { get; set; }

        public GrupoViewModel GrupoViewModel { get; set; }

        public string Arquivo { get; set; }

        public List<string> Fotos { get; set; }
    }
}