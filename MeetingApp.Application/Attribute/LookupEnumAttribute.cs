using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Application.Attribute
{
    public class LookupEnumAttribute : System.Attribute
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
    }
}
