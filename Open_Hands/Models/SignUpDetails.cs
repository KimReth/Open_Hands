using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Open_Hands.Models
{
    public class SignUpDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int IdEventDetails { get; set; }

        //public int IdUserDetails { get; set; }

        public bool IsVolunteer { get; set; }

        //If the user is not the volunteer
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
        
        public DateTime Birthdate { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(225)]
        public string Comments { get; set; }

        [MaxLength(20)]
        public string PhoneNum { get; set; }
    }
}
