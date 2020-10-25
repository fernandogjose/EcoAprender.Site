using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityMapping
{
    public class ChatMap : EntityTypeConfiguration<Chat>
    {
        public ChatMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id);
            Property(t => t.DataInclusao).IsRequired();
            Property(t => t.DataAlteracao).IsRequired();
            Property(t => t.UsuarioNome).IsRequired().HasMaxLength(200);

            //--- Especifico
            Property(t => t.ParaTipo).IsRequired().HasMaxLength(200);
            Property(t => t.Assunto).IsRequired().HasMaxLength(300);
            Property(t => t.Mensagem).IsRequired().IsMaxLength();

            //--- Relacionamentos 
            Property(t => t.GrupoParaId);
            HasOptional(x => x.GrupoPara).WithMany(x => x.ChatsPara).HasForeignKey(x => x.GrupoParaId);

            Property(t => t.Para);
            HasOptional(x => x.UsuarioPara).WithMany(x => x.ChatsPara).HasForeignKey(x => x.Para);

            Property(t => t.De).IsRequired();
            HasRequired(x => x.UsuarioDe).WithMany(x => x.ChatsDe).HasForeignKey(x => x.De);

            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.Chats).HasForeignKey(x => x.EscolaId);
        }
    }
}
