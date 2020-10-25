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
    public class RefeicaoAlimentoRepository : IRefeicaoAlimentoRepository
    {
        public IList<RefeicaoAlimento> List(RefeicaoAlimento refeicaoAlimento)
        {
            var refeicaoAlimentos = new List<RefeicaoAlimento>();
            RefeicaoAlimento refeicaoAlimentoAux;

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_alimento_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EscolaId", refeicaoAlimento.EscolaId);
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            refeicaoAlimentoAux = new RefeicaoAlimento
                            {
                                Descricao = dr["Descricao"].ToString(),
                            };

                            refeicaoAlimentos.Add(refeicaoAlimento);
                        }
                    }
                }
            }

            return refeicaoAlimentos;
        }

        public void Add(RefeicaoAlimento refeicaoAlimento)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_alimento_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descricao", refeicaoAlimento.Descricao);
                    cmd.Parameters.AddWithValue("@EscolaId", refeicaoAlimento.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioNome", refeicaoAlimento.UsuarioNome);
                    conn.Open();
                    cmd.ExecuteNonQuery();                    
                }
            }
        }

        public void Update(RefeicaoAlimento refeicaoAlimento)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_alimento_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descricao", refeicaoAlimento.Descricao);
                    cmd.Parameters.AddWithValue("@EscolaId", refeicaoAlimento.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioNome", refeicaoAlimento.UsuarioNome);
                    cmd.Parameters.AddWithValue("@Id", refeicaoAlimento.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(RefeicaoAlimento refeicaoAlimento)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_alimento_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", refeicaoAlimento.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
