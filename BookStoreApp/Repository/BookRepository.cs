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
    public class BookRepository: IBookRepository
    {
        private readonly BooksDbContext _context;

        private readonly IMapper _mapper;

        public BookRepository(BooksDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public async Task<List<BookModel>> GetAllBooks()
        //{
        //    var books = await _context.Books.Select(x => new BookModel()
        //    {
        //        Id = x.Id,
        //        BookName = x.BookName,
        //        Description = x.Description
        //    }).ToListAsync();
        //    return books;
        //}

        //using Automapper
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books =await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }

        //public async Task<BookModel> GetBookByIdAsync(int bookId)
        //{
        //    var book = await _context.Books.Where(x => x.Id == bookId).
        //        Select(x => new BookModel()
        //        {
        //            Id = x.Id,
        //            BookName = x.BookName,
        //            Description = x.Description
        //        }).FirstOrDefaultAsync();
        //    return book;
        //}

        //using Automapper
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }

        //public async Task<BookModel> AddBookAsync(BookModel bookModel)
        //{
        //    var book = new BookModel()
        //    {
        //        BookName = bookModel.BookName,
        //        Description = bookModel.Description
        //    };
        //    _context.Books.Add(book);
        //    await _context.SaveChangesAsync();

        //    return book;
        //}
        public async Task<BookModel> AddBookAsync(BookModel bookModel)
        {
            var book= _mapper.Map<BookModel>(bookModel);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Books> UpdateBookById(int id, BookModel bookModel)
        {
             var book= await _context.Books.FindAsync(id);
            // var book1= _mapper.Map<Books>(book);
            if(id==book.Id)
            {
                _context.Books.Update(book);
                await _context.SaveChangesAsync();

            }
            //await _context.SaveChangesAsync();
            return _mapper.Map<Books>(book);

        }

        //public async Task<BookModel> UpdateBookById(int bookId, BookModel bookModel)
        //{

        //    var book = new BookModel()
        //    {
        //        Id = bookId,
        //        BookName = bookModel.BookName,
        //        Description = bookModel.Description
        //    };

        //    _context.Books.Update(book);
        //    await _context.SaveChangesAsync();
        //    return book;
        //}

        //public async Task<Books> UpdateBookById(int bookId, Books books)
        //{
        //    var entity =await this._context.Books.FindAsync(bookId);

        //            _mapper.Map(books, entity);
        //    // _context.Books.FindAsync(bookId);


        //    var book = this._context.Books.Update(entity);
        //    await this._context.SaveChangesAsync();

        //    return books;

        //var book = await _context.Books.FindAsync(bookId);
        //if(book !=null)
        //{
        //    book.BookName = bookModel.BookName;
        //    book.Description = bookModel.Description;
        //};
        //  await _context.SaveChangesAsync();


  //  }
        public async Task<BookModel> DeleteBookAsync(int id)
        {
            
            var book = await _context.Books.FindAsync(id);
            if(id==book.Id)
            {
                return null;
            }
             _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookModel>(book);
        }
           
    }
}
