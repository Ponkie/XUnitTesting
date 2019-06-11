using Entity;
using System;
using System.Collections.Generic;

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

        public bool checkPassword(string password)
        {
            bool haveUpper = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) haveUpper = true;
            }

            if (!haveUpper) throw new ArgumentException("Invalid Password! Must contain 1 uppercase!", "Password");

            return haveUpper;
        }

        public void EditUser(List<User> userList, string username, string newFirstName, string newLastName)
        {
            int editCtr = 0;
            userList.ForEach(edit =>
            {
                if (edit.Username == username)
                {
                    edit.FirstName = newFirstName;
                    edit.LastName = newLastName;
                    editCtr++;
                }
            });
            if (editCtr == 0) throw new ArgumentException("Invalid Username!", "Username");

        }

        public void DeleteUser(List<User> UserList, string username)
        {
            int index = UserList.FindIndex(del => del.Username == username);
            if (index >= 0) UserList.RemoveAll(rem => rem.Username == username);
            else throw new ArgumentException("Invalid Username!", "Username");
        }

    }
}


