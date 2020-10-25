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
    public class AlunoRepository : IAlunoRepository
    {
        public IList<Aluno> List(Aluno aluno)
        {
            var alunos = new List<Aluno>();
            Aluno alunoAux;

            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_aluno_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EscolaId", aluno.EscolaId);
                    cmd.Parameters.AddWithValue("@UsuarioId", aluno.UsuarioId);
                    conn.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            alunoAux = new Aluno
                            {
                                Nome = dr["Nome"].ToString(),
                                EscolaId = Convert.ToInt32(dr["EscolaId"].ToString()),
                                GrupoId = Convert.ToInt32(dr["GrupoId"].ToString())
                            };

                            alunos.Add(aluno);
                        }
                    }
                }
            }

            return alunos;
        }

        public void Add(Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_aluno_add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EscolaId", aluno.EscolaId);
                    cmd.Parameters.AddWithValue("@GrupoId", aluno.GrupoId);
                    cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@UsuarioNome", aluno.UsuarioNome);
                    conn.Open();
                    cmd.ExecuteNonQuery();                    
                }
            }
        }

        public void Update(Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_aluno_update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EscolaId", aluno.EscolaId);
                    cmd.Parameters.AddWithValue("@GrupoId", aluno.GrupoId);
                    cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@UsuarioNome", aluno.UsuarioNome);
                    cmd.Parameters.AddWithValue("@Id", aluno.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_aluno_delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", aluno.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
