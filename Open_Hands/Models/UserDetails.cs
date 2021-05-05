using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open_Hands.Models
{
    public class UserDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string PhoneNum { get; set; }

        public DateTime Birthdate { get; set; }

        [MaxLength(20)]
        public string Role { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(225)]
        public string Password { get; set; }                   
    }
}
