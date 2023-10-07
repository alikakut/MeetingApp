using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Domain.Common;

namespace MeetingApp.Application.Interfaces.LookupHelper
{
    public interface ILookupHelper
    {
        List<LookupValueResult> FillLookupValue(GetLookupValueModel lookupValueModel);
        List<LookupValueResult> FillLookupValue(List<string> ClassNameList);
    }

    public interface ILookupHelper<TModel> : ILookupHelper
    {
        void ResolveMapping(List<TModel> source);
        void ResolveMapping(TModel source);
    }
}
