using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA18_hw2_Dushkevych
{
    public class Parking
    {
        private List<Car> cars = new List<Car>();
        private List<Transaction> transactions = new List<Transaction>();
        private double balance = 0.0;

        public List<Car> Cars
        {
            get
            {
                return cars;
            }
        }
        public List<Transaction> Transactions
        {
            get
            {
                return transactions;
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }
        }
    }
}
