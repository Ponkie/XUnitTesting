using Business;
using Entity;
using System;
using System.Collections.Generic;

namespace XUnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> userList = new List<User>();
            UserManagement userMan = new UserManagement();
            userList.Add(userMan.AddUser("Ponkie", "Dino", "Reyes", "Huehuehue"));
            userList.Add(userMan.AddUser("Ponkiz", "Dinoa", "Reyesa", "Huehueaaahue"));
            userList.Add(userMan.AddUser("Ponkib", "Dinoa", "Reyesa", "Huehueaaahue"));
            displayList(userList);


            userMan.DeleteUser(userList, "Ponkiz");
            displayList(userList);

        }

        private static void displayList(List<User> userList)
        {
            foreach (var list in userList)
            {
                Console.WriteLine("{0}-------{1}-------{2}", list.Username, list.FirstName, list.LastName);
            }
        }
    }
}
