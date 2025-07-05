using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
      public abstract class User
    {
        private string username;
        private string email;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gamertag { get; set; }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public abstract void Post(string content);//i cannot implement this method just in deriven class 
        internal abstract void Comment(IPost post, string content);//   /////////////////////////////

    }
}
