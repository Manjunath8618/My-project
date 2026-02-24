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
        Task<UserModel> Createuser();
        Task<UserModel> UpdateModel();
        Task<UserModel> DeleteUser();

    }
}
