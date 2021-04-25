using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private dp_musicContext db;

        public GenreRepository(dp_musicContext context)
        {
            db = context;
        }

        public void Create(Genre genre)
        {
            db.Genre.Add(genre);
        }

        public void Delete(string id)
        {
            var genre = db.Genre.Find(id);
            if (genre != null)
                db.Remove(genre);
        }

        public IQueryable<Genre> Find(Expression<Func<Genre, bool>> predicate)
        {
            return db.Genre.AsNoTracking().Where(predicate);
        }

        public Genre Get(string id)
        {
            //return db.Genre.Find(id);
            return db.Genre.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genre;
        }

        public void Update(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
        }
    }
}
