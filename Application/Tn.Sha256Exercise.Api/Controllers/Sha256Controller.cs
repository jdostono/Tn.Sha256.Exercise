using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tn.Sha256.Api.Services;

namespace Tn.Sha256.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Sha256Controller : ControllerBase
    {
        private readonly ICacheService _cacheService;
        
        public Sha256Controller(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("encrypt")]
        public async Task<string> Encrypt(string name)
        {   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(name));  
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }
                
                _cacheService.Hash = new KeyValuePair<string, string>(name, builder.ToString());
                
                return await Task.FromResult(_cacheService.Hash.Value);  
            }
        }
        
        [HttpGet("decrypt")]
        public async Task<string> Decrypt(string hash)
        {
            var result = "unknown hash";

            if (hash == _cacheService.Hash.Value)
            {
                result = _cacheService.Hash.Key;
            }

            return await Task.FromResult(result);    
        }
    }
}