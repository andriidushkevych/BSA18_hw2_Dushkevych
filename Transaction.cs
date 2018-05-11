using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA18_hw2_Dushkevych
{
    public class Transaction
    {
        private DateTime dateTime;
        private int carId;
        private double chargedAmount;

        public Transaction(int carIdArg, double chargedAmountArg)
        {
            dateTime = DateTime.Now;
            carId = carIdArg;
            chargedAmount = chargedAmountArg;
        }

        public override string ToString()
        {
            return "Time of transaction: " + dateTime + "   CarId charged: " + carId + "  ChargedAmount : " + chargedAmount;
        }
    }
}
