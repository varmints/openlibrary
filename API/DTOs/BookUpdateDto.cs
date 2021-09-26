using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ShortDescription { get; set; }
    }
}