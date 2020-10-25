using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityMapping
{
    public class ComunicadoConfirmarUsuarioMap : EntityTypeConfiguration<ComunicadoConfirmarUsuario>
    {
        public ComunicadoConfirmarUsuarioMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id);
            Property(t => t.DataInclusao).IsOptional();
            Property(t => t.DataAlteracao).IsOptional();
            Property(t => t.UsuarioNome).IsRequired().HasMaxLength(200);

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.ComunicadoConfirmarUsuarios).HasForeignKey(x => x.EscolaId);

            Property(t => t.UsuarioId);
            HasRequired(x => x.Usuario).WithMany(x => x.ComunicadoConfirmarUsuarios).HasForeignKey(x => x.UsuarioId);

            Property(t => t.ComunicadoId);
            HasRequired(x => x.Comunicado).WithMany(x => x.ComunicadoConfirmarUsuarios).HasForeignKey(x => x.ComunicadoId);
        }
    }
}
