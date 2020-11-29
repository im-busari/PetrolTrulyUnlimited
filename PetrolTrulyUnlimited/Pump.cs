using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace PetrolTrulyUnlimited
{
    class Pump
    {
        private int _id;
        private int pumpsCounter = 0;
        private double _totalLitresDispensed;  // Seperate for each fuel type --> make an array
        private double _comission;

        public Vehicle currentVehicle = null;

        Random rand = new Random();


        //  All pumps contain all types of fuel.
        public Pump()
        {
            this._id = pumpsCounter++;
            this._totalLitresDispensed = 0;
            this._comission = 0;
        }

        public void addReceipt()
        {
            Console.WriteLine("[Vehicle type, Number of litres and Pump number]");
        }

        public bool isAvailable()
        {
            // returns TRUE if currentVehicle is NULL, meaning available
            // returns FALSE if currentVehicle is NOT NULL, meaning busy
            return currentVehicle == null;
        }

        //  TODO: I can use reference variable to keep a track on the totalLitresDispensed from all of the pumps
        public void AssignVehicle(Vehicle v, ref double litresCounter)
        {
            currentVehicle = v;
            litresCounter += 1.5 * v.fuelTime;

            Timer timer = new Timer();
            timer.Interval = v.fuelTime;
            timer.AutoReset = false; // don't repeat
            timer.Elapsed += releaseVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        public void releaseVehicle(object sender, ElapsedEventArgs e)
        {
            currentVehicle = null;
            // record transaction
        }
    }
}