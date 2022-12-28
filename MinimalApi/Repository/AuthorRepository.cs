using Microsoft.EntityFrameworkCore;
using MinimalApi.Contracts;
using MinimalApi.EntityFramework;
using MinimalApi.Model;

namespace MinimalApi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public AuthorRepository()
        {
            using (var context = new ApiContext())
            {
                var authors = new List<Author>
                {
                new Author
                {
                    FirstName ="Joydip",
                    LastName ="Kanjilal",
                    //   Books = new List<Book>()
                    //{
                    //    new Book { Title = "Mastering C# 8.0"},
                    //    new Book { Title = "Entity Framework Tutorial"},
                    //    new Book { Title = "ASP.NET 4.0 Programming"}
                    //}
                },
                new Author
                {
                    FirstName ="Yashavanth",
                    LastName ="Kanetkar",
                    //Books = new List<Book>()
                    //{
                    //    new Book { Title = "Let us C"},
                    //    new Book { Title = "Let us C++"},
                    //    new Book { Title = "Let us C#"}
                    //}
                },
                new Author
                {
                    FirstName ="Vivek",
                    LastName ="Bajpai",
                },
                  new Author
                {
                    FirstName ="Anuj",
                    LastName ="Som",
                }
                };
                context.Authors.AddRange(authors);
                context.SaveChangesAsync();
            }
        }
        public async Task<List<Author>> GetAuthorsAsync()
        {
            using (var context = new ApiContext())
            {
                var list = await context.Authors
                    .Include(a => a.Books)
                    .ToListAsync();
                return list;
            }
        }
    }
}
