using System;
using System.Collections.Generic;
using System.Text;

namespace PetrolTrulyUnlimited
{
    class Pump
    {
        private int _id;
        private int _totalLitresDispensed;
        private int _vehicles;
        private int _comission;
        public bool isAvailable = true;


        public Pump(int id)
        {
            this._id = id;
            this._totalLitresDispensed = 0;
            this._vehicles = 0;
            this._comission = 0;
        }

        public void addReceipt()
        {
            Console.WriteLine("[Vehicle type, Number of litres and Pump number]");
        }
    }
}
