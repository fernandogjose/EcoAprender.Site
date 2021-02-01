using Domain.Entities.Email;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityMapping
{
    public class FaleConoscoMap : EntityTypeConfiguration<FaleConosco>
    {
        public FaleConoscoMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id);
            Property(t => t.DataInclusao).IsRequired();
            Property(t => t.DataAlteracao).IsRequired();
            Property(t => t.UsuarioNome).IsRequired().HasMaxLength(200);

            //--- Especifico
            Property(t => t.Nome).IsRequired().HasMaxLength(200);
            Property(t => t.Email).IsRequired().HasMaxLength(300);
            Property(t => t.Telefone).IsRequired().HasMaxLength(300);
            Property(t => t.Assunto).IsRequired().HasMaxLength(300);
            Property(t => t.Mensagem).IsRequired().IsMaxLength();
        }
    }
}
