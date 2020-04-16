//20183732_Tommy_Pham

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                userList.Add(new User(id, firstName, lastName, username, balance, email));
            }
            return userList;
        }

        public List<Transaction> ReadTransactiontxt(string filePath)
        {
            Stregsystem ss = new Stregsystem();
            List<Transaction> transactionList = new List<Transaction>();
            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    List<string> newList = line.Split(",").ToList();
                    int id = int.Parse(newList[0]);
                    string kindOfTransaction = newList[1];
                    string username = newList[2];
                    decimal amount = decimal.Parse(newList[3]);
                    int productID = int.Parse(newList[4]);
                    DateTime date = DateTime.Parse(newList[5]);
                    User u = ss.GetUserByUsername(username);
                
                    if (kindOfTransaction == "InsertCashTransaction")
                    {
                        transactionList.Add(new InsertCashTransaction(id, u, amount, date));
                    }
                    else if (kindOfTransaction == "BuyTransaction")
                    {
                        Product p = ss.GetProductByID(productID);
                        transactionList.Add(new BuyTransaction(id, u, p, date));
                    }
                }
                return transactionList;
            }
            catch (FileNotFoundException)
            {
                File.Create(filePath).Dispose();
                return transactionList;
            }

        }

    }
}
