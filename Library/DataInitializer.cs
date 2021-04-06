using Library.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
namespace Library
{
    public static class DataInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            if (context.Books.Any())
            {
                return;
            }
            var book1 = new Book { Title = "Капитанская дочка", Author = "А.С. Пушкин", Vendor = 101, PublishDate = 2015, Count = 5 };
            var book2 = new Book { Title = "Отцы и дети", Author = "И.С. Тургенев", Vendor = 102, PublishDate = 2000, Count = 3 };
            var book3 = new Book { Title = "Идиот", Author = "Ф.М. Достоевский", Vendor = 103, PublishDate = 1995, Count = 10 };
            context.Books.AddRange(book1, book2, book3);
            context.SaveChanges();

            var reader1 = new Reader { Name = "И.И. Иванов", BirthDate = new DateTime(2015, 10, 14) };
            var reader2 = new Reader { Name = "П.П. Петров", BirthDate = new DateTime(2020, 6, 20) };
            var reader3 = new Reader { Name = "С.С. Сидоров", BirthDate = new DateTime(1999, 4, 5) };

            context.Readers.AddRange(reader1, reader2, reader3);
            context.SaveChanges();

            var Copies = new Copy[]{
                new Copy { BookId = 1, ReaderId = 1, Issue_Date = DateTime.Now },
                new Copy { BookId = 1, ReaderId = 2, Issue_Date = DateTime.Now },
                new Copy { BookId = 1, ReaderId = 3, Issue_Date = DateTime.Now },
                new Copy { BookId = 2, ReaderId = 3, Issue_Date = DateTime.Now },
            };
            
            context.Copies.AddRange(Copies);
            context.SaveChanges();
        }
    }
}
