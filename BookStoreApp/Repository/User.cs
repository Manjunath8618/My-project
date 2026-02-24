using AutoMapper;
using BookStoreApp.Data;
using BookStoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public class User : IUser
    {
        private readonly BooksDbContext _context;
        private readonly IMapper _mapper;

        public User(BooksDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<UserModel> Createuser(UserModel userModel)
        {
            var user = _mapper.Map<UserModel>(userModel);
            _context.BookUser.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            var user = await _context.BookUser.FindAsync(id);
           if(id==user.UserID)
            {
                return null;
            }
            _context.BookUser.Remove(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserModel>(user);

        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _context.BookUser.FindAsync();
            return _mapper.Map<List<UserModel>>(users);
        }
        public async Task<UserModel> GetUserById(int userId)
        {
            var book = await _context.BookUser.FindAsync();

            return _mapper.Map<UserModel>(book);
        }
        public async Task<UserModel> UpdateUser(int id, UserModel userModel)
        {
            var user = await _context.BookUser.FindAsync(id);
            if(id==userModel.UserID)
            {
                _context.BookUser.Update(user);
                await _context.SaveChangesAsync();
            }

            return user;
        }
    }
}
