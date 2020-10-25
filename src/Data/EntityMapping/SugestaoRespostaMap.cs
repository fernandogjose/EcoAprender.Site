using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityMapping
{
    public class SugestaoRespostaMap : EntityTypeConfiguration<SugestaoResposta>
    {
        public SugestaoRespostaMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao").IsRequired();
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao").IsRequired();
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome").IsRequired().HasMaxLength(200);

            //--- Especifico
            Property(t => t.Descricao).IsRequired().IsMaxLength();

            //--- Relacionamentos 
            Property(t => t.SugestaoId).IsRequired(); 
            HasRequired(x => x.Sugestao).WithMany(x => x.SugestaoRespostas).HasForeignKey(x => x.SugestaoId);
        }
    }
}
