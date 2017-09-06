using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublisherWebAPI.Models;
using PublisherWebAPI.Data;

namespace PublisherWebAPI.Services
{
    public class BookstoreMockRepository : IBookstoreRepository
    {
        public void AddPublisher(PublisherDTO publisher)
        {
            // For Demo purposes only: Get next id
            var id = GetPublishers().Max(m => m.Id) + 1;
            publisher.Id = id;
            MockData.Current.Publishers.Add(publisher);
        }

        public void DeleteBook(BookDTO book)
        {
            MockData.Current.Books.Remove(book);
        }

        public void DeletePublisher(PublisherDTO publisher)
        {
            foreach (var book in publisher.Books)
            {
                DeleteBook(book);
            }
            // Alternative implementation to remove the books from a publisher
            //MockData.Current.Books.RemoveAll(b =>
            //    b.PublisherId.Equals(publisher));


            MockData.Current.Publishers.Remove(publisher);
        }

        public BookDTO GetBook(int publisherId, int bookId)
        {
            return MockData.Current.Books.FirstOrDefault(b =>
                b.PublisherId.Equals(publisherId) && b.Id.Equals(bookId));
        }

        public IEnumerable<BookDTO> GetBooks(int publisherId)
        {
            return MockData.Current.Books.Where(b =>
                b.PublisherId.Equals(publisherId));
        }

        public PublisherDTO GetPublisher(int publisherId, bool includeBooks = false)
        {
            var publisher = MockData.Current.Publishers.FirstOrDefault(
                p => p.Id.Equals(publisherId));

            if (includeBooks && publisher != null)
            {
                publisher.Books = MockData.Current.Books.Where(b =>
                b.PublisherId.Equals(publisherId)).ToList();
            }
            return publisher;
        }

        public IEnumerable<PublisherDTO> GetPublishers()
        {
            return MockData.Current.Publishers;
        }

        public bool PublisherExists(int publisherId)
        {
            return MockData.Current.Publishers.Count(p =>
                p.Id.Equals(publisherId)).Equals(1);
        }

        public bool Save()
        {
            return true;
        }

        public void UpdatePublisher(int id, PublisherUpdateDTO publisher)
        {
            var publisherToUpdate = GetPublisher(id);
            publisherToUpdate.Name = publisher.Name;
            publisherToUpdate.Established = publisher.Established;
        }
    }
}
