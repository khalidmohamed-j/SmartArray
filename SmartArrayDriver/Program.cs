using System;

namespace Mod01SmartArray
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartArray mySmartArray = new SmartArray(5, true);
            mySmartArray.SetAtIndex(0, 22);
            mySmartArray.SetAtIndex(3, 222);
            mySmartArray.PrintAllElements();
            Console.WriteLine($"\nValue 222 found at position {mySmartArray.Find(222)}");

            Console.WriteLine($"\nThe value at index 3 is {mySmartArray.GetAtIndex(3)}");

            mySmartArray.Resize(10);
            mySmartArray.SetAtIndex(7, 65535);

            //will cause an IndexOutOfRange exception
            mySmartArray.SetAtIndex(9, 65535);

            //the length of the array will be increased to 10 (5*2) and value 65535 will be placed in the seventh slot
            //SmartArray my2SmartArray = new SmartArray(5, true);
            mySmartArray.SetAtIndex(6, 65535);


            //will increase the length to accommodate the requested index, 25
            mySmartArray.SetAtIndex(5, 65535);
            mySmartArray.SetAtIndex(4, 65535);
            mySmartArray.SetAtIndex(11, 65535);
            mySmartArray.SetAtIndex(12, 65535);


            mySmartArray.Resize(5,false);

            mySmartArray.PrintAllElements();


            Console.WriteLine("\nFinito!");

        }
    }

}
