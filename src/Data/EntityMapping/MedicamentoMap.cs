using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class MedicamentoMap : EntityTypeConfiguration<Medicamento>
    {
        public MedicamentoMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome");

            //--- Especifico
            Property(t => t.Remedio).HasMaxLength(100);
            Property(t => t.Dose).HasMaxLength(100);
            Property(t => t.Horario).HasMaxLength(100);
            Property(t => t.De);
            Property(t => t.Ate);

            //--- Relacionamentos 
            Property(t => t.AlunoId);
            Property(t => t.EscolaId);
        }
    }
}
