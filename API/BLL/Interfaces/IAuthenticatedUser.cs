using BLL.Models;

namespace BLL.Interfaces
{
    public interface IAuthenticatedUser
    {
        RestResponse<bool> IsAuthenticatedUser(bool isAuthenticatedUser);
    }
}
