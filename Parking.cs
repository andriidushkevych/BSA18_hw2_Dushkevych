using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

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
            private set
            {
                this.balance = value;
            }
        }

        private Parking()
        {
            cars = new List<Car>();
            transactions = new List<Transaction>();
            balance = 0.0;
            Timer aTimer = new Timer(Settings.Timeout * 1000); //from https://msdn.microsoft.com/en-us/library/system.timers.timer(v=vs.110).aspx#Examples
            aTimer.Elapsed += ChargeParkingFee;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void ChargeParkingFee(Object source, ElapsedEventArgs e)
        {
            if(cars.Count != 0)
            {
                foreach (Car car in cars)
                {
                    Transaction newTran =  car.ChargeCarParkingFee();
                    transactions.Add(newTran);
                }
            }
        }

        public void AddCar()
        {
            bool balanceValid = false;
            bool carTypeValid = false;
            double balance = 0.0;
            int carTypeChoice = 0;
            Console.WriteLine();
            do
            {
                if (!balanceValid)
                {
                    Console.WriteLine("Please enter car initial balance (0-1000): ");
                    balance = Convert.ToInt32(Console.ReadLine());
                    if (0 <= balance && balance <= 1000)
                    {
                        balanceValid = true;
                    } else
                    {
                        Console.WriteLine("Please enter correct car balance!!!");
                    }
                }
                if (!carTypeValid && balanceValid)
                {
                    Console.WriteLine("Please choose car type: ");
                    Console.WriteLine("1. Passenger.\n2. Truck.\n3. Bus.\n4. Motorcycle.");
                    carTypeChoice = Convert.ToInt32(Console.ReadLine());
                    if (1 <= carTypeChoice && carTypeChoice <= 4) { carTypeValid = true; }
                    else { Console.WriteLine("Please choose correct car type!!!"); }
                }
            } while (!balanceValid || !carTypeValid);
            if(cars.Count >= Settings.ParkingSpace)
            {
                Console.WriteLine("Parking lot is full, please wait for available spot!");
            } else
            {
                Car newCar = new Car((CarType)(carTypeChoice - 1), balance);
                cars.Add(newCar);
                Console.WriteLine("Car added successfully!!!\n\n");
            }            
        }

        public void RemoveCar()
        {
            bool choiceValid = false;
            int carChoice = 0;
            double carCurrentBalance = 0.0;
            do
            {
                ShowCarsList();
                Console.WriteLine("Choose car number from the list above to be removed from parking.");
                carChoice = Convert.ToInt32(Console.ReadLine());
                if (1 <= carChoice && carChoice <= cars.Count) { choiceValid = true; }
                else { Console.WriteLine("Please choose valid car number from list"); }

            } while (!choiceValid);
            carCurrentBalance = cars.ElementAt(carChoice - 1).Balance;
            if(carCurrentBalance <= 0)
            {
                Console.WriteLine("You can not remove this car from parking spot!\nYour balance is negative!\nYou must load your balance first!");
                Console.WriteLine("Your balance is {0}.\n\n", carCurrentBalance);
            } else
            {
                cars.RemoveAt(carChoice - 1);
                Console.WriteLine("Car removed successfully!!!\n\n");
            }            
        }

        public void LoadCarBalance()
        {
            bool carChoiceValid = false;
            int carChoice = 0;
            double amount = 0;
            do
            {
                ShowCarsList();
                Console.WriteLine("Choose car number from the list above to be removed from parking.");
                carChoice = Convert.ToInt32(Console.ReadLine());
                if (1 <= carChoice && carChoice <= cars.Count) {
                    carChoiceValid = true;
                    Console.WriteLine("Please enter amount to load on car number {0}", carChoice);
                    amount = Convert.ToDouble(Console.ReadLine());
                    cars.ElementAt(carChoice - 1).LoadCarBalance(amount);
                }
                else { Console.WriteLine("Please choose valid car number from list"); }

            } while (!carChoiceValid);
        }

        public void ShowTransactionsHistory()
        {
            foreach (Transaction tran in transactions)
            {
                Console.WriteLine(tran);
            }
        }

        public void ShowRecentTransactionHistory()
        {
            
        }

        public void ShowTotalIncome()
        {

        }

        public void ShowVacantSpots()
        {
            Console.WriteLine();
            int currentCarsCount = cars.Count;
            int maxParkingCapacity = Settings.ParkingSpace;
            if(currentCarsCount < maxParkingCapacity)
            {
                Console.WriteLine("{0} out of {1} parking spots are vacant!", maxParkingCapacity - currentCarsCount, maxParkingCapacity);
            } else if (currentCarsCount == maxParkingCapacity)
            {
                Console.WriteLine("Parking lot is full!!!");
            }
            Console.WriteLine();
        }

        public void ShowCarsList()
        {
            Console.WriteLine();
            Console.WriteLine("Cars list: ");
            int counter = 1;
            foreach(Car car in cars)
            {
                Console.WriteLine("{0}. {1}", counter, car);
                counter++;
            }
            Console.WriteLine();
        }
    }
}
