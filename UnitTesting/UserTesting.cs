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
            //userList.Add(userMan.AddUser(username, firstName, lastName, password));

            //var expected = new User();
            //expected.EntityID = 1;
            //expected.Username = username;
            //expected.FirstName = firstName;
            //expected.LastName = lastName;
            //expected.Password = password;

            //Assert.Contains(expected, userList);
            int actual = 0;
            userList.Add(userMan.AddUser(username, firstName, lastName, password));
            int expected = 1;
            actual = userList.Count;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", "Dino", "Angelo", "yoyoyoyo", "Username")]
        [InlineData("Ponkie", "", "Angelo", "yoyoyoyo", "FirstName")]
        [InlineData("Ponkie", "Dino", "", "yoyoyoyo", "LastName")]
        [InlineData("Ponkie", "Dino", "Angelo", "", "Password")]

        public void AddUser_ShouldFailEmptyFields(string username, string firstName, string lastName, string password, string param)
        {
            Assert.Throws<ArgumentException>(param, () => userMan.AddUser(username, firstName, lastName, password));
        }

        [Fact]
        public void AddUser_ShouldAcceptPassword()
        {
            bool expected = true;
            bool actual = userMan.checkPassword("Password");
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ssword", "Password")]
        public void AddUser_ShouldNotAcceptPassword(string password, string param)
        {
            Assert.Throws<ArgumentException>(param, () => userMan.checkPassword(password));
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
        [InlineData("asdadas", "Username")]
        public void EditUser_ShouldFailInvalidUsername(string username, string param)
        {
            userList.Add(userMan.AddUser("Ponkie", "Dino", "Reyes", "Password"));

            Assert.Throws<ArgumentException>(param, () => userMan.EditUser(userList, username, "Dino", "Angelo"));
        }

        [Theory]
        [InlineData("Ponkie")]
        public void DeleteUser_ShouldDeleteUser(string username)
        {
            bool actual = true;
            bool expected = false;
            userList.Add(userMan.AddUser(username, "Dino", "Reyes", "Password"));
            userList.Add(userMan.AddUser("Heyhey", "Ellah", "Agni", "Drowssap"));
            userMan.DeleteUser(userList, username);
            foreach (var list in userList)
            {
                if (list.Username != username) actual = false;              
            }         
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Ponki", "Username")]
        public void DeleteUser_ShouldFailDeleteUser(string username, string param)
        {
            userList.Add(userMan.AddUser("Ponkie", "Dino", "Reyes", "Password"));
            Assert.Throws<ArgumentException>(param, () => userMan.DeleteUser(userList, username));
        }


    }


}
