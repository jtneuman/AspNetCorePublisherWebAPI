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
        public IEnumerable<PublisherDTO> GetPublishers()
        {
            return MockData.Current.Publishers;
        }
    }
}
