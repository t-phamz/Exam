//20183732_Tommy_Pham

using System;
using System.Collections.Generic;

namespace _20183732_Tommy_Pham
{
    class StregsystemCommandParser
    {
        IStregsystemUI ui;
        IStregsystem ss;
        private readonly Dictionary<string, Action> _adminCommands = new Dictionary<string, Action>();
        private string _command { get; set; }

        public StregsystemCommandParser(IStregsystemUI ui, IStregsystem stregsystem)
        {
            this.ss = stregsystem;
            this.ui = ui;
            FillAdminCommands();
        }

        public void FillAdminCommands()
        {
            _adminCommands.Add(":q", () => ui.Close());
            _adminCommands.Add(":quit", () => ui.Close());
            _adminCommands.Add(":activate", () =>
            {
                try
                {
                    if (ProductSuccess(int.Parse(_command.Split(" ")[1])))
                    {
                        Product p = ss.GetProductByID(int.Parse(_command.Split(" ")[1]));
                        if (p is SeasonalProduct)
                        {
                            ui.DisplayGeneralError($"{p.name} is a seasonal product");
                            return;
                        }
                        p.active = true;
                        Console.WriteLine($"{p.name} has been activated");
                    }
                }
                catch (FormatException)
                {
                    ui.DisplayGeneralError($"{_command.Split(" ")[1]} is not a positive integer");
                }


            });
            _adminCommands.Add(":deactivate", () =>
            {
                try
                {
                    if (ProductSuccess(int.Parse(_command.Split(" ")[1])))
                    {
                        Product p = ss.GetProductByID(int.Parse(_command.Split(" ")[1]));
                        if (p is SeasonalProduct)
                        {
                            ui.DisplayGeneralError($"{p.name} is a seasonal product");
                            return;
                        }
                        p.active = false;
                        Console.WriteLine($"{p.name} has been deactivated");
                    }

                }
                catch (FormatException)
                {
                    ui.DisplayGeneralError($"{_command.Split(" ")[1]} is not a positive integer");
                }
            });
            _adminCommands.Add(":crediton", () =>
            {
                try
                {
                    if (ProductSuccess(int.Parse(_command.Split(" ")[1])))
                    {
                        Product p = ss.GetProductByID(int.Parse(_command.Split(" ")[1]));
                        if (p is SeasonalProduct)
                        {
                            ui.DisplayGeneralError($"{p.name} is a seasonal product");
                            return;
                        }
                        p.canBeBoughtOnCredit = true;
                        Console.WriteLine($"{p.name} can now be bought on credit");
                    }

                }
                catch (FormatException)
                {
                    ui.DisplayGeneralError($"{_command.Split(" ")[1]} is not a positive integer");
                }
            });
            _adminCommands.Add(":creditoff", () =>
            {
                try
                {
                    if (ProductSuccess(int.Parse(_command.Split(" ")[1])))
                    {
                        Product p = ss.GetProductByID(int.Parse(_command.Split(" ")[1]));
                        if (p is SeasonalProduct)
                        {
                            ui.DisplayGeneralError($"{p.name} is a seasonal product");
                            return;
                        }
                        p.canBeBoughtOnCredit = false;
                        Console.WriteLine($"{p.name} can now not be bought on credit");
                    }

                }
                catch (FormatException)
                {
                    ui.DisplayGeneralError($"{_command.Split(" ")[1]} is not a positive integer");
                }
            });
            _adminCommands.Add(":addcredits", () =>
            {
                if (UserSucess(_command.Split(" ")[1]))
                {

                    User u = ss.GetUserByUsername(_command.Split(" ")[1]);
                    ss.LogTransaction(ss.AddCreditsToAccount(u, int.Parse(_command.Split(" ")[2])), @"C:\Users\T-Phamz\Desktop\test.txt");
                    Console.WriteLine($"{_command.Split(" ")[2]} credits has been added to {u.username}");


                }
            });
        }



        public void ParseCommand()
        {
            _command = Console.ReadLine();
            string[] command = _command.Split(" ");

            if (command[0].StartsWith(":"))
            {
                bool success = false;
                foreach (var item in _adminCommands)
                {
                    if (_command.StartsWith(item.Key))
                    {
                        item.Value();
                        success = true;
                    }
                }
                if (success == false)
                {
                    ui.DisplayAdminCommandNotFoundMessage(_command);
                }

            }
            else if (command.Length == 2)
            {
                try
                {
                    string user = command[0];
                    int productID = int.Parse(command[1]);
                    if (ProductSuccess(productID) && UserSucess(user))
                    {
                        ss.LogTransaction(ss.BuyProduct(ss.GetUserByUsername(user), ss.GetProductByID(productID)), @"C:\Users\T-Phamz\Desktop\test.txt");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{(command[1])} is not a positive integer");
                }
                catch (InsufficientCreditsException)
                {
                    ui.DisplayInsufficientCash(ss.GetUserByUsername(command[0]), ss.GetProductByID(int.Parse(command[1])));
                }
            }
            else if (command.Length == 3)
            {
                try
                {
                    string user = command[0];
                    int numberOfItems = int.Parse(command[1]);
                    int productID = int.Parse(command[2]);
                    if (ProductSuccess(productID) && UserSucess(user))
                    {
                        for (int i = 0; i < numberOfItems-1; i++)
                        {
                            ss.LogTransaction(ss.BuyProduct(ss.GetUserByUsername(user), ss.GetProductByID(productID)), @"C:\Users\T-Phamz\Desktop\test.txt");
                        }
                        ui.DisplayUserBuysProduct(numberOfItems, ss.BuyProduct(ss.GetUserByUsername(user), ss.GetProductByID(productID)));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{(command[1])} or {(command[2])} " +
                                      $"is not a number");
                }
                catch (InsufficientCreditsException)
                {
                    ui.DisplayInsufficientCash(ss.GetUserByUsername(command[0]), ss.GetProductByID(int.Parse(command[1])));
                }
            }
            else if (command.Length == 1)
            {
                //brugernavn
                if (UserSucess(command[0]))
                {
                    User u = ss.GetUserByUsername(command[0]);
                    ui.DisplayUserInfo(u);
                    ss.OnUserBalanceWarning(u);
                    foreach (Transaction item in ss.GetTransactions(u, 10))
                    {
                        ui.DisplayTransactions(item);
                    }
                    //Hvis saldo er under 50 kr skal brugeren informeres med tekst 
                }
            }
            else
            {
                ui.DisplayTooManyArgumentsError($"\"{_command}\"");
            }
            Console.WriteLine();
        }

        public bool ProductSuccess(int id)
        {
            bool res = false;
            try
            {
                ss.GetProductByID(id);
                res = true;
            }
            catch (System.Exception)
            {
                ui.DisplayProductNotFound(id.ToString());
            }
            return res;
        }
        public bool UserSucess(string username)
        {
            bool res = false;
            try
            {
                ss.GetUserByUsername(username);
                res = true;
            }
            catch (System.Exception)
            {
                ui.DisplayUserNotFound(username);
            }
            return res;
        }
        

    }
}
