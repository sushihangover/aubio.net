using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Aubio.NET
{
	[PublicAPI]
	public static class AubioUtils
	{
		[PublicAPI]
		public const string DllName = "libaubio.dll";

		public static void Cleanup()
		{
			aubio_cleanup();
		}

		[DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void aubio_cleanup();
	}
}