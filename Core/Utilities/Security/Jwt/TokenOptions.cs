using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security
{
    // Token Bilgilerini match edecek sinif
   public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
