using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class UserManagement
    {
        public User AddUser(string username, string firstName, string lastName, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Please input a username!", "Username");
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Please input a First Name!", "FirstName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Please input a Last Name!", "LastName");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Please input a Password!", "Password");
            }

            User newUser = new User()
            {
                EntityID = 1,
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };

            return newUser;
        }

        public void EditUser(List<User> User, string username, string newFirstName, string newLastName)
        {
        
            User = User.Select(edit =>
            {
                if (edit.Username == username)
                {
                    Console.WriteLine(edit.Username);
                    Console.WriteLine(username);
                    edit.FirstName = newFirstName;
                    edit.LastName = newLastName;
                    return edit;
                }
                else
                {
                    throw new ArgumentException("Invalid Username!", "Username");
                }
            }).ToList();   
        }


    }
}


