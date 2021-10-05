using System;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Repositories
{
    // "Contrato" ("Abstrato")
    public interface IUsuarioRepository
    {
        void Create(Usuario model);        
        Usuario Read(string email, string senha);
        void Update(int id, Usuario model);
        void Delete(int id);
    }
}