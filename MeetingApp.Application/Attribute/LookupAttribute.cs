using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Application.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LookupAttribute : System.Attribute
    {
        public bool IsRequired { get; set; } = true;
        public Type EnumType { get; set; }
    }
}
