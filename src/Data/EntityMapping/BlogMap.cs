using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id);
            Property(t => t.DataInclusao);
            Property(t => t.DataAlteracao);
            Property(t => t.UsuarioNome).HasMaxLength(200);

            //--- Especifico
            Property(t => t.Data).IsRequired().HasColumnType("DateTime");
            Property(t => t.Titulo).HasMaxLength(200);
            Property(t => t.Resumo).HasMaxLength(500);
            Property(t => t.Completa).IsRequired().IsMaxLength();
            Property(t => t.FotoCapa).HasMaxLength(100);
            Property(t => t.Categoria).HasMaxLength(30);
            Property(t => t.Tag).HasMaxLength(200);
        }
    }
}
