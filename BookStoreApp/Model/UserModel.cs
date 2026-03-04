using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Model
{
    public class UserModel
    {
        [Key]
        public int UsrID { get; set; }
        public string userName { get; set; }
    }
}
