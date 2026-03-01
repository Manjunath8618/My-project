using BookStoreApp.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Data
{
    public class BooksDbContext:IdentityDbContext<ApplicationUser>
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options):base(options)
        {

        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<UserModel> UserTable { get; set; }
    }
}
