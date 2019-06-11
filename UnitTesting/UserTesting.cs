using Business;
using Entity;
using System;
using System.Collections.Generic;
using Xunit;
namespace UnitTesting
{
    public class UserTesting
    {
        UserManagement userMan = new UserManagement();
        List<User> userList = new List<User>();

        [Theory]
        [InlineData("Ponkie", "Dino", "Reyes", "HappyHappy")]
        [InlineData("Blast", "Charles", "Nazareno", "HappyHappy")]

        public void AddUser_ShouldAddUser(string username, string firstName, string lastName, string password)
        {

            userList.Add(userMan.AddUser(username, firstName, lastName, password));

            int expected = 1;
            int actual = userList.Count;

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("", "Dino", "Angelo", "yoyoyoyo", "Username")]
        [InlineData("Ponkie", "", "Angelo", "yoyoyoyo", "FirstName")]
        [InlineData("Ponkie", "Dino", "", "yoyoyoyo", "LastName")]
        [InlineData("Ponkie", "Dino", "Angelo", "", "Password")]

        public void AddUser_ShouldFailEmptyFields(string username, string firstName, string lastName, string password, string param)
        {
            UserManagement user = new UserManagement();

            Assert.Throws<ArgumentException>(param, () => user.AddUser(username, firstName, lastName, password));
        }

        [Theory]
        [InlineData("Ponkie", "Yoyo")]
        public void EditUser_ShouldEditFirstName(string username, string firstName)
        {
            string actual = "";

            userList.Add(userMan.AddUser(username, "1", "2", "3"));

            userMan.EditUser(userList, username, firstName, "3");

            foreach (var list in userList)
            {
                actual = list.FirstName;
            }

            Assert.Equal(firstName, actual);
        }

        [Theory]
        [InlineData("Ponkie", "Yoyo")]
        public void EditUser_ShouldEditLastName(string username, string lastName)
        {
            string actual = "";

            userList.Add(userMan.AddUser(username, "1", "2", "3"));

            userMan.EditUser(userList, username, "2", lastName);

            foreach (var list in userList)
            {
                actual = list.LastName;
            }
            Assert.Equal(lastName, actual);
        }

        [Theory]
        [InlineData("Ponki", "Username")]
        public void EditUser_ShouldFailInvalidUsername(string username, string param)
        {
            userList.Add(userMan.AddUser("Ponkie", "Dino", "Reyes", "Password"));

            Assert.Throws<ArgumentException>(param, () => userMan.EditUser(userList, username, "Dino", "Angelo"));

        }
    }


}
