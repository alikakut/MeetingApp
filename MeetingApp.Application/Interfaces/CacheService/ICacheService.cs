using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Application.Interfaces.CacheService
{
    public interface ICacheService
    {
        void InsertValue(string key, string value, int cacheTime = 0);
        string GetByKey(string key);
        void Delete(string key);
        T? Get<T>(string key, Func<T> factory) where T : class;
        void Flush();
    }
}
