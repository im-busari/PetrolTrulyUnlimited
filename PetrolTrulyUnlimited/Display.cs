using System;
using System.Collections.Generic;
using System.Text;

namespace PetrolTrulyUnlimited
{
	public class Display
	{
		public static void DrawVehicles()
		{
			Vehicle vehicle;

			Console.WriteLine("Vehicles Queue:");

			for (int i = 0; i < PetrolStation.vehicles.Count; i++)
			{
				vehicle = PetrolStation.vehicles[i];
				Console.Write("#{0} ({1}) - Fuel Type: {2} | ", vehicle.id, vehicle.brand, vehicle.fuelType);
			}
		}

		public static void DrawPumps()
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
	}
}
