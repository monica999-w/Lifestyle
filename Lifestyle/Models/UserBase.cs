using Lifestyle.Exercise;
using Lifestyle.Interface;
using Lifestyle.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lifestyle.Class
{
    public abstract class UserBase: ICloneable<UserBase>
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


        //ICloneable
        public UserBase Clone()
        {
            return new UserProfile(Username, Password, Email, Height, Weight);
          
        }


    }

}
