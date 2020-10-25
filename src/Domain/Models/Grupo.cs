using System.Collections.Generic;

namespace Domain.Entities
{
    public class Grupo : Base
    {
        public string Descricao { get; set; }

        public virtual ICollection<GrupoUsuario> GrupoUsuarios { get; set; }

        public virtual ICollection<Chat> ChatsPara { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }
    }
}
