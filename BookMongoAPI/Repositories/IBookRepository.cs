using System.Collections.Generic;
using BookMongoAPI.Models;

namespace BookMongoAPI.Repositories
{
    public interface IBookRepository
    {
        List<Book> Get();
        Book Get(string id);
        Book Create(Book book);
        void Update(string id, Book bookToUpdate);
        void Remove(Book bookToRemove);
        void Remove(string id);
    }
}