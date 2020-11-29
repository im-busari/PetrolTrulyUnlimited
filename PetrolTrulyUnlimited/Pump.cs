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
        private double _totalLitresDispensed;
        private double _comission;

        public Vehicle currentVehicle = null;
        public string fuelType;

        Random rand = new Random();


        public Pump(string fuelType)
        {
            this._id = pumpsCounter++;
            this._totalLitresDispensed = 0;
            this._comission = 0;
            this.fuelType = fuelType;
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
        public void AssignVehicle(Vehicle v)
        {
            currentVehicle = v;
            this._totalLitresDispensed += 1.5 * v.fuelTime;

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