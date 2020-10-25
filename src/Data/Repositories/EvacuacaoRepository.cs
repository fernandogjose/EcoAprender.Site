using Data.Helper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class EvacuacaoRepository : IEvacuacaoRepository
    {
        public IList<Evacuacao> List(Evacuacao evacuacao)
        {
            var evacuacaos = new List<Evacuacao>();
            Evacuacao evacuacaoAux;

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_evacuacao_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgendaId", evacuacao.AgendaId);
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            evacuacaoAux = new Evacuacao
                            {
                                AgendaId = Convert.ToInt32(dr["AgendaId"].ToString()),
                            };

                            evacuacaos.Add(evacuacao);
                        }
                    }
                }
            }

            return evacuacaos;
        }

        public void Add(Evacuacao evacuacao)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_evacuacao_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgendaId", evacuacao.AgendaId);
                    cmd.Parameters.AddWithValue("@Status", evacuacao.Status);
                    cmd.Parameters.AddWithValue("@UsuarioNome", evacuacao.UsuarioNome);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Evacuacao evacuacao)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_evacuacao_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgendaId", evacuacao.AgendaId);
                    cmd.Parameters.AddWithValue("@Status", evacuacao.Status);
                    cmd.Parameters.AddWithValue("@UsuarioNome", evacuacao.UsuarioNome);
                    cmd.Parameters.AddWithValue("@Id", evacuacao.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Evacuacao evacuacao)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_evacuacao_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", evacuacao.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
