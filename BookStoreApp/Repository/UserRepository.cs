using AutoMapper;
using BookStoreApp.Data;
using BookStoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public class UserRepository : IUser
    {
        private readonly BooksDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(BooksDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserModel> Createuser(UserModel userModel)
        {
            var record = _mapper.Map<UserModel>(userModel);
            _context.User.Add(userModel);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            var record = await _context.User.FindAsync(id);
            if(id==record.UsrID)
            {
                return null;
            }
            _context.User.Remove(record);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserModel>(record);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var records = await _context.User.FindAsync();
            return _mapper.Map<List<UserModel>>(records);
        }

        public async Task<UserModel> GetUserById(int userid)
        {
            var record = await _context.User.FindAsync(userid);
            return _mapper.Map<UserModel>(record);
        }

        public async Task<UserModel> UpdateUser(int id, UserModel userModel)
        {
            var record = await _context.User.FindAsync(id);
            if(id==record.UsrID)
            {
                _context.User.Update(userModel);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<UserModel>(record);
        }
    }
}
