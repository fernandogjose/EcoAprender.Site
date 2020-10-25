using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class ChatMensagemMap : EntityTypeConfiguration<ChatMensagem>
    {
        public ChatMensagemMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome");

            //--- Especifico
            Property(t => t.Mensagem).IsRequired().IsMaxLength();

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.ChatMensagens).HasForeignKey(x => x.EscolaId);

            Property(t => t.ChatId);
            HasRequired(x => x.Chat).WithMany(x => x.ChatMensagens).HasForeignKey(x => x.ChatId);

            Property(t => t.De);
            HasRequired(x => x.UsuarioDe).WithMany(x => x.ChatMensagens).HasForeignKey(x => x.De);
        }
    }
}