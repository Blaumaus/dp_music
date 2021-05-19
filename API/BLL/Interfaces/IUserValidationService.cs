using BLL.Models;

namespace BLL.Interfaces
{
    public interface IUserValidationService
    {
        RestResponse<bool> ValidateUserName(string userName);
        RestResponse<bool> ValidateEmail(string email);
    }
}
