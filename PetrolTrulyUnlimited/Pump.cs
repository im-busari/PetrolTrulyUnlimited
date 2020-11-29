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

        public void assignVehicle(Vehicle v)
        {
            currentVehicle = v;
            v.fuelling = true;  // update vehicle fuelling status
            this._totalLitresDispensed = 1.5 * (v.fuelTime / 1000);

            Timer timer = new Timer();
            timer.Interval = v.fuelTime;
            timer.AutoReset = false; // don't repeat
            timer.Elapsed += (sender, e) => { releaseVehicle(); };
            timer.Enabled = true;
            timer.Start();
        }

        public void releaseVehicle()
        {
            // record transaction, update the counters for the dispensed liters, and remove car from pump
            Receipt receipt = new Receipt(currentVehicle, this._totalLitresDispensed, this._id);
            PetrolStation.storeReceipts(receipt);
            PetrolStation.servicedVehiclesCounter++;
            PetrolStation.updateLitersCounters(currentVehicle, this._totalLitresDispensed);
            currentVehicle = null;
        }
    }
}