﻿using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Aubio.NET.Utilities
{
    /// <summary>
    ///     https://aubio.org/doc/latest/log_8h.html
    /// </summary>
    [PublicAPI]
    public static class Log
    {
        #region Public Members
		[PublicAPI]
		public const string DllName = "libaubio.dll";

        public static void Reset()
        {
            aubio_log_reset();
        }

        public static void SetFunction([NotNull] LogFunction function, IntPtr data)
        {
            if (function == null)
                throw new ArgumentNullException(nameof(function));

            aubio_log_set_function(function, data);
        }

        public static LogFunction SetLevelFunction(LogLevel level, [NotNull] LogFunction function, IntPtr data)
        {
            if (function == null)
                throw new ArgumentNullException(nameof(function));

            var previous = aubio_log_set_level_function(level, function, data);

            return previous;
        }

        #endregion

        #region Native Methods

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void aubio_log_reset(
        );

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void aubio_log_set_function(
            [MarshalAs(UnmanagedType.FunctionPtr)] LogFunction function,
            IntPtr data
        );

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        private static extern LogFunction aubio_log_set_level_function(
            LogLevel level,
            LogFunction function,
            IntPtr handle
        );

        #endregion
    }
}