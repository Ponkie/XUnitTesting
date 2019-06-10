using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business
{
    public class UserManagement
    {
        public User AddUser (string username, string firstName, string lastName, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Please input a username!");
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Please input a username!");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Please input a username!");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Please input a username!");
            }

            User newUser = new User()
            {
                EntityID = 1,
                Username = "Ponkie",
                FirstName = "Dino",
                LastName = "Reyes",
                Password  = "321Password"
            };

            return newUser;
        }

    }
}
