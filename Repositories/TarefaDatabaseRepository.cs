using System;
using System.Collections.Generic;
using TodoList.Models;
using System.Data.SqlClient;

namespace TodoList.Repositories
{
    public class TarefaDatabaseRepository : BDContext, ITarefaRepository
    {
        public void Create(Tarefa model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "INSERT INTO Tarefa VALUES (@texto, @concluida)";

            cmd.Parameters.AddWithValue("@texto", model.Texto);
            cmd.Parameters.AddWithValue("@concluida", model.Concluida);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "DELETE FROM Tarefa WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public void Update(int id, Tarefa model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "UPDATE Tarefa SET Texto = @texto, Concluida = @concluida WHERE Id = @id";

            cmd.Parameters.AddWithValue("@texto", model.Texto);
            cmd.Parameters.AddWithValue("@concluida", model.Concluida);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public List<Tarefa> Read()
        {
            List<Tarefa> lista = new List<Tarefa>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT Id, Texto, Concluida FROM Tarefa";

            SqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read()) 
            {
                Tarefa tarefa = new Tarefa();
                tarefa.Id = reader.GetInt32(0);
                tarefa.Texto = reader.GetString(1);
                tarefa.Concluida = reader.GetBoolean(2);

                lista.Add(tarefa);
            }

            return lista;
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
        }       
    }
}