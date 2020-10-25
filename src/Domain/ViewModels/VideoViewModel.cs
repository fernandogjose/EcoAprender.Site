using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class VideoViewModel : Base
    {
        public DateTime Data { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Embed { get; set; }

        public string Grupo { get; set; }

        public int EscolaId { get; set; }
    }
}