//20183732_Tommy_Pham
using System;
using System.Collections.Generic;

namespace _20183732_Tommy_Pham
{
    public interface IStregsystem
    {
        IEnumerable<Product> Products { get; }
        InsertCashTransaction AddCreditsToAccount(User user, decimal amount);
        BuyTransaction BuyProduct(User user, Product product);
        Product GetProductByID(int id);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        List<User> GetUsers(Func<User, bool> predicate);
        User GetUserByUsername(string userName);
        event User.UserBalanceNotification UserBalanceWarning;
        void OnUserBalanceWarning(User user);
        public void LogTransaction(Transaction t, string filePath);

    }

}
