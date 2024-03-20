using Lifestyle.Class;
using Lifestyle.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestyle.Models
{
    public class UserRepository : IRepository<UserProfile>
    {

        private List<UserProfile> users;

        public UserRepository()
        {
            users = new List<UserProfile>();
        }

        public void Add(UserProfile entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            users.Add(entity);
        }

        public void Remove(UserProfile entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            users.Remove(entity);
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return users;
        }

    }
}

