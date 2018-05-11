using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA18_hw2_Dushkevych
{
    public enum CarType { Passenger, Truck, Bus, Motorcycle }

    public class Car
    {
        private static int idCounter = 1;
        private int id;
        private double balance;
        private CarType carType;

        public int Id { get { return id; } }
        public double Balance { get { return balance; } }
        public CarType CarType { get { return carType; } }

        public Car(CarType carTypeArg, double initialBalance)
        {
            id = idCounter;
            balance = initialBalance;
            carType = carTypeArg;
            idCounter++;
        }

        public static void RemoveCar()
        {

        }

        public void LoadCarBalance(double amount)
        {
            balance += amount;
        }

        public Transaction ChargeCarParkingFee()
        {
            double amountToCharge = (double)Settings.ParkingPrice[carType];
            if(amountToCharge > balance)
            {
                amountToCharge *= Settings.Fine;
            }
            balance -= amountToCharge;
            return new Transaction(id, amountToCharge);
        }

        public override string ToString()
        {
            return "ID: " + id + "   Car type: " + carType + "  Balance: " + balance;
        }
    }
}
