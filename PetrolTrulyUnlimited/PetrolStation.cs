using System;
using System.Collections.Generic;
using System.Timers;

namespace PetrolTrulyUnlimited
{
    class PetrolStation
    {
        private static Timer timer;
        public static List<Vehicle> vehicles;
        public static List<Pump> pumps;
        
        public static Random rnd = new Random();

        //  Create/Initialize Petrol Station Unlimited.
        public static void createStation()
        {
            createPumps();
            createVehiclesQueue();
        }

        //  Create new vehicle every 1500-2200 milisecounds 
        private static void createVehiclesQueue()
        {
            vehicles = new List<Vehicle>();

            timer = new Timer();
            timer.Interval = 1500;
            timer.AutoReset = true;
            timer.Elapsed += createVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        private static void createVehicle(object sender, ElapsedEventArgs e)
        {
            // Fueltime is a random number between 17000 and 19000 miliseconds. 
            Vehicle v = new Vehicle(rnd.Next(17000, 19000));
            vehicles.Add(v);
        }
        private static void createPumps()
        {
            pumps = new List<Pump>();

            Pump p;

            for (int i = 0; i < 9; i++)
            {
                p = new Pump("diesel");
                pumps.Add(p);
            }
        }
        public static void AssignVehicleToPump()
        {
            Vehicle v;
            Pump p;

            if (vehicles.Count == 0) { return; }

            for (int i = 0; i < 9; i++)
            {
                p = pumps[i];

                // note: needs more logic here, don't just assign to first
                // available pump, but check for the last available pump
                if (p.isAvailable())
                {
                    v = vehicles[0]; // get first vehicle
                    vehicles.RemoveAt(0); // remove vehicles from queue
                    p.AssignVehicle(v); // assign it to the pump
                }

                if (vehicles.Count == 0) { break; }

            }
        }
    }
}
