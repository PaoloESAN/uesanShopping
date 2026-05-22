using System;
using System.Collections.Generic;
using System.Text;

namespace UESAN.SHOPPING.CORE.core.Settings
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
