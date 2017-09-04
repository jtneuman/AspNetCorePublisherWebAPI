using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PublisherWebAPI.Models
{
    public class PublisherCreateDTO
    {
        [Required(ErrorMessage = "You must enter a name.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Established { get; set; }

    }
}
