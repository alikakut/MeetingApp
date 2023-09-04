using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Domain.Base;

namespace MeetingApp.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("start_date")]
        public DateTime? StartDate { get; set;}

        [Column("package_id")]
        public long? PackageDate { get; set;}

        [Column("education")]
        public string? Education { get; set;}

        [Column("certificate")]
        public string? Certificate { get; set; }

        [ForeignKey("package_id")]
        public PackageEnity Package { get; set; }
    }
}
