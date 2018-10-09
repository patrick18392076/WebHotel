using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHotel.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string PostCode { get; set; }

        // Navigation properties
        public ICollection<Booking> TheBookings { get; set; }
    }
}
