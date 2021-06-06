using DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private dp_musicContext db;
        private GenreRepository genreRepository;
        private UserRepository userRepository;
        private BandRepository bandRepository;
        private BandgenreRepository bandgenreRepository;
        private AlbumRepository albumRepository;
        private CompositionRepository compositionRepository;

        public UnitOfWork(dp_musicContext context)
        {
            db = context;
            userRepository = new UserRepository(db);
            genreRepository = new GenreRepository(db);
            bandRepository = new BandRepository(db);
            bandgenreRepository = new BandgenreRepository(db);
            albumRepository = new AlbumRepository(db);
            compositionRepository = new CompositionRepository(db);
        }

        public IRepository<Album> Album
        {
            get
            {
                if (albumRepository == null)
                    albumRepository = new AlbumRepository(db);
                return albumRepository;
            }
        }

        public IRepository<Band> Band
        {
            get
            {
                if (bandRepository == null)
                    bandRepository = new BandRepository(db);
                return bandRepository;
            }
        }

        public IRepository<Bandgenre> Bandgenre
        {
            get
            {
                if (bandgenreRepository == null)
                    bandgenreRepository = new BandgenreRepository(db);
                return bandgenreRepository;
            }
        }

        public IRepository<Composition> Composition
        {
            get
            {
                if (compositionRepository == null)
                    compositionRepository = new CompositionRepository(db);
                return compositionRepository;
            }
        }

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

        public IRepository<User> User
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

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
