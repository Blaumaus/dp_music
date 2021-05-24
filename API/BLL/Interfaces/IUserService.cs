using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetCurrentUser(string id);
    }
}
