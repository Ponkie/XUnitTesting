using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User : BaseClass
    {
        private string username;
        private string firstName;
        private string lastName;
        private string password;
        public string Username { get { return username; } set { username = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Password {  get { return password; } set { password = value; } }
    }
}
