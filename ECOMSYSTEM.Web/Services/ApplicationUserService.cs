using ECOMSYSTEM.Repository.ApplicationUsers;
using ECOMSYSTEM.Shared;
using ECOMSYSTEM.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ECOMSYSTEM.Web.Services
{
    public class ApplicationUserService : IApplicatioUser
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserService(IApplicationUserRepository userRepository)
        {
            _applicationUserRepository = userRepository;
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="userObject">The user object.</param>
        /// <returns></returns>
        public ApplicationUser RegisterUser(ApplicationUser userObject)
        {
            try
            {
                var result = _applicationUserRepository.AddUser(userObject);
                return result;
            }
            catch (Exception eX)
            {
                return new ApplicationUser();
            }
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="userObject">The user object.</param>
        /// <returns></returns>
        public ApplicationUser LoginUser(ApplicationUser userObject)
        {
            try
            {
                var result = _applicationUserRepository.AuthUser(userObject);
                return result;
            }
            catch (Exception)
            {
                return new ApplicationUser();
            }
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public List<ApplicationUser> GetAllUsers()
        {
            try
            {
                var result = _applicationUserRepository.GetAllUsers();
                return result;
            }
            catch (Exception)
            {
                return new List<ApplicationUser>();
            }
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public List<ApplicationUser> GetAllProducts()
        {
            try
            {
                var result = _applicationUserRepository.GetAllUsers();
                return result;
            }
            catch (Exception)
            {
                return new List<ApplicationUser>();
            }
        }
    }
}
