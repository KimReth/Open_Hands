using System;
using System.Collections.Generic;
using System.Text;

namespace Open_Hands.Models
{
    class EventDetails
    {        
        public int Id { get; set; }

        public string EventName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; } 
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public int MaxVolunteers { get; set; }

        public bool SharePhoneNum { get; set; }

        public int IdUserDetails { get; set; }
    }
}
