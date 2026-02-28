using BookStoreApp.Migrations;
using BookStoreApp.Model;
using BookStoreApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllUser()
        {
            var records = await _user.GetAllUsers();
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var record = await _user.GetUserById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromBody] UserModel userModel)
        {
            var records = await _user.Createuser(userModel);
            if(records==null)
            {
                return NotFound();
            }

            return Accepted(records);
                    
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserModel userModel)
        {
            var records = await _user.UpdateUser(id,userModel);
            return Ok(records);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var record = await _user.DeleteUser(id);
            if(record==null)
            {
                return NotFound();
            }
            return Ok(record);
        }
    }
}
