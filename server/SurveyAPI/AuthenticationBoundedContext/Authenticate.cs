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

        public User GetUserAndRole(string emailId)
        {
            return authorisationRepository.GetUserAndRole(emailId);
        }

        public bool IsUserValid(User user)
        {
            var userInfo = authorisationRepository.GetUserAndRole(user.emailID);

            if(user.role == userInfo.role && user.pwd == userInfo.pwd)
            {
                return true;
            }

            return false;
        }
    }
}
