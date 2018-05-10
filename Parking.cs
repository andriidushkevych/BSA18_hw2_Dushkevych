using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA18_hw2_Dushkevych
{
    public sealed class Parking
    {
        private static readonly Parking parking = new Parking();
        private List<Car> cars;
        private List<Transaction> transactions;
        private double balance;

        public static Parking ParkingInstance
        {
            get
            {
                return parking;
            }
        }
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

        private Parking()
        {
            cars = new List<Car>();
            transactions = new List<Transaction>();
            balance = 0.0;
        }

        public static void ShowRecentTransactionHistory()
        {

        }

        public static void ShowTotalIncome()
        {

        }

        public static void ShowVacantSpots()
        {

        }
    }
}
