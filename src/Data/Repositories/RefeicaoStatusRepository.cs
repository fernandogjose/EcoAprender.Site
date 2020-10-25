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
    public class RefeicaoStatusRepository : IRefeicaoStatusRepository
    {
        public IList<RefeicaoStatus> List(RefeicaoStatus refeicaoStatus)
        {
            var refeicaoStatuss = new List<RefeicaoStatus>();
            RefeicaoStatus refeicaoStatusAux;

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_status_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EscolaId", refeicaoStatus.EscolaId);
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            refeicaoStatusAux = new RefeicaoStatus
                            {
                                Descricao = dr["Descricao"].ToString(),
                            };

                            refeicaoStatuss.Add(refeicaoStatus);
                        }
                    }
                }
            }

            return refeicaoStatuss;
        }

        public void Add(RefeicaoStatus refeicaoStatus)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_status_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descricao", refeicaoStatus.Descricao);
                    cmd.Parameters.AddWithValue("@EscolaId", refeicaoStatus.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioNome", refeicaoStatus.UsuarioNome);
                    conn.Open();
                    cmd.ExecuteNonQuery();                    
                }
            }
        }

        public void Update(RefeicaoStatus refeicaoStatus)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_status_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descricao", refeicaoStatus.Descricao);
                    cmd.Parameters.AddWithValue("@EscolaId", refeicaoStatus.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioNome", refeicaoStatus.UsuarioNome);
                    cmd.Parameters.AddWithValue("@Id", refeicaoStatus.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(RefeicaoStatus refeicaoStatus)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_status_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", refeicaoStatus.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
