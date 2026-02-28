using BookStoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public interface IUser
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int userid);
        Task<UserModel> Createuser(UserModel userModel);
        Task<UserModel> UpdateUser(int id,UserModel userModel);
        Task<UserModel> DeleteUser(int id);

    }
}
