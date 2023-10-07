using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace MeetingApp.Application.Utilities.Sieve
{
    public class BaseApplicationSieveProcessor<TFilterModel, TFilterTerm, TSortTerm> : SieveProcessor<DataFilterModel, FilterTerm, SortTerm>
    {
        public BaseApplicationSieveProcessor(IOptions<SieveOptions> options) : base(options)
        {
        }
    }
}
