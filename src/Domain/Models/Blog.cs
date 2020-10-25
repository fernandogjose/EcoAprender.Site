using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Blog : Base
    {
        public DateTime Data { get; set; }

        public string Titulo { get; set; }

        public string Resumo { get; set; }

        public string Completa { get; set; }

        public string FotoCapa { get; set; }

        public string FotoResumo { get; set; }

        public string Link { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public string Categoria { get; set; }

        public string Tag { get; set; }
    }
}
