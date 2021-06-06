using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class CompositionRepository : IRepository<Composition>
    {
        private dp_musicContext db;

        public CompositionRepository(dp_musicContext context)
        {
            db = context;
        }

        public void Create(Composition composition)
        {
            db.Composition.Add(composition);
        }

        public void Delete(string id)
        {
            var composition = db.Composition.Find(id);
            if (composition != null)
                db.Remove(composition);
        }

        public IQueryable<Composition> Find(Expression<Func<Composition, bool>> predicate)
        {
            return db.Composition.AsNoTracking().Where(predicate);
        }

        public Composition Get(string id)
        {
            return db.Composition.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Composition> GetAll()
        {
            return db.Composition;
        }

        public void Update(Composition composition)
        {
            db.Entry(composition).State = EntityState.Modified;
        }
    }
}
