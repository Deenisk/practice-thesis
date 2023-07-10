using System;
using System.Collections.Generic;
using System.Text;

namespace SportClose
{
    class User
    {
        public string Name {get; private set;}
        public string Username{ get; private set;}
        public string Password {get; private set;}

        public User(string name, string username, string password)
        {
            Name = name;
            Password = password;
            Username = username;
        }
    }
}
