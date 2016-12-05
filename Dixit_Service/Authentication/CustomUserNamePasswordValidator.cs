using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dixit_Service
{
    public class CustomUserNamePasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new SecurityTokenException("Username and password cannot be empty.");
            //m:161009:TODO
        }
    }
}
