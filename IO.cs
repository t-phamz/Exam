//20183732_Tommy_Pham

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/// <summary>
/// CANBEBOUGHTONCREDIT??????????????
/// </summary>
namespace _20183732_Tommy_Pham
{
    public class IO
    {
        public List<Product> ReadProductcsv(string filePath)
        {
            List<Product> productList = new List<Product>();

            foreach (string line in File.ReadLines(filePath).Skip(1))
            {
                List<string> newList = line.Split(";").ToList();

                int id = int.Parse(newList[0]);
                string name = newList[1];
                decimal price = decimal.Parse(newList[2]);
                bool isActive = Convert.ToBoolean(Convert.ToInt32(newList[3]));
                productList.Add(new Product(id, name, price, isActive, false));
            }

            return productList;

        }
        public List<User> ReadUsercsv(string filePath)
        {
            List<User> userList = new List<User>();
            foreach (string line in File.ReadLines(filePath).Skip(1))
            {
                List<string> newList = line.Split(",").ToList();
                int id = int.Parse(newList[0]);
                string firstName = newList[1];
                string lastName = newList[2];
                string username = newList[3];
                decimal balance = decimal.Parse(newList[4]);
                string email = newList[5];
                userList.Add(new User(firstName, lastName, username, balance, email));
            }
            return userList;
        }

    }
}
