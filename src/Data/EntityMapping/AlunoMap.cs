using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome");

            //--- Especifico
            Property(t => t.Nome).HasMaxLength(100);

            //--- Relacionamentos 
            Property(t => t.GrupoId);
            HasRequired(x => x.Grupo).WithMany(x => x.Alunos).HasForeignKey(x => x.GrupoId);

            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.Alunos).HasForeignKey(x => x.EscolaId);
        }
    }
}
