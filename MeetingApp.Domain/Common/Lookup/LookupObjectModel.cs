using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Domain.Common.Lookup
{
    public class LookupObjectModel
    {
        public int? Ordinal { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public int? ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
