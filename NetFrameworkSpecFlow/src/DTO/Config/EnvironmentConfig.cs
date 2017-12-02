using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.src.DTO.Config
{
    public class EnvironmentConfig 
    {
        public string HostName { get; set; }
        public string DomainName { get; set; }

        //        public List<Dictionary<string, User>> UserCredentials { get; set; }
        public Dictionary<string, User> UserCredentials { get; set; }

    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
