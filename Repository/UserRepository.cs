using Microsoft.EntityFrameworkCore;
using RESTfullAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfullAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;

        public  UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }


            public async Task<int> AdduserAsync(RequestUserModel requestUser)
            {
                

            //map above model to UserModel

            var userData = new UserModel
            {
                user_id = requestUser.user_id,
                name = requestUser.name,
                email = requestUser.email,
                phone = requestUser.phone,
                Gender = requestUser.Gender,
                address = requestUser.address
            };


            _userDbContext.users.Add(userData);
                 await _userDbContext.SaveChangesAsync();
                 return userData.user_id;
                        
            }


        public async Task<List<RequestUserModel>> GetAllUsers()
        {
            var records = await _userDbContext.users.Select(n => new RequestUserModel()
            {
                user_id = n.user_id,
                name = n.name,
                email = n.email,
                phone = n.phone,
                Gender = n.Gender,
                address = n.address
            }).ToListAsync();

            return records;

        }

    }
}
