using DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private dp_musicContext db;
        private GenreRepository genreRepository;

        public UnitOfWork(dp_musicContext context)
        {
            db = context;
            genreRepository = new GenreRepository(db);
        }

        public IRepository<Album> Album => throw new NotImplementedException();

        public IRepository<Band> Band => throw new NotImplementedException();

        public IRepository<Bandgenre> Bandgenre => throw new NotImplementedException();

        public IRepository<Composition> Composition => throw new NotImplementedException();

        public IRepository<Genre> Genre
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }

        public IRepository<Reflection> Reflection => throw new NotImplementedException();

        public IRepository<Selected> Selected => throw new NotImplementedException();

        public IRepository<User> User => throw new NotImplementedException();

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        #region Dispose Support

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
