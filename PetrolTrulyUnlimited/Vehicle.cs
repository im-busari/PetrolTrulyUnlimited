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

        private string[] brandsOptions = { "Car", "Van", "HGV" };
        private string[] fuelOptions = { "Unleaded", "Diesel", "LPG" };

        Random rnd = new Random();

        public Vehicle(int id)
        {
            this._id = id;
            this._brand = brandsOptions[rnd.Next(brandsOptions.Length)];
            this._fuelType = fuelOptions[rnd.Next(fuelOptions.Length)];
        }

        public int id { get => this._id; }
        public string brand { get => this._brand; }
        public string fuelType { get => this._fuelType; }
    }
}
