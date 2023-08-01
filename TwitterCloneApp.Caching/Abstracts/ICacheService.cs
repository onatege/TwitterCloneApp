namespace TwitterCloneApp.Caching.Abstracts
{
	public interface ICacheService
	{
		Task<byte[]> GetAsync(string key);
		Task<T> GetAsync<T>(string key);
		Task SetAsync(string key, object value);
		Task RefreshAsync(string key);
		Task<bool> AnyAsync(string key);
		Task RemoveAsync(string key);
	}
}
