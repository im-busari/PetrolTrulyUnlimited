﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetrolTrulyUnlimited
{
	public class Display
	{
		public static void showCounters()
        {
			Console.WriteLine("Diesel: {0:N2} L | LPG: {1:N2} L | Unleaded: {2:N2} L | Other: {3:N2} L", 
				PetrolStation.dieselLitersCounter, PetrolStation.lpgLitersCounter,
				PetrolStation.unleadedLitersCounter, PetrolStation.unknownLitersCounter);

			Console.WriteLine("Served vehicles: {0}", PetrolStation.servicedVehiclesCounter);
			Console.WriteLine("Vehicles that left: {0}", PetrolStation.leftVehiclesCounter);
		}
		public static void showVehicles()
		{
			Vehicle vehicle;

			Console.WriteLine("Vehicles Queue:");

			for (int i = 0; i < PetrolStation.vehicles.Count; i++)
			{
				vehicle = PetrolStation.vehicles[i];
				Console.Write("#{0} ({1}) - Fuel Type: {2} | ", vehicle.id, vehicle.brand, vehicle.fuelType);
			}
		}

		public static void showPumps()
		{
			Pump pump;

			Console.WriteLine("Pumps Status:");

			for (int i = 0; i < 9; i++)
			{
				pump = PetrolStation.pumps[i];

				Console.Write("#{0} ", i + 1);
				if (pump.isAvailable()) { Console.Write("FREE"); }
				else { Console.Write("BUSY"); }
				Console.Write(" | ");

				// modulus -> remainder of a division operation
				// 0 % 3 => 0 (0 / 3 = 0 R=0)
				// 1 % 3 => 1 (1 / 3 = 0 R=1)
				// 2 % 3 => 2 (2 / 3 = 0 R=2)
				// 3 % 3 => 0 (3 / 3 = 1 R=0)
				// 4 % 3 => 1 (4 / 3 = 1 R=1)
				// 5 % 3 => 2 (5 / 3 = 1 R=2)
				// 6 % 3 => 0 (6 / 3 = 2 R=0)
				// ...
				if (i % 3 == 2) { Console.WriteLine(); }
			}
		}

		public static void showReceipts()
        {
			Receipt receipt;

			Console.WriteLine("Receipts: ");

			for (int i = 0; i < PetrolStation.receipts.Count; i++)
			{
				receipt = PetrolStation.receipts[i];
				Console.Write("Vehicle Brand: {0}, Litres: {1:N2}, Pump No: {2}	| ", receipt.vehicleBrand, receipt.litres, receipt.pumpId);
			}
		}
	}
}
