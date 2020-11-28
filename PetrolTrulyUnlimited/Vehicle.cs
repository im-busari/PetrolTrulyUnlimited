using System;
using System.Collections.Generic;
using System.Text;

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

        //  A random number that we will use when creating a new vehicle to decide fuel type and brand.
        Random rnd = new Random();

        public Vehicle(double fuelTime)
        {
            this._id = _nextID++;
            this._brand = brandsOptions[rnd.Next(brandsOptions.Length)];
            this._fuelType = fuelOptions[rnd.Next(fuelOptions.Length)];
            this._fuelTime = fuelTime;
        }

        public int id { get => this._id; }
        public string brand { get => this._brand; }
        public string fuelType { get => this._fuelType; }
        public double fuelTime { get => this._fuelTime; }
    }
}
