﻿using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EntityMapping
{
    public class MedicamentoRealizadoMap : EntityTypeConfiguration<MedicamentoRealizado>
    {
        public MedicamentoRealizadoMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome");

            //--- Especifico
            Property(t => t.Status).HasMaxLength(100);

            //--- Relacionamentos 
            Property(t => t.MedicamentoId);
        }
    }
}
