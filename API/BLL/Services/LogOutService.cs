using Microsoft.AspNetCore.Http;
using BLL.Interfaces;

namespace BLL.Services
{
    public class LogOutService : ILogOutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LogOutService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void LogOut()
        {
            var cookieHelper = new CookieHelper(_httpContextAccessor);
            cookieHelper.RemoveCookie("jwtToken");
        }
    }
}
