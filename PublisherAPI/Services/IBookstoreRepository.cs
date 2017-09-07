using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublisherWebAPI.Models;

namespace PublisherWebAPI.Services
{
    public interface IBookstoreRepository
    {
        IEnumerable<PublisherDTO> GetPublishers();
        PublisherDTO GetPublisher(int publisherId, bool includeBooks = false);
        void AddPublisher(PublisherDTO publisher);
        void UpdatePublisher(int id, PublisherUpdateDTO publisher);
        void DeleteBook(BookDTO book);
        void DeletePublisher(PublisherDTO publisher);
        bool PublisherExists(int publisherId);
        bool Save();

        IEnumerable<BookDTO> GetBooks(int publisherId);
        BookDTO GetBook(int publisherId, int bookId);
        void AddBook(BookDTO book);
        void UpdateBook(int publisherId, int id, BookUpdateDTO book);
        
    }
}
