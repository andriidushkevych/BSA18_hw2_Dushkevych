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
        private int id;
        private double balance;
        private CarType carType;
    }
}
