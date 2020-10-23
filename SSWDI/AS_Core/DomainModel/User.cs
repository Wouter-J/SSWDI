using System;
using System.Collections.Generic;
using System.Text;

namespace AS_Core.DomainModel
{
    public class User
    {
        public int CustomerID { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public string Cellphone { get; set; }

        public DateTime BirthDay { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }
    }
}
