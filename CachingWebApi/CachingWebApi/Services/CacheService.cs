using System.Runtime.Caching;

namespace CachingWebApi.Services;

public class CacheService:ICacheService
{
    private ObjectCache _cacheMemory = MemoryCache.Default;
    
    public T GetData<T>(string key)
    {
        try
        {
            T item = (T)_cacheMemory.Get(key);
            return item;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        var res = true;
        try
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value.ToString()))
            {
                _cacheMemory.Set(key,value,expirationTime);
            }
            else
            {
                res = false;
            }

            return false;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public object RemoveData(string key)
    {
        var res = true;
        try
        {
            if (!string.IsNullOrEmpty(key))
            {
                _cacheMemory.Remove(key);
            }
            else
            {
                res = false;
            }

            return false;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}