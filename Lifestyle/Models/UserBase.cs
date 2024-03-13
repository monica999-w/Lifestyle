using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Class
{
    public abstract class UserBase
    {


        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }




        protected UserBase(string username, string password, string email, double height, double weight)
        {
            Username = username;
            Password = password;
            Email = email;
            Height = height;
            Weight = weight;
        }
    }

}
