using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityMapping
{
    public class GrupoUsuarioMap : EntityTypeConfiguration<GrupoUsuario>
    {
        public GrupoUsuarioMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id);
            Property(t => t.DataInclusao).IsRequired();
            Property(t => t.DataAlteracao).IsRequired();
            Property(t => t.UsuarioNome).IsRequired().HasMaxLength(200);

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.GrupoUsuarios).HasForeignKey(x => x.EscolaId);

            Property(t => t.GrupoId);
            HasRequired(x => x.Grupo).WithMany(x => x.GrupoUsuarios).HasForeignKey(x => x.GrupoId);

            Property(t => t.UsuarioId);
            HasRequired(x => x.Usuario).WithMany(x => x.GrupoUsuarios).HasForeignKey(x => x.UsuarioId);
        }
    }
}
