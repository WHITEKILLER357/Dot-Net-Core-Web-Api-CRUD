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

        public async Task<RequestUserModel> GeyUserById(int id)
        {
            var recods = await _userDbContext.users.FindAsync(id);

            return new RequestUserModel() { 
            user_id = recods.user_id,
            name = recods.name,
            email = recods.email,
            phone =recods.phone,
            Gender = recods.Gender,
            address = recods.address
            };

            
        }


        public async Task<RequestUserModel> UpdateUser(int id,RequestUserModel requestUser)
        {
            var records = await _userDbContext.users.FindAsync(id);
            if (records != null)
            {
                records.name = requestUser.name;
                records.email = requestUser.email;
                records.phone = requestUser.phone;
                records.Gender = requestUser.Gender;
                records.address = requestUser.address;

                await _userDbContext.SaveChangesAsync();

                              
            }
            var responseData = new RequestUserModel()
            {
                user_id = records.user_id,
                name = records.name,
                email = records.email,
                phone = records.phone,
                Gender = records.Gender,
                address = records.address
            };

            return responseData;
        }
              

        public async Task DeleteUser(int id)
        {
            var record = new UserModel() { user_id = id};
            
                _userDbContext.users.Remove(record);
                await _userDbContext.SaveChangesAsync();
            
        }

    }
}
