using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthSample.Models
{
    public class JwtSettings
    {
        /// <summary>
        /// 颁发者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 授权使用者
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string SecretKey { get; set; }
    }
}
