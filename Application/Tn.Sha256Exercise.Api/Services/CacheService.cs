using System.Collections.Generic;

namespace Tn.Sha256Exercise.Api.Services
{
    public interface ICacheService
    {
        KeyValuePair<string, string> Hash { get; set; }
    }
    
    public class CacheService : ICacheService
    {
        public KeyValuePair<string, string> Hash { get; set; }
    }
}