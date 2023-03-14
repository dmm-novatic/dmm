using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novatic.Models;
using Novatic.Repository;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Novatic.Util
{
    public interface ICacheHelper
    {
        Dictionary<string, SystemConfig> GetSystemConfig();
        void SetSystemConfig(List<SystemConfig> systemConfigs);
        void SetSystemConfig(Dictionary<string, SystemConfig> systemConfigs);
    }

    public class CacheHelper : ICacheHelper
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public Dictionary<string, SystemConfig> GetSystemConfig()
        {
            Dictionary<string, SystemConfig> obj = null;
            _cache.TryGetValue<string>("SystemConfig", out var json);

            if (json != null)
            {
                obj = JsonConvert.DeserializeObject<Dictionary<string, SystemConfig>>(json);
            }

            return obj;
        }

        public void SetSystemConfig(List<SystemConfig> systemConfigs)
        {
            SetSystemConfig(systemConfigs.ToDictionary(p => p.Code));
        }

        public void SetSystemConfig(Dictionary<string, SystemConfig> systemConfigs)
        {
            var json = JsonConvert.SerializeObject(systemConfigs);
            _cache.Set("SystemConfig", json);
        }
    }
}
