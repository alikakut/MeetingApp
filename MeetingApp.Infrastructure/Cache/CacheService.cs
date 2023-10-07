using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Extensions;
using MeetingApp.Application.Interfaces.CacheService;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MeetingApp.Infrastructure.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _cache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public CacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
            _cache = connectionMultiplexer.GetDatabase();
        }

        public void Delete(string key)
        {
            try
            {
                _cache.KeyDelete(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Redis Cache Server Error : {ex.Message}");
            }
        }

        public void Flush()
        {
            try
            {
                var endpoints = _connectionMultiplexer.GetEndPoints();
                foreach (var endpoint in endpoints)
                {
                    var server = _connectionMultiplexer.GetServer(endpoint);
                    server.FlushAllDatabases();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Redis Cache Server Error : {ex.Message}");
            }
        }

        public T? Get<T>(string key, Func<T> factory) where T : class
        {
            T? data;
            try
            {
                var cachedValue = GetByKey(key);

                if (cachedValue.IsNotNullOrEmpty())
                {
                    return JsonConvert.DeserializeObject<T>(cachedValue);
                }

                data = factory();

                InsertValue(key, JsonConvert.SerializeObject(data), cacheTime: 720);

            }
            catch (Exception)
            {
                throw new Exception($"Servis Hatası");
            }

            return data;
        }

        public string GetByKey(string key)
        {
            try
            {
                return _cache.StringGet(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Redis Cache Server Error : {ex.Message}");
            }
        }

        public void InsertValue(string key, string value, int cacheTime = 0)
        {
            try
            {
                cacheTime = cacheTime == 0 ? 60 : cacheTime;
                _cache.StringSet(key, value, TimeSpan.FromMinutes(cacheTime));
            }
            catch (Exception ex)
            {
                throw new Exception($"Redis Cache Server Error : {ex.Message}");
            }
        }
    }
}
