using System;
using System.Collections.Generic;
using System.Text;

namespace Open_Hands.Models
{
    class UserDetails
    {
        public int Id { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNum { get; set; }
        public DateTime Birthdate { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }                   
    }
}
