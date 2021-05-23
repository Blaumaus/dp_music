using BLL.Models;
using BLL.DTO;



namespace BLL.Interfaces
{
    public interface ILogInService
    {
        RestResponse<bool> LogIn(LogInDto logInDto);
    }
}
