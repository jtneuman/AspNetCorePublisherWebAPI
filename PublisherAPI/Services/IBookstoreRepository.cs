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
        bool Save();
    }
}
