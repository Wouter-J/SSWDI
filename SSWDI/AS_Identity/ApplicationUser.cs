using System;
using Microsoft.AspNetCore.Identity;

namespace AS_Identity
{
    public class ApplicationUser : IdentityUser
    {
        // Note that E-mail is a default value from IdentityUser
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Cellphone { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
    }
}
