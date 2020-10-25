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
    public class MedicamentoRepository : IMedicamentoRepository
    {
        public IList<Medicamento> List(Medicamento medicamento)
        {
            var medicamentos = new List<Medicamento>();
            Medicamento medicamentoAux;

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_medicamento_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EscolaId", medicamento.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioId", medicamento.UsuarioId);
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            medicamentoAux = new Medicamento
                            {
                                Remedio = dr["Remedio"].ToString(),
                                De = Convert.ToDateTime(dr["De"].ToString()),
                                Ate = Convert.ToDateTime(dr["Ate"].ToString())
                            };

                            medicamentos.Add(medicamento);
                        }
                    }
                }
            }

            return medicamentos;
        }

        public void Add(Medicamento medicamento)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_medicamento_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Remedio", medicamento.Remedio);
                    cmd.Parameters.AddWithValue("@Dose", medicamento.Dose);
                    cmd.Parameters.AddWithValue("@Horario", medicamento.Horario);
                    cmd.Parameters.AddWithValue("@De", medicamento.De);
                    cmd.Parameters.AddWithValue("@Ate", medicamento.Ate);
                    cmd.Parameters.AddWithValue("@AlunoId", medicamento.AlunoId);
                    cmd.Parameters.AddWithValue("@EscolaId", medicamento.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioNome", medicamento.UsuarioNome);
                    conn.Open();
                    cmd.ExecuteNonQuery();                    
                }
            }
        }

        public void Update(Medicamento medicamento)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_medicamento_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Remedio", medicamento.Remedio);
                    cmd.Parameters.AddWithValue("@Dose", medicamento.Dose);
                    cmd.Parameters.AddWithValue("@Horario", medicamento.Horario);
                    cmd.Parameters.AddWithValue("@De", medicamento.De);
                    cmd.Parameters.AddWithValue("@Ate", medicamento.Ate);
                    cmd.Parameters.AddWithValue("@AlunoId", medicamento.AlunoId);
                    cmd.Parameters.AddWithValue("@EscolaId", medicamento.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioNome", medicamento.UsuarioNome);
                    cmd.Parameters.AddWithValue("@Id", medicamento.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Medicamento medicamento)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_medicamento_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", medicamento.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
