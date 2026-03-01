using AutoMapper;
using BookStoreApp.Data;
using BookStoreApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public class UserRepository:IUser
    {
        private readonly BooksDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(BooksDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper =mapper;
        }

        public async Task<UserModel> Createuser(UserModel userModel)
        {
            var record = _mapper.Map<UserModel>(userModel);
            _context.UserTable.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            var record = await _context.UserTable.FindAsync(id);
            if(id==record.UsrID)
            {
                return null;
            }
            _context.UserTable.Remove(record);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserModel>(record);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var records = await _context.UserTable.ToListAsync();
            
                return _mapper.Map<List<UserModel>>(records);
        }

        public async Task<UserModel> GetUserById(int userid)
        {
            var user = await _context.UserTable.FindAsync(userid);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> UpdateUser(int id, UserModel userModel)
        {
            var user = await _context.UserTable.FindAsync(id);
            if(id==user.UsrID)
            {
                _context.UserTable.Update(userModel);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<UserModel>(user);
        }
    }
}
