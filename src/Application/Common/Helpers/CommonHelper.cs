using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Application.Common.Helpers
{
    public class CommonHelper
    {
        public static bool EmailFormat(string email)
        {
            return Regex.IsMatch(email, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+(^-.]\\w+)*");
        }
    }
}
