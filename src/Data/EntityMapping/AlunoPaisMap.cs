using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class AlunoPaisMap : EntityTypeConfiguration<AlunoPais>
    {
        public AlunoPaisMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome");

            //--- Relacionamentos 
            Property(t => t.AlunoId);
            HasRequired(x => x.Aluno).WithMany(x => x.AlunosPais).HasForeignKey(x => x.AlunoId);

            Property(t => t.UsuarioId);
            HasRequired(x => x.Usuario).WithMany(x => x.AlunosPais).HasForeignKey(x => x.UsuarioId);

            Property(t => t.ParentescoId);
            HasRequired(x => x.Parentesco).WithMany(x => x.AlunosPais).HasForeignKey(x => x.ParentescoId);
        }
    }
}
