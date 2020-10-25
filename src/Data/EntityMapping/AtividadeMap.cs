using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class AtividadeMap : EntityTypeConfiguration<Atividade>
    {
        public AtividadeMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome");

            //--- Especifico
            Property(t => t.Data).HasColumnName("Data").IsRequired().HasColumnType("DateTime");
            Property(t => t.Titulo).HasColumnName("Titulo").HasMaxLength(500);
            Property(t => t.Link).HasMaxLength(500);
            Property(t => t.Resumo).HasColumnName("Resumo").HasMaxLength(500);
            Property(t => t.Completa).HasColumnName("Completa").IsRequired().IsMaxLength();
            Property(t => t.CompletaApp).IsRequired().IsMaxLength();
            Property(t => t.FotoCapa).HasColumnName("FotoCapa").HasMaxLength(100).IsOptional();
            Property(t => t.FotoResumo).HasMaxLength(100).IsOptional();

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.Atividades).HasForeignKey(x => x.EscolaId);
            
            Property(t => t.GrupoId);
            HasOptional(x => x.GrupoRelacionamento).WithMany(x => x.Atividades).HasForeignKey(x => x.GrupoId);
        }
    }
}
