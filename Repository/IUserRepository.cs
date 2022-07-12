using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTfullAPI.Repository
{
    public interface IUserRepository
    {
        Task<int> AdduserAsync(RequestUserModel requestUser);
        Task<List<RequestUserModel>> GetAllUsers();
    }
}