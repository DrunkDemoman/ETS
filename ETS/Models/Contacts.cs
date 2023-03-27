using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace ETS.Models
{
    [Table("contacts")]
    public class Contacts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), Unique]
        public string Name { get; set; }

        [MaxLength (100)]
        public string Company { get; set; }

        [MaxLength (100)]
        public string Email { get; set; }

        [MaxLength (15)]
        public string OfficeNumber { get; set; }

        [MaxLength (15)]
        public string PhoneNumber { get; set; }

    }
}
