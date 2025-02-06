using ECOMSYSTEM.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IApplicationUser
{
    /// <summary>
    /// Registers the user.
    /// </summary>
    /// <param name="userObject">The user object.</param>
    /// <returns></returns>
    Task<ApplicationUser> Register(ApplicationUser userObject);

    /// <summary>
    /// Logins the user.
    /// </summary>
    /// <param name="userObject">The user object.</param>
    /// <returns></returns>
    Task<ApplicationUser> Login(ApplicationUser userObject);

    /// <summary>
    /// Gets all users.
    /// </summary>
    /// <returns></returns>
    Task<List<ApplicationUser>> GetAllUsers();
}
