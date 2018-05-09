using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA18_hw2_Dushkevych
{
    public static class Settings
    {
        private static Dictionary<CarType, int> parkingPrice = new Dictionary<CarType, int>()
        {
            { CarType.Passenger, 3 },
            { CarType.Truck, 5 },
            { CarType.Bus, 2 },
            { CarType.Motorcycle, 1 }
        };

        public static int Timeout {
            get {
                return 3;
            }
        }
        public static Dictionary<CarType, int> ParkingPrice
        {
            get
            {
                return parkingPrice;
            }
        }
        public static int ParkingSpace {
            get {
                return 15;
            }
        }
        public static float Fine {
            get {
                return 1.5f;
            }
        }
    }
}
