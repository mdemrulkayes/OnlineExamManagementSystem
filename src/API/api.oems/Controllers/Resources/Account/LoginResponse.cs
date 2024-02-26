using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Controllers.Resources.Account
{
    public class LoginResponse
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string auth_token { get; set; }
    }
}
