using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helper.Security.Jwt
{
    // token ozelliklerini tutan entity classım
  public  class AccessToken 
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
