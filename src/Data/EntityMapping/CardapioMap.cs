using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityMapping
{
    public class CardapioMap : EntityTypeConfiguration<Cardapio>
    {
        public CardapioMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao").IsOptional();
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao").IsOptional();
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome").IsRequired().HasMaxLength(200);

            //--- Especifico
            Property(t => t.Grupo).IsRequired().HasMaxLength(100);
            Property(t => t.Arquivo).IsRequired().HasMaxLength(200);

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.Cardapios).HasForeignKey(x => x.EscolaId);
        }
    }
}
