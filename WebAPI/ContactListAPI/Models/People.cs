using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListAPI.Models
{
    public class People
    {

        [Key]
        public int PersonId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PersonFirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PersonMiddleName { get; set;  }

        [Column(TypeName = "nvarchar(100)")]
        public string PersonLastName { get; set; }

        public string PersonPhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PersonAdress { get; set; }
    }
}
