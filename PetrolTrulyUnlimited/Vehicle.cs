using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace PetrolTrulyUnlimited
{
    class Vehicle
    {
        private int _id;
        private string _brand;
        private string _fuelType;
        private static int _nextID = 0; // to ensure we will not have 2 cars with the same IDs.
        private double _fuelTime;

        private string[] brandsOptions = { "Car", "Van", "HGV" };
        private string[] fuelOptions = { "Unleaded", "Diesel", "LPG" };

        public bool fuelling = false;

        //  A random number that we will use when creating a new vehicle to decide fuel type and brand.
        Random rnd = new Random();

        //  If a vehicle is not served within 1500 miliseconds it will leave the queue.
        //  We should keep a track of how many clients/vehicles have we lost.
        public Vehicle(double fuelTime)
        {
            this._id = _nextID++;
            this._brand = brandsOptions[rnd.Next(brandsOptions.Length)];
            this._fuelType = fuelOptions[rnd.Next(fuelOptions.Length)];
            this._fuelTime = fuelTime;

            startCountdown();
        }

        private void startCountdown()
        {
            Timer timer = new Timer();
            timer.Interval = rnd.Next(1000, 2000);
            timer.AutoReset = false; // don't repeat
            timer.Elapsed += leaveQueue;
            timer.Enabled = true;
            timer.Start();
        }

        public void leaveQueue(object sender, ElapsedEventArgs e)
        {
            //  Check if the vehicle is still waiting
            if(!this.fuelling)
            {
                PetrolStation.vehicles.RemoveAll(x => x.id == this._id);
                PetrolStation.leftVehiclesCounter++;
            }
        }

        public int id { get => this._id; }
        public string brand { get => this._brand; }
        public string fuelType { get => this._fuelType; }
        public double fuelTime { get => this._fuelTime; }
    }
}
