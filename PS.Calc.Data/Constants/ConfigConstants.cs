using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Calc.Data.Constants
{
    public static class ConfigConstants
    {
        public static string JwtSecurityKey
        {
            get
            {
                return "Authentication:JWTSettings:SecretKey";
            }
        }
    }
}
