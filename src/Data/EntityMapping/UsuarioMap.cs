using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityMapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //--- Base
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao").IsRequired();
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao").IsRequired();
            Property(t => t.UsuarioNome).HasColumnName("UsuarioNome").IsRequired().HasMaxLength(200);

            //--- Especifico
            Property(t => t.PushNotificationAndroidRegistrationId).HasMaxLength(500);
            Property(t => t.Nome).HasColumnName("Nome").IsRequired().HasMaxLength(200);
            Property(t => t.Login).HasColumnName("Login").IsRequired().HasMaxLength(100);
            Property(t => t.Senha).HasColumnName("Senha").IsRequired().HasMaxLength(20);
            Property(t => t.Email).HasColumnName("Email").HasMaxLength(200);
            Property(t => t.TelefoneResidencial).HasColumnName("TelefoneResidencial").HasMaxLength(20);
            Property(t => t.TelefoneCelular).HasColumnName("TelefoneCelular").HasMaxLength(20);
            Property(t => t.Foto).HasColumnName("Foto").HasMaxLength(200);
            Property(t => t.Acesso).HasColumnName("Acesso").IsRequired();
            Property(t => t.DataDeAniversario).HasColumnName("DataDeAniversario").IsRequired();
            Property(t => t.Cpf).HasColumnName("Cpf").HasMaxLength(15);
            Property(t => t.Endereco).HasColumnName("Endereco").HasMaxLength(300);
            Property(t => t.Bairro).HasColumnName("Bairro").HasMaxLength(100);
            Property(t => t.Cep).HasColumnName("Cep").HasMaxLength(9);
            Property(t => t.NomeNoBoleto).HasColumnName("NomeNoBoleto").HasMaxLength(200);

            //--- Relacionamentos 
            Property(t => t.EscolaId);
            HasRequired(x => x.Escola).WithMany(x => x.Usuarios).HasForeignKey(x => x.EscolaId);

            Property(t => t.PerfilId).IsRequired();
            HasRequired(x => x.Perfil).WithMany(x => x.Usuarios).HasForeignKey(x => x.PerfilId);
        }
    }
}
