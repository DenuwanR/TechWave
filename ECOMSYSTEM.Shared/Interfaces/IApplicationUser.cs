using ECOMSYSTEM.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared.Interfaces
{
    public interface IApplicationUser
    {
        Task<ApplicationUser> AddUser(ApplicationUser userObject);
        Task<ApplicationUser> AuthUser(ApplicationUser userObject);
        Task<List<ApplicationUser>> GetAllUsers();
    }
}
