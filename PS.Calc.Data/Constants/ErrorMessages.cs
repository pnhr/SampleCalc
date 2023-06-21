﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Calc.Data.Constants
{
    public static class ErrorMessages
    {
        public const string UNHANDLED_EXCEPTION = "Something went wrong at backend. Please contact site admin";
        public const string HTTP_CONTEXT_NOT_FOUND = "Http Context is null";
        public const string UNAUTHORIZED = "Unauthorized access to the api";
    }
}
