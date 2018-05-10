using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA18_hw2_Dushkevych
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            try
            {
                menu.MainMenu();
            }
            catch (FormatException fex)
            {
                Console.WriteLine("Please enter optional sign followed by a sequence of digits (0 through 9)");
            }
            catch (OverflowException oex)
            {
                Console.WriteLine("Entered value represents a number that is less than Int32.MinValue or greater than Int32.MaxValue.");
            }
            catch (IOException ioex)
            {
                Console.WriteLine("An I/O error occurred.");
            }
            catch (OutOfMemoryException oomex)
            {
                Console.WriteLine("There is insufficient memory to allocate a buffer for the returned string.");
            }
            catch (ArgumentOutOfRangeException aoorex)
            {
                Console.WriteLine("The number of characters in the next line of characters is greater than Int32.MaxValue.");
            }
        }
    }
}
