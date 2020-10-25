using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityMapping
{
    public class ComunicadoMap : EntityTypeConfiguration<Comunicado>
    {
        public ComunicadoMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao").IsOptional();
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao").IsOptional();
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome").IsRequired().HasMaxLength(200);

            //--- Especifico
            Property(t => t.Data).HasColumnName("Data").IsRequired().HasColumnType("DateTime");
            Property(t => t.Titulo).HasColumnName("Titulo").IsRequired().HasMaxLength(100);
            Property(t => t.Descricao).HasColumnName("Descricao").IsRequired().IsMaxLength();
            Property(t => t.Confirmar);

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.Comunicados).HasForeignKey(x => x.EscolaId);
        }
    }
}
