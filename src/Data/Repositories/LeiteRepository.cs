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
    public class LeiteRepository : ILeiteRepository
    {
        public IList<Leite> List(Leite leite)
        {
            var leites = new List<Leite>();
            Leite leiteAux;

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_leite_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EscolaId", leite.AgendaId);
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            leiteAux = new Leite
                            {
                                AgendaId = Convert.ToInt32(dr["AgendaId"].ToString()),
                            };

                            leites.Add(leite);
                        }
                    }
                }
            }

            return leites;
        }

        public void Add(Leite leite)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_leite_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descricao", leite.AgendaId);
                    cmd.Parameters.AddWithValue("@Horario", leite.Horario);
                    cmd.Parameters.AddWithValue("@Quantidade", leite.Quantidade);
                    cmd.Parameters.AddWithValue("@Temperatura", leite.Temperatura);
                    cmd.Parameters.AddWithValue("@UsuarioNome", leite.UsuarioNome);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Leite leite)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_leite_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descricao", leite.AgendaId);
                    cmd.Parameters.AddWithValue("@Horario", leite.Horario);
                    cmd.Parameters.AddWithValue("@Quantidade", leite.Quantidade);
                    cmd.Parameters.AddWithValue("@Temperatura", leite.Temperatura);
                    cmd.Parameters.AddWithValue("@UsuarioNome", leite.UsuarioNome);
                    cmd.Parameters.AddWithValue("@Id", leite.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Leite leite)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_leite_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", leite.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
