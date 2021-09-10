using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListAPI.Models
{
    public class People
    {
        public int PersonId { get; set; }

        public string PersonFirstName { get; set; }

        public string PersonMiddleName { get; set;  }

        public string PersonLastName { get; set; }

        public string PersonPhoneNumber { get; set; }

        public string PersonAdress { get; set; }
    }
}
