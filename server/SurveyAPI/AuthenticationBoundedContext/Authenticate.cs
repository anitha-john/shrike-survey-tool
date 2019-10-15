using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using RepositoryFactory;

namespace AuthenticationBoundedContext
{
    public class Authenticate : IAuthenticate
    {
        public IAuthorisationRepository authorisationRepository { get; set; }
        public Authenticate(IAuthorisationRepository _authorisationRepository)
        {
            authorisationRepository = _authorisationRepository;
        }
        public async Task<string> AddUserAndRole(User _userInfo)
        {
            return await authorisationRepository.AddUserAndRole(_userInfo);
        }

        public async Task<User> GetUserAndRole(string emailId)
        {
            return await authorisationRepository.GetUserAndRole(emailId);
        }

        public bool IsUserValid(User user)
        {
            var userInfo = authorisationRepository.GetUserAndRole(user.emailID).Result;

            if(user.firstName == userInfo.firstName && user.role == userInfo.role && user.pwd == userInfo.pwd)
            {
                return true;
            }

            return false;
        }
    }
}
