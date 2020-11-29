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

        //  Counters for the total amount of litres dispensed from all pumps on the station
        public static double dieselLitersCounter = 0;  // 2.53 pounds per liter
        public static double unleadedLitersCounter = 0;  // 2.10 pounds per liter
        public static double lpgLitersCounter = 0; //  2.00 pounds per liter
        public static double unknownLitersCounter = 0;  //  1.50 pounds per liter 

        public static int servicedVehiclesCounter = 0;
        public static int leftVehiclesCounter = 0;

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
            timer.Interval = rnd.Next(1500, 2200);
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

            Pump pump;

            for (int i = 0; i < 9; i++)
            {
                pump = new Pump();
                pumps.Add(pump);
            }
        }
        public static void AssignVehicleToPump()
        {
            Vehicle vehicle;
            Pump pump;

            if (vehicles.Count == 0) { return; }

            for (int i = 0; i < 9; i++)
            {
                pump = pumps[i];

                if (pump.isAvailable())
                {
                    vehicle = vehicles[0]; // get first vehicle
                    vehicles.RemoveAt(0); // remove vehicles from queue

                    // assign it to the pump with the relevant counter reference
                    switch (vehicle.fuelType)
                    {
                        case "Unleaded":
                            pump.AssignVehicle(vehicle, ref unleadedLitersCounter);
                            break;
                        case "Diesel":
                            pump.AssignVehicle(vehicle, ref dieselLitersCounter);
                            break;
                        case "LPG":
                            pump.AssignVehicle(vehicle, ref lpgLitersCounter);
                            break;
                        default:
                            pump.AssignVehicle(vehicle, ref unknownLitersCounter);
                            break;
                    }
                }

                if (vehicles.Count == 0) { break; }

            }
        }
    }
}
