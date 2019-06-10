using System;
using Business;
using Entity;
using System.Collections.Generic;

using Xunit;
namespace UnitTesting
{
    public class UserTesting
    {
        [Theory]
        [InlineData("Ponkie", "Dino", "Reyes", "HappyHappy")]
        [InlineData("Blast", "Charles", "Nazareno", "HappyHappy")]

        public void AddUser_ShouldAddUser(string username, string firstName, string lastName, string password)
        {
            UserManagement user = new UserManagement();
            List<UserManagement> userList = new List<UserManagement>();

            user.AddUser(username, firstName, lastName, password);
            userList.Add(user);

            int expected = 1;
            int actual = userList.Count;      
            
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("", "Dino", "Reyes", "HappyHappy", "LastName"]
        public void AddUser_ShouldFailNoUsername()
        {
            UserManagement user = new UserManagement();
            
            
        }

    }


}
