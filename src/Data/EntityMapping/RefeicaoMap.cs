using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class RefeicaoMap : EntityTypeConfiguration<Refeicao>
    {
        public RefeicaoMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome");

            //--- Especifico
            Property(t => t.Horario);
            Property(t => t.Observacao).IsMaxLength();

            //--- Relacionamentos 
            Property(t => t.RefeicaoAlimentoId);
            Property(t => t.RefeicaoStatusId);
            Property(t => t.RefeicaoTipoId);
        }
    }
}
