using System;
using System.Timers;

namespace PetrolTrulyUnlimited
{
    class Program
    {

        static void Main(string[] args)
        {
            PetrolStation.createStation();

            Timer timer = new Timer();
            timer.Interval = 2050;
            timer.AutoReset = true; //  every 2 seconds update console view/display
            timer.Elapsed += RunProgramLoop;
            timer.Enabled = true;
            timer.Start();

            Console.ReadLine();
        }

        //  
        static void RunProgramLoop(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine();
            Display.showCounters();
            Console.WriteLine();
            Console.WriteLine();
            Display.showVehicles();
            Console.WriteLine();
            Console.WriteLine();
            Display.showPumps();
            Console.WriteLine();
            Console.WriteLine();
            Display.showReceipts();
            PetrolStation.assignVehicleToPump();
        }
    }
}
