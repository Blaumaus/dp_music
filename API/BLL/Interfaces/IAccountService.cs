using BLL.DTO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task Register(UserRegistrationDto user);
    }
}
