using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityMapping
{
    public class CalendarioMap : EntityTypeConfiguration<Calendario>
    {
        public CalendarioMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao").IsOptional();
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao").IsOptional();
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome").IsRequired().HasMaxLength(200);

            //--- Especifico
            Property(t => t.Data).HasColumnName("Data").IsRequired().HasColumnType("DateTime");
            Property(t => t.Evento).IsRequired().HasMaxLength(200);

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.Calendarios).HasForeignKey(x => x.EscolaId);
        }
    }
}
