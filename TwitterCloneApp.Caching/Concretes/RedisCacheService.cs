﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using TwitterCloneApp.Caching.Abstracts;

namespace TwitterCloneApp.Caching.Concretes
{
	public class RedisCacheService : ICacheService
	{
		private readonly IDistributedCache _distributedCache;
        public RedisCacheService(IDistributedCache distributedCache)
        {
			_distributedCache = distributedCache;
		}

		public async Task<byte[]> GetAsync(string key)
		{
			return await _distributedCache.GetAsync(key);
		}

		public async Task<T> GetAsync<T>(string key)
		{
			var utf8String = Encoding.UTF8.GetString(await _distributedCache.GetAsync(key));
			var result = JsonConvert.DeserializeObject<T>(utf8String);
			return result;
		}

		public async Task SetAsync(string key, object value)
		{
			var serializedObject = JsonConvert.SerializeObject(value);
			var utf8String = Encoding.UTF8.GetBytes(serializedObject);
			await _distributedCache.SetAsync(key, utf8String);
		}

		public async Task RefreshAsync(string key)
		{
			await _distributedCache.RefreshAsync(key);
		}

		public async Task<bool> AnyAsync(string key)
		{
			return await _distributedCache.GetAsync(key) != null;
		}

		public async Task RemoveAsync(string key)
		{
			await _distributedCache.RemoveAsync(key);
		}
	}
}
