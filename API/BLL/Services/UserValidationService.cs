using BLL.Interfaces;
using System.Linq;
using BLL.Models;
using DAL.Repositories;
using DAL;

namespace BLL.Services
{
    public class UserValidationService : IUserValidationService
    {
        private readonly UnitOfWork unitOfWork;
        const int conflictStatusCode = 409;
        public UserValidationService(dp_musicContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }
        public RestResponse<bool> ValidateUserName(string userName)
        {
            bool isValid = !unitOfWork.User.Find(u => u.Login == userName).Any();
            if (isValid)
                return RestResponse<bool>.Success(isValid);
            else
                return RestResponse<bool>.Fail(conflictStatusCode, "Username is not valid");
        }
        public RestResponse<bool> ValidateEmail(string email)
        {
            bool isValid = !unitOfWork.User.Find(u => u.Email == email).Any();
            if (isValid)
                return RestResponse<bool>.Success(isValid);
            else
                return RestResponse<bool>.Fail(conflictStatusCode, "Email is not valid");
        }
    }
}
