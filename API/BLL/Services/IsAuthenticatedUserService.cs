using BLL.Interfaces;
using BLL.Models;

namespace BLL.Services
{
    public class IsAuthenticatedUserService : IAuthenticatedUser
    {
        
        public RestResponse<bool> IsAuthenticatedUser(bool isAuthenticatedUser)
        {
            if (isAuthenticatedUser)
                return RestResponse<bool>.Success(isAuthenticatedUser);
            else
                return RestResponse<bool>.Unauthorized();
        }
    }
}
