using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace ChickenBuddy
{
	[StandardModule]
	internal sealed class MemoryReading
	{
		[DllImport("kernel32.dll")]
		public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, ref uint lpNumberOfBytesWritten);

		[DllImport("kernel32.dll")]
		private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, IntPtr nSize, out IntPtr lpNumberOfBytesWritten);

		public static byte[] ReadProcessMemory(IntPtr adresse, IntPtr handle)
		{
			byte[] array = new byte[33];
			uint lpNumberOfBytesWritten = 0u;
			ReadProcessMemory(handle, adresse, array, array.Length, ref lpNumberOfBytesWritten);
			return array;
		}

		public static void WriteProcessMemory(IntPtr adresse, IntPtr handle, byte[] input)
		{
			int num = 0;
			IntPtr nSize = (IntPtr)input.Length;
			IntPtr lpNumberOfBytesWritten = (IntPtr)num;
			WriteProcessMemory(handle, adresse, input, nSize, out lpNumberOfBytesWritten);
			num = (int)lpNumberOfBytesWritten;
		}

		public static IntPtr getModuleBase(string modulename, Process derprozess)
		{
			IEnumerator enumerator = default(IEnumerator);
			try
			{
				enumerator = derprozess.Modules.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ProcessModule processModule = (ProcessModule)enumerator.Current;
					if (processModule.FileName.IndexOf(modulename) != -1)
					{
						return processModule.BaseAddress;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return (IntPtr)0;
		}
	}
}
