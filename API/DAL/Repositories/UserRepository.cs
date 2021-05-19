using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    class UserRepository : IRepository<User>
    {
        private dp_musicContext db;

        public UserRepository(dp_musicContext context)
        {
            db = context;
        }
        public void Create(User user)
        {
            try
            {
                db.User.Add(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string id)
        {
            var user = db.User.Find(id);
            if (user != null)
            {
                db.Remove(user);
            }
        }

        public IQueryable<User> Find(Expression<Func<User, bool>> predicate)
        {
            try
            {
                return db.User.AsNoTracking().Where(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Get(string id)
        {
            return db.User.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.User;
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
    }
}
