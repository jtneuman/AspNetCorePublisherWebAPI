using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublisherWebAPI.Entities;
using PublisherWebAPI.Models;
using AutoMapper;

namespace PublisherWebAPI.Services
{
    public class BookstoreSqlRepository : IBookstoreRepository
    {
        private SqlDbContext _db;

        public BookstoreSqlRepository(SqlDbContext db)
        {
            _db = db;
        }

        public void AddBook(BookDTO book)
        {
            var bookToAdd = Mapper.Map<Book>(book);
            _db.Books.Add(bookToAdd);
        }

        public void AddPublisher(PublisherDTO publisher)
        {
            var publisherToAdd = Mapper.Map<Publisher>(publisher);
            _db.Publishers.Add(publisherToAdd);
        }

        public void DeleteBook(BookDTO book)
        {
            throw new NotImplementedException();
        }

        public void DeletePublisher(PublisherDTO publisher)
        {
            throw new NotImplementedException();
        }

        public BookDTO GetBook(int publisherId, int bookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDTO> GetBooks(int publisherId)
        {
            throw new NotImplementedException();
        }

        public PublisherDTO GetPublisher(int publisherId, bool includeBooks = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PublisherDTO> GetPublishers()
        {
            throw new NotImplementedException();
        }

        public bool PublisherExists(int publisherId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(int publisherId, int id, BookUpdateDTO book)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublisher(int id, PublisherUpdateDTO publisher)
        {
            throw new NotImplementedException();
        }
    }
}
