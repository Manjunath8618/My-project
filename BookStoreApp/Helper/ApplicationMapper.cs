using AutoMapper;
using BookStoreApp.Data;
using BookStoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
          //  CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
