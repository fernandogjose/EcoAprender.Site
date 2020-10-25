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
    public class RefeicaoTipoRepository : IRefeicaoTipoRepository
    {
        public IList<RefeicaoTipo> List(RefeicaoTipo refeicaoTipo)
        {
            var refeicaoTipos = new List<RefeicaoTipo>();
            RefeicaoTipo refeicaoTipoAux;

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_tipo_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EscolaId", refeicaoTipo.EscolaId);
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            refeicaoTipoAux = new RefeicaoTipo
                            {
                                Descricao = dr["Descricao"].ToString(),
                            };

                            refeicaoTipos.Add(refeicaoTipo);
                        }
                    }
                }
            }

            return refeicaoTipos;
        }

        public void Add(RefeicaoTipo refeicaoTipo)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_tipo_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descricao", refeicaoTipo.Descricao);
                    cmd.Parameters.AddWithValue("@EscolaId", refeicaoTipo.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioNome", refeicaoTipo.UsuarioNome);
                    conn.Open();
                    cmd.ExecuteNonQuery();                    
                }
            }
        }

        public void Update(RefeicaoTipo refeicaoTipo)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_tipo_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descricao", refeicaoTipo.Descricao);
                    cmd.Parameters.AddWithValue("@EscolaId", refeicaoTipo.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioNome", refeicaoTipo.UsuarioNome);
                    cmd.Parameters.AddWithValue("@Id", refeicaoTipo.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(RefeicaoTipo refeicaoTipo)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_refeicao_tipo_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", refeicaoTipo.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
