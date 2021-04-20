using DAL.EfStructures;
using DAL.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public interface ICommentsRepo
    {
        int Add(Comment entity, bool presist = true);
        int Update(Comment entity, bool presist = true);
        int Delete(Comment entity, bool presist = true);
        Comment Find(int? id);
        IEnumerable<Comment> GetAll();
        void ExecuteQuery(string sql, object[] sqlParamtersObject);
        int SaveChanges();
    }
}
