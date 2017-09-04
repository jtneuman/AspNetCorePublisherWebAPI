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

    }
}
