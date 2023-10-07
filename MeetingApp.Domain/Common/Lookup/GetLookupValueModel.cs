using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Domain.Common
{
    public class GetLookupValueModel : LookupValueModel
    {
        public List<int> LookupValueOrdinalList { get; set; }
    }
}
