using Lifestyle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Class
{
    public class UserProfile : UserBase
    {
        public Planner Planner { get; set; }

        public UserProfile(string username, string password, string email, double height, double weight)
        : base(username, password, email, height, weight)
        {
            Planner = new Planner();
        }

    }
}
