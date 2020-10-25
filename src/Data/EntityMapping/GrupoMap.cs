using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityMapping
{
    public class GrupoMap : EntityTypeConfiguration<Grupo>
    {
        public GrupoMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao").IsOptional();
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao").IsOptional();
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome").IsRequired().HasMaxLength(200);

            //--- Especifico
            Property(t => t.Descricao).IsRequired().HasMaxLength(100);

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.Grupos).HasForeignKey(x => x.EscolaId);
        }
    }
}
