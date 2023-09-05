using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Domain.Base;

namespace MeetingApp.Domain.Entities
{
    [Table("users")]
    public class UserEntity : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phome_number")]
        public int PhoneNumber { get; set; }

        [Column("password_no")]
        public string Password { get; set; }


    }
}
