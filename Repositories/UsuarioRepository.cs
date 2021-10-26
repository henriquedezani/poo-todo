using System;
using System.Data.SqlClient;
using TodoList.Models;

namespace TodoList.Repositories
{
    public class UsuarioRepository : BDContext, IUsuarioRepository
    {
        public void Create(Usuario model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Read(string email, string senha)
        {
            Usuario usuario = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Usuario WHERE Email = @email AND Senha = @senha";

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read()) 
            {
                usuario = new Usuario();
                usuario.Id = reader["Id"] as int?;
                usuario.Nome = (string)reader["Nome"];
                usuario.Email = (string)reader["Email"];
                usuario.Senha = reader["Senha"] as string;
            }

            return usuario;
        }

        public void Update(int id, Usuario model)
        {
            throw new System.NotImplementedException();
        }
    }
}