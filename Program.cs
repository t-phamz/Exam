//20183732_Tommy_Pham
using System;
using System.Collections.Generic;

namespace _20183732_Tommy_Pham
{
    class Program
    {
        static void Main(string[] args)
        {




            ////test for seasonalproduct.cs
            //SeasonalProduct sp1 = new SeasonalProduct("Coca Cola Rasperry", 12.50m, true, "01/04/2020", "30/04/2020");
            //SeasonalProduct sp2 = new SeasonalProduct("Fanta Lemon", 13.50m, false, "01/05/2020", "30/06/2020");
            //SeasonalProduct sp3 = new SeasonalProduct("Monster Summer", 15.50m, true, "01/04/2020", "7/04/2020");

            ////Console.WriteLine(sp1.ToString());
            ////Console.WriteLine(sp2.ToString());
            ////Console.WriteLine(sp3.ToString());

            ////test for product.cs

            //Product p1 = new Product("Fanta Exotic", 10.50m, true, false);
            //Product p2 = new Product("Coca Cola", 11.50m, true, true);
            //Product p3 = new Product("Monster Energy Pineapple", 15.50m, true, false);

            ////Console.WriteLine(p1.ToString());
            ////Console.WriteLine(p2.ToString());
            ////Console.WriteLine(p3.ToString());


            ////Test for user.cs
            //User test1 = new User("Tommy", "Pham", "TPhamz", "park@kmkm.dk");
            //User test2 = new User("Lasse", "Toet", "SinghKingh22", "pol@kasdsamkm.dk");
            //User test3 = new User("Kasper", "Singh", "Comestink", "s@kasdsamkm.dk");

            ////test1.ToStringTest();
            ////test2.ToStringTest();
            ////test3.ToStringTest();
            //StrikeSystem Treo = new StrikeSystem();
            //Treo.AddCreditsToAccount(test1, 200m);
            //Treo.BuyProduct(test1, p2);
            //Treo.BuyProduct(test1, sp1);
            //test1.ToStringTest();

            //IO io = new IO();
            //Stregsystem ss = new Stregsystem();
            //List<Product> productList = io.ReadProductcsv(@"C:\Users\T-Phamz\OneDrive - Aalborg Universitet\Skole\Objectorienteret_prog\products.csv");

            //Product desired = ss.GetProductByID(21, productList);

            //foreach (var item in productList)
            //{
            //    System.Console.WriteLine($"{item.id}, {item.name}, {item.price}, {item.active}");
            //}
            //List<User> userList = io.ReadUsercsv(@"C:\Users\T-Phamz\OneDrive - Aalborg Universitet\Skole\Objectorienteret_prog\users.csv");
            //foreach (User item in userList)
            //{
            //    Console.WriteLine($"{item.id}, {item.firstName}, {item.lastName}, {item.username}, {item.balance}, {item.email}");
            //}
            //User desireduser = SS.GetUserByUsername("rking", userList);
            //SS.AddCreditsToAccount(desireduser, 25m);
            ////filtrer efter navne med a i dem
            //List<User> filteredUserList = SS.GetUsers(userList, i => i.username.Contains("a"));
            //foreach (User item in filteredUserList)
            //{
            //    Console.WriteLine($"{item.username}");
            //}
            //Stregsystem ss = new Stregsystem();
            //ss.FillUserAndProductList();
            //Console.WriteLine(ss.GetUserByUsername("rking").balance);
            //ss.AddCreditsToAccount(ss.GetUserByUsername("rking"), 100100m);
            //Console.WriteLine("after add credits");
            //Console.WriteLine(ss.GetUserByUsername("rking").balance);
            //StregsystemCLI CLI = new StregsystemCLI(ss);
            //CLI.DrawMenu();

            IStregsystem stregsystem = new Stregsystem();
            IStregsystemUI ui = new StregsystemCLI(stregsystem);
            StregsystemCommandParser sc = new StregsystemCommandParser(ui, stregsystem);

            ui.Start();












        }
    }
}
