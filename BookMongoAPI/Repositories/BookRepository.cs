using System.Collections.Generic;
using BookMongoAPI.Models;
using MongoDB.Driver;

namespace BookMongoAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BookRepository(IMongoDatabase mongoDatabase)
        {
            _books = mongoDatabase.GetCollection<Book>("Books");
        }

        public List<Book> Get() =>
            _books.Find(book => true).ToList();

        public Book Get(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookToUpdate) =>
            _books.ReplaceOne(book => book.Id == id, bookToUpdate);

        public void Remove(Book bookToRemove) =>
            _books.DeleteOne(book => book.Id == bookToRemove.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}
