using BookStoreApp.Data;
using BookStoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookByIdAsync(int bookId);
        Task<BookModel> AddBookAsync(BookModel bookModel);
         Task<Books> UpdateBookById(int id, BookModel bookModel);
      //  Task<Books> UpdateBookById(int bookId, Books books);
        Task<BookModel> DeleteBookAsync(int id);
    }
}
