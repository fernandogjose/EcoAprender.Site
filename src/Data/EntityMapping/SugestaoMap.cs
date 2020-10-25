using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class SugestaoMap : EntityTypeConfiguration<Sugestao>
    {
        public SugestaoMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome");

            //--- Especifico
            Property(t => t.Nome).HasMaxLength(200);
            Property(t => t.Email).HasMaxLength(200);
            Property(t => t.Titulo).HasMaxLength(200);
            Property(t => t.Descricao).IsMaxLength();
        }
    }
}
