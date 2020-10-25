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
    public class RefeicaoRepository : IRefeicaoRepository
    {
        public IList<Refeicao> List(Refeicao refeicao)
        {
            var refeicaos = new List<Refeicao>();
            Refeicao refeicaoAux;

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgendaId", refeicao.AgendaId);
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            refeicaoAux = new Refeicao
                            {
                                Observacao = dr["Observacao"].ToString(),
                            };

                            refeicaos.Add(refeicao);
                        }
                    }
                }
            }

            return refeicaos;
        }

        public void Add(Refeicao refeicao)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgendaId", refeicao.AgendaId);
                    cmd.Parameters.AddWithValue("@Horario", refeicao.Horario);
                    cmd.Parameters.AddWithValue("@RefeicaoAlimentoId", refeicao.RefeicaoAlimentoId);
                    cmd.Parameters.AddWithValue("@RefeicaoStatusId", refeicao.RefeicaoStatusId);
                    cmd.Parameters.AddWithValue("@RefeicaoTipoId", refeicao.RefeicaoTipoId);
                    cmd.Parameters.AddWithValue("@Observacao", refeicao.Observacao);
                    cmd.Parameters.AddWithValue("@UsuarioNome", refeicao.UsuarioNome);
                    conn.Open();
                    cmd.ExecuteNonQuery();                    
                }
            }
        }

        public void Update(Refeicao refeicao)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgendaId", refeicao.AgendaId);
                    cmd.Parameters.AddWithValue("@Horario", refeicao.Horario);
                    cmd.Parameters.AddWithValue("@RefeicaoAlimentoId", refeicao.RefeicaoAlimentoId);
                    cmd.Parameters.AddWithValue("@RefeicaoStatusId", refeicao.RefeicaoStatusId);
                    cmd.Parameters.AddWithValue("@RefeicaoTipoId", refeicao.RefeicaoTipoId);
                    cmd.Parameters.AddWithValue("@Observacao", refeicao.Observacao);
                    cmd.Parameters.AddWithValue("@UsuarioNome", refeicao.UsuarioNome);
                    cmd.Parameters.AddWithValue("@Id", refeicao.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Refeicao refeicao)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", refeicao.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
