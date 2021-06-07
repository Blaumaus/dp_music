using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        private dp_musicContext db;

        public AlbumRepository(dp_musicContext context)
        {
            db = context;
        }

        public void Create(Album album)
        {
            db.Album.Add(album);
        }

        public void Delete(string id)
        {
            var album = db.Album.Find(id);
            if (album != null)
                db.Remove(album);
        }

        public IQueryable<Album> Find(Expression<Func<Album, bool>> predicate)
        {
            return db.Album.AsNoTracking().Where(predicate);
        }

        public Album Get(string id)
        {
            return db.Album.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Album> GetAll()
        {
            return db.Album;
        }

        public void Update(Album album)
        {
            db.Entry(album).State = EntityState.Modified;
        }
    }
}
