using System;
using System.Collections.Generic;
using TodoList.Models;
using System.Data.SqlClient;
using System.Data;

namespace TodoList.Repositories
{
    public class TarefaRepository : BDContext, ITarefaRepository
    {
        public void Create(Tarefa model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                // cmd.CommandText = "EXEC CREATE_TAREFA @texto, @idUsuario";

                cmd.CommandText = "CREATE_TAREFA";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@texto", model.Texto);
                cmd.Parameters.AddWithValue("@idusuario", 2);

                cmd.ExecuteNonQuery();

            }catch(Exception ex) {
                // Armazenar a exceção em um log.
                Console.WriteLine(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public void Delete(int id)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "DELETE FROM Tarefa WHERE Id = @id";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }catch(Exception ex) {
                // Armazenar a exceção em um log.
            }
            finally {
                Dispose();
            }
        }

        public void Update(int id, Tarefa model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "UPDATE Tarefa SET Texto = @texto, Concluida = @concluida WHERE Id = @id";

                cmd.Parameters.AddWithValue("@texto", model.Texto);
                cmd.Parameters.AddWithValue("@concluida", model.Concluida);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }catch(Exception ex) {
                // Armazenar a exceção em um log.
            }
            finally {
                Dispose();
            }
        }

        public List<Tarefa> ReadAll(int id)
        {
            try {
                List<Tarefa> lista = new List<Tarefa>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT Id, Texto, Concluida, Nome, UsuarioId FROM ViewTarefa WHERE UsuarioId = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Tarefa tarefa = new Tarefa();
                    tarefa.Id = reader.GetInt32(0);
                    tarefa.Texto = reader.GetString(1);
                    tarefa.Concluida = reader.GetBoolean(2);
                    tarefa.Usuario = new Usuario {
                        Nome = reader.GetString(3)
                    };

                    lista.Add(tarefa);
                }

                return lista;
            }catch(Exception ex) {
                // Armazenar a exceção em um log.
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public Tarefa Read(int id)
        {
            try 
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT Id, Texto, Concluida FROM Tarefa WHERE Id = @id";

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if(reader.Read()) 
                {
                    Tarefa tarefa = new Tarefa();
                    tarefa.Id = reader.GetInt32(0);
                    tarefa.Texto = reader.GetString(1);
                    tarefa.Concluida = reader.GetBoolean(2);

                    return tarefa;
                }

                return null;
                
            }
            catch(Exception ex) 
            {
                throw new Exception("Tarefa não encontrada.");
            }
            finally {
                Dispose();
            }
        }       
    }
}