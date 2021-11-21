using System;
using System.Diagnostics;

namespace ChickenBuddy
{
	public class GameData
	{
		private Process gameProcess;

		public int mapSeed;

		public IntPtr fullStatsObject;

		private IntPtr baseAdress;

		public GameData(Process d2process)
		{
			mapSeed = 0;
			fullStatsObject = default(IntPtr);
			baseAdress = default(IntPtr);
			gameProcess = d2process;
			getBasicGameData();
		}

		public object getStatValue(int valueId)
		{
			int num = 0;
			int num2 = 0;
			string text = "";
			int num3 = 0;
			int num4 = 0;
			checked
			{
				do
				{
					num2 = BitConverter.ToInt16(MemoryReading.ReadProcessMemory(IntPtr.Add(fullStatsObject, num4 + 2), gameProcess.Handle), 0);
					text = Enum.GetName(typeof(Stats.Stat), num2);
					num3 = ((!unchecked(num2 == 6 || num2 == 7)) ? BitConverter.ToInt32(MemoryReading.ReadProcessMemory(IntPtr.Add(fullStatsObject, num4 + 4), gameProcess.Handle), 0) : BitConverter.ToInt32(MemoryReading.ReadProcessMemory(IntPtr.Add(fullStatsObject, num4 + 4 + 1), gameProcess.Handle), 0));
					if (num2 == valueId)
					{
						return num3;
					}
					num4 += 8;
				}
				while (num4 != 1000);
				return null;
			}
		}

		private void getBasicGameData()
		{
			baseAdress = MemoryReading.getModuleBase("D2R.exe", gameProcess);
			IntPtr pointer = IntPtr.Add(baseAdress, Offsets.playerUnit);
			IntPtr intPtr = default(IntPtr);
			IntPtr intPtr2 = default(IntPtr);
			IntPtr intPtr3 = default(IntPtr);
			IntPtr intPtr4 = default(IntPtr);
			IntPtr intPtr5 = default(IntPtr);
			IntPtr intPtr6 = default(IntPtr);
			IntPtr intPtr7 = default(IntPtr);
			IntPtr intPtr8 = default(IntPtr);
			IntPtr intPtr9 = default(IntPtr);
			IntPtr intPtr10 = default(IntPtr);
			IntPtr intPtr11 = default(IntPtr);
			IntPtr intPtr12 = default(IntPtr);
			IntPtr intPtr13 = default(IntPtr);
			IntPtr intPtr14 = default(IntPtr);
			IntPtr intPtr15 = default(IntPtr);
			IntPtr intPtr16 = default(IntPtr);
			IntPtr intPtr17 = default(IntPtr);
			int num = 0;
			checked
			{
				do
				{
					IntPtr adresse = IntPtr.Add(pointer, num * 8);
					byte[] value = MemoryReading.ReadProcessMemory(adresse, gameProcess.Handle);
					if (BitConverter.ToInt64(value, 0) != 0)
					{
						intPtr10 = (IntPtr)BitConverter.ToInt64(value, 0);
						IntPtr intPtr18 = (IntPtr)BitConverter.ToInt32(MemoryReading.ReadProcessMemory(intPtr10 + 0, gameProcess.Handle), 0);
						IntPtr intPtr19 = (IntPtr)BitConverter.ToInt32(MemoryReading.ReadProcessMemory(intPtr10 + 4, gameProcess.Handle), 0);
						IntPtr intPtr20 = (IntPtr)BitConverter.ToInt32(MemoryReading.ReadProcessMemory(intPtr10 + 8, gameProcess.Handle), 0);
						if ((intPtr18 == (IntPtr)0) & (intPtr19 == (IntPtr)1))
						{
							intPtr2 = IntPtr.Add(intPtr10, 32);
							intPtr12 = (IntPtr)BitConverter.ToInt64(MemoryReading.ReadProcessMemory(intPtr2, gameProcess.Handle), 0);
							mapSeed = BitConverter.ToInt32(MemoryReading.ReadProcessMemory(IntPtr.Add(intPtr12, 20), gameProcess.Handle), 0);
							if (mapSeed > 100000)
							{
								Offsets.playerUnitDecryptOffset = num * 8;
								break;
							}
						}
					}
					num++;
				}
				while (num <= 640);
				IntPtr adresse2 = IntPtr.Add(intPtr10, 136);
				IntPtr pointer2 = (IntPtr)BitConverter.ToInt64(MemoryReading.ReadProcessMemory(adresse2, gameProcess.Handle), 0);
				IntPtr adresse3 = IntPtr.Add(pointer2, 128);
				fullStatsObject = (IntPtr)BitConverter.ToInt64(MemoryReading.ReadProcessMemory(adresse3, gameProcess.Handle), 0);
			}
		}
	}
}
