using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Domain.Base;

namespace MeetingApp.Domain.Entities
{
    public class PackageEnity : BaseEntity
    {
        [Column("detail")]
        public string Detail { get; set; }

        [Column("price")]
        public int Price { get; set; }
    }
}
