using DAL.EfStructures;
using DAL.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class CommentsRepository : ICommentsRepo
    {
        public ApplicationDbContext Context { get; }
        private readonly bool _disposeContext;
        private bool _isDisposed;
        public DbSet<Comment> Table { get; }
        public CommentsRepository(ApplicationDbContext context)
        {
            Context = context;
            Table = context.Comments;
        }
        internal CommentsRepository(DbContextOptions<ApplicationDbContext> dbContextOptions) 
            : this(new ApplicationDbContext(dbContextOptions))
        {
            _disposeContext = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            else if (disposing)
            {
                if (_disposeContext)
                {
                    Context.Dispose();
                }
            }
            _isDisposed = true;
        }
        public int Add(Comment entity, bool presist = true)
        {
            Table.Add(entity);
            return presist ? SaveChanges() : 0;
        }

        public int Delete(Comment entity, bool presist = true)
        {
            Table.Remove(entity);
            return presist ? SaveChanges() : 0;
        }

        public void ExecuteQuery(string sql, object[] sqlParamtersObject)
        {
            Context.Database.ExecuteSqlRaw(sql, sqlParamtersObject);
        }
        public IEnumerable<Comment> GetAll() => Table;

        public int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Comment entity, bool presist = true)
        {
            Table.Update(entity);
            return presist ? SaveChanges() : 0;
        }

        public Comment Find(int? id) => Table.Find(id);
    }
}
