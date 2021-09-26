using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Reservation
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Book ReservedBook { get; set; }
        public int ReservedBookId { get; set; }
    }
}