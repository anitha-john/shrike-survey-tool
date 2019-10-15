using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBoundedContext
{
    public interface IAuthenticate
    {
        Task<string> AddUserAndRole(User _userInfo);
        Task<User> GetUserAndRole(string emailId);
        bool IsUserValid(User user);
    }
}
