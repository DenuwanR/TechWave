using AutoMapper;
using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Repository.ApplicationUsers
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly ECOM_WebContext _dbContext = new ECOM_WebContext();
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserRepository"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public ApplicationUserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="userObject">The user object.</param>
        /// <returns></returns>
        public ApplicationUser AddUser(ApplicationUser userObject)
        {
            try
            {
                if(userObject.UserType == 2)
                {
                    userObject.SupplierId = GenerateId();
                }

                var MappedObject = _mapper.Map<TblUserRegistration>(userObject);

                _dbContext.TblUserRegistrations.Add(MappedObject);
                var result = _dbContext.SaveChanges();

                userObject.UserId = MappedObject.UserId;
                if (result > 0) return userObject;

                return new ApplicationUser();
            }
            catch (Exception eX)
            {
                return new ApplicationUser(); ;
            }
        }

        /// <summary>
        /// Authentications the user.
        /// </summary>
        /// <param name="userObject">The user object.</param>
        /// <returns></returns>
        public ApplicationUser AuthUser(ApplicationUser userObject)
        {
            try
            {
                var result = new TblUserRegistration();
                if (userObject == null || userObject.Password == null)
                {
                    return new ApplicationUser();
                }

                result = _dbContext.TblUserRegistrations.Select(data => data).
                Where(data => data.Email.ToLower().Equals(userObject.Email.ToLower()) &&
                data.Password.Equals(userObject.Password)).FirstOrDefault();

                var mappedobject = _mapper.Map<ApplicationUser>(result);
                if (mappedobject != null) return mappedobject;
                return new ApplicationUser();
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
                var appointment = _dbContext.TblUserRegistrations.ToList();
                var mappedUsers = _mapper.Map<List<ApplicationUser>>(appointment);
                return mappedUsers;
            }
            catch (Exception eX)
            {
                return new List<ApplicationUser>();
            }
        }

        private static Random random = new Random();

        public static long GenerateId()
        {
            byte[] buffer = new byte[8];
            random.NextBytes(buffer);
            long id = BitConverter.ToInt64(buffer, 0);
            return Math.Abs(id);
        }

    }
}
