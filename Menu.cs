using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA18_hw2_Dushkevych
{
    class Menu
    {
        public void MainMenu()
        {
            int menuChoice = 0;
            do
            {
                menuChoice = ShowMenu();
                if(menuChoice != 0)
                {
                    ProcessMenuChoice(menuChoice);
                }
            } while (menuChoice != 0);
            
        }

        private int ShowMenu()
        {
            int choice = 0;
            Console.WriteLine("Parking menu:");
            Console.WriteLine("1. Add/Remove car.");
            Console.WriteLine("2. Load car balance.");
            Console.WriteLine("3. Show car list.");
            Console.WriteLine("4. Show recent transaction history(1 minute).");
            Console.WriteLine("5. Total parking income.");
            Console.WriteLine("6. Parking vacant spots.");
            Console.WriteLine("7. Show transaction history.");
            Console.WriteLine("0. Exit.");
            
            choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        private void ProcessMenuChoice(int menuChoice)
        {
            switch(menuChoice)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Please choose:");
                    Console.WriteLine("1. Add car.\n2. Remove car.");
                    int addRemoveFlag = Convert.ToInt32(Console.ReadLine());
                    if(addRemoveFlag == 1)
                    {
                        Parking.ParkingInstance.AddCar();
                        Parking.ParkingInstance.ShowCarsList();
                    } else if (addRemoveFlag == 2)
                    {
                        Parking.ParkingInstance.RemoveCar();
                        Parking.ParkingInstance.ShowCarsList();
                    }
                    break;
                case 2:
                    Console.WriteLine("Load car balance:");
                    Parking.ParkingInstance.LoadCarBalance();
                    break;
                case 3:
                    Console.WriteLine("Show car list:");
                    Parking.ParkingInstance.ShowCarsList();
                    break;
                case 4:
                    Console.WriteLine("Show recent transaction history:");
                    Parking.ParkingInstance.ShowRecentTransactionHistory();
                    break;
                case 5:
                    Console.WriteLine("Total parking income:");
                    Parking.ParkingInstance.ShowTotalIncome();
                    break;
                case 6:
                    Console.WriteLine("Parking vacant spots:");
                    Parking.ParkingInstance.ShowVacantSpots();
                    break;
                case 7:
                    Console.WriteLine("Transaction history: ");
                    Parking.ParkingInstance.ShowTransactionsHistory();
                    break;
            }            
        }

    }
}
