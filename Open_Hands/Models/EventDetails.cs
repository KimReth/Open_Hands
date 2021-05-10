using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open_Hands.Models
{
    public class EventDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string EventName { get; set; }

        [MaxLength(50)]
        public string Street { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(30)]
        public string State { get; set; }

        [MaxLength(15)]
        public string Zip { get; set; }

        public DateTime StartingDate { get; set; }

        //public DateTime StartTime { get; set; }

        public DateTime EndingDate { get; set; }

       // public DateTime EndTime { get; set; }

        [MaxLength(225)]
        public string Description { get; set; }

        public int MaxVolunteers { get; set; }

        public string ContactPhoneNum { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }
    }
}
