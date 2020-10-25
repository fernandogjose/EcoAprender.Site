using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class VideoMap : EntityTypeConfiguration<Video>
    {
        public VideoMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome").IsRequired().HasMaxLength(200);

            //--- Especifico
            Property(t => t.Data).IsRequired();
            Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            Property(t => t.Descricao).IsRequired().HasColumnType("text").IsMaxLength();
            Property(t => t.Embed).IsRequired().HasMaxLength(200);
            Property(t => t.Grupo).HasMaxLength(50);

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.Videos).HasForeignKey(x => x.EscolaId);
        }
    }
}
