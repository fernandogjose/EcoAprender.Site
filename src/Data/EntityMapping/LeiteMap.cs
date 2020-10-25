using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class LeiteMap : EntityTypeConfiguration<Leite>
    {
        public LeiteMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome");

            //--- Especifico
            Property(t => t.Horario);
            Property(t => t.Quantidade);
            Property(t => t.Temperatura);

            //--- Relacionamentos 
            Property(t => t.AgendaId);
        }
    }
}
