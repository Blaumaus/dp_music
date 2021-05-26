using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class BandgenreRepository : IRepository<Bandgenre>
    {
        private dp_musicContext db;

        public BandgenreRepository(dp_musicContext context)
        {
            db = context;
        }

        public void Create(Bandgenre bandgenre)
        {
            db.Bandgenre.Add(bandgenre);
        }

        public void Delete(string id)
        {
            var bandgenre = db.Bandgenre.Find(id);
            if (bandgenre != null)
                db.Bandgenre.Remove(bandgenre);
        }

        public IQueryable<Bandgenre> Find(Expression<Func<Bandgenre, bool>> predicate)
        {
            return db.Bandgenre.AsNoTracking().Where(predicate);
        }

        public Bandgenre Get(string id)
        {
            return db.Bandgenre.FirstOrDefault(e => e.GenreId == id);
        }

        public IEnumerable<Bandgenre> GetAll()
        {
            return db.Bandgenre;
        }

        public void Update(Bandgenre bandgenre)
        {
            throw new NotImplementedException();
        }
    }
}
