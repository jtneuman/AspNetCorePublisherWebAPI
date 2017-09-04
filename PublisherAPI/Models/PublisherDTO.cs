using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublisherWebAPI.Models
{
    public class PublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Established { get; set; }
        //public int BookCount{get { return Books.Count; } what below means
        public int BookCount => Books.Count;
        public ICollection<BookDTO> Books { get; set; } = new List<BookDTO>();

    }
}