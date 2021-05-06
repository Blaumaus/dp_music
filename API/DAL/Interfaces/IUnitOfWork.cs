using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        IRepository<Album> Album { get; }
        IRepository<Band> Band { get; }
        IRepository<Bandgenre> Bandgenre { get; }
        IRepository<Composition> Composition { get; }
        IRepository<Genre> Genre { get; }
        IRepository<Reflection> Reflection { get; }
        IRepository<Selected> Selected { get; }
        IRepository<User> User { get; }
    }
}
