using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Data.SqlClient;
using System.Data;
using Data.Helper;
using System;

namespace Data.Repositories
{
    public class AtividadeRepository : BaseRepository<Atividade>, IAtividadeRepository
    {
        public AtividadeRepository()
            : base() { }

        public void SelecionarFotoCapa(Atividade atividade)
        {
            var sql = string.Format("UPDATE Atividade SET FotoCapa = '{0}' WHERE Id = {1}", atividade.FotoCapa, atividade.Id);

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SelecionarFotoResumo(Atividade atividade)
        {
            var sql = string.Format("UPDATE Atividade SET FotoResumo = '{0}' WHERE Id = {1}", atividade.FotoResumo, atividade.Id);

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Salvar(Atividade atividade)
        {
            var sql = string.Format("INSERT INTO Atividade (Grupo, FotoCapa, FotoResumo, DataInclusao, DataAlteracao, UsuarioNome, Data, Titulo, Resumo, Completa, Link, MetaDescription, MetaTitle, CompletaApp, EscolaId, GrupoId) " +
                                    "VALUES (0, '', '', GETDATE(), GETDATE(), 'Admin', '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, {9}) SELECT SCOPE_IDENTITY()", 
                                    atividade.Data.ToString("yyyy-MM-dd"), atividade.Titulo, atividade.Resumo, atividade.Completa, atividade.Link, atividade.MetaDescription, atividade.MetaTitle, atividade.CompletaApp, atividade.EscolaId, atividade.GrupoId);
            if (atividade.Id > 0)
            {
                sql = string.Format("UPDATE Atividade SET " +
                    "DataAlteracao = GETDATE(), " +
                    "Data = '{0}', " +
                    "Titulo = '{1}', " +
                    "Resumo = '{2}', " +
                    "Completa = '{3}', " +
                    "Link = '{4}', " +
                    "MetaDescription = '{5}', " +
                    "MetaTitle = '{6}', " +
                    "CompletaApp = '{7}', " +
                    "EscolaId = {8}, " +
                    "GrupoId = {9} " +
                    "WHERE Id = {10}",
                    atividade.Data.ToString("yyyy-MM-dd"),
                    atividade.Titulo,
                    atividade.Resumo,
                    atividade.Completa,
                    atividade.Link,
                    atividade.MetaDescription,
                    atividade.MetaTitle,
                    atividade.CompletaApp,
                    atividade.EscolaId,
                    atividade.GrupoId,
                    atividade.Id);
            }

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    atividade.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
