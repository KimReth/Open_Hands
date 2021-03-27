using System;
using System.Collections.Generic;
using System.Text;

namespace Open_Hands.Models
{
    class SignUpDetails
    {
        public int Id { get; set; }

        public int IdEventDetails { get; set; }
        public int IdUserDetails { get; set; }
        
        public bool IsVolunteer { get; set; }

        //If the user is not the volunteer
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
    }
}
