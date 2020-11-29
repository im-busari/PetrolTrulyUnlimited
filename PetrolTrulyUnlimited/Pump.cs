using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace PetrolTrulyUnlimited
{
    class Pump
    {
        private int _id;
        private double _totalLitresDispensed;  // Seperate for each fuel type --> make an array
        private double _comission;

        public Vehicle currentVehicle = null;

        Random rand = new Random();


        //  All pumps contain all types of fuel.
        public Pump(int id)
        {
            this._id = id + 1;
            this._totalLitresDispensed = 0;
            this._comission = 0;
        }

        public bool isAvailable()
        {
            // returns TRUE if currentVehicle is NULL, meaning available
            // returns FALSE if currentVehicle is NOT NULL, meaning busy
            return currentVehicle == null;
        }

        public void assignVehicle(Vehicle v, ref double litresCounter)
        {
            currentVehicle = v;
            this._totalLitresDispensed = 1.5 * (v.fuelTime / 1000);
            litresCounter += this._totalLitresDispensed;

            Timer timer = new Timer();
            timer.Interval = v.fuelTime;
            timer.AutoReset = false; // don't repeat
            timer.Elapsed += releaseVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        public void releaseVehicle(object sender, ElapsedEventArgs e)
        {
            // record transaction
            Receipt receipt = new Receipt(currentVehicle, this._totalLitresDispensed, this._id);
            PetrolStation.storeReceipts(receipt);
            currentVehicle = null;
        }
    }
}