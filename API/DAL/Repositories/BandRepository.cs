using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class BandRepository : IRepository<Band>
    {
        private dp_musicContext db;

        public BandRepository(dp_musicContext context)
        {
            db = context;
        }

        public void Create(Band band)
        {
            db.Band.Add(band);
        }

        public void Delete(string id)
        {
            var band = db.Band.Find(id);
            if (band != null)
                db.Remove(band);
        }

        public IQueryable<Band> Find(Expression<Func<Band, bool>> predicate)
        {
            return db.Band.AsNoTracking().Where(predicate);
        }

        public Band Get(string id)
        {
            return db.Band.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Band> GetAll()
        {
            return db.Band;
        }

        public void Update(Band band)
        {
            db.Entry(band).State = EntityState.Modified;
        }
    }
}
