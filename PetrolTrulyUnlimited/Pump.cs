using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace PetrolTrulyUnlimited
{
    class Pump
    {
        private int _id;
        private int _totalLitresDispensed; // 1.5 litres/second
        private int _vehicles;
        private int _comission;
        public bool isAvailable = true;

        Random rand = new Random();


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

        public void fillingVehicle(Vehicle vehicle)
        {
            int time = rand.Next(17000, 19000);
            Timer fillingTimer = new Timer(time);
            fillingTimer.Elapsed += OnTimedEvent;
            fillingTimer.Enabled = true;
            fillingTimer.AutoReset = false;
            fillingTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this._vehicles += 1;
            Console.WriteLine(this._vehicles);
        }
    }
}
