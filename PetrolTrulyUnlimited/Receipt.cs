using System;
using System.Collections.Generic;
using System.Text;

namespace PetrolTrulyUnlimited
{
    //  Receipt = fuelling transaction
    class Receipt
    {
        private int nextReceiptId = 0;
        private string _vehicleBrand;
        private double _litres;
        private int _pumpId;

        public Receipt(Vehicle vehicle, double litres, int pumpId)
        {
            this._vehicleBrand = vehicle.brand;
            this._litres = litres;
            this._pumpId = pumpId;
        }


        public string vehicleBrand { get => this._vehicleBrand; }
        public double litres { get => this._litres; }
        public int pumpId { get => this._pumpId; }
    }
}
