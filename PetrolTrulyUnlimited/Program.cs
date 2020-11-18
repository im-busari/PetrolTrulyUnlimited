using System;
using System.Timers;

namespace PetrolTrulyUnlimited
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Timer vehicleTimer = new Timer();


            Pump pump1 = new Pump(1);
            pump1.addReceipt();


            for (int i = 0; i < 5; i++)
            {
                Vehicle v1 = new Vehicle(i);
                Console.WriteLine("Car1: {0}.{1}.{2}", v1.id, v1.brand, v1.fuelType);
            }

            Console.ReadLine();
        }
    }
}
