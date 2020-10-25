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
    public class SonoRepository : ISonoRepository
    {
        public IList<Sono> List(Sono sono)
        {
            var sonos = new List<Sono>();
            Sono sonoAux;

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_sono_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgendaId", sono.AgendaId);
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            sonoAux = new Sono
                            {
                                AgendaId = Convert.ToInt32(dr["AgendaId"].ToString()),
                            };

                            sonos.Add(sono);
                        }
                    }
                }
            }

            return sonos;
        }

        public void Add(Sono sono)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_sono_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgendaId", sono.AgendaId);
                    cmd.Parameters.AddWithValue("@Status", sono.Status);
                    cmd.Parameters.AddWithValue("@UsuarioNome", sono.UsuarioNome);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Sono sono)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_sono_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgendaId", sono.AgendaId);
                    cmd.Parameters.AddWithValue("@Status", sono.Status);
                    cmd.Parameters.AddWithValue("@UsuarioNome", sono.UsuarioNome);
                    cmd.Parameters.AddWithValue("@Id", sono.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Sono sono)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_sono_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", sono.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
