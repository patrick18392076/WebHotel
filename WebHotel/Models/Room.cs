using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHotel.Models
{
    public class Room
    {   
        // Primary Key
        public int ID { get; set; }

        public string Level { get; set; }
        public int BedCount { get; set; }
        public decimal Price { get; set; }

        // Navigation properties
        public ICollection<Booking> TheBookings {get; set; }


    }
}
