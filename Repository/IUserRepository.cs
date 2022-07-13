using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTfullAPI.Repository
{
    public interface IUserRepository
    {
        Task<int> AdduserAsync(RequestUserModel requestUser);
        Task DeleteUser(int id);
        Task<List<RequestUserModel>> GetAllUsers();
        Task<RequestUserModel> GeyUserById(int id);
        Task<RequestUserModel> UpdateUser(int id, RequestUserModel requestUser);
    }
}