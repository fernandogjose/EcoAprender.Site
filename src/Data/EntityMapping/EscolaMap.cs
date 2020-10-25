using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityMapping
{
    public class EscolaMap : EntityTypeConfiguration<Escola>
    {
        public EscolaMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id);
            Property(t => t.DataInclusao);
            Property(t => t.DataAlteracao);
            Property(t => t.UsuarioNome).HasMaxLength(200);

            //--- Especifico
            Property(t => t.Nome).IsRequired().HasMaxLength(200);
            Property(t => t.Telefone).IsRequired().HasMaxLength(20);
        }
    }
}
