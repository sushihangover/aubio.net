﻿using System.Diagnostics.CodeAnalysis;

namespace Aubio.NET.Vectors
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal unsafe struct LVec__
    {
#pragma warning disable 649
        public readonly uint Length;
#pragma warning disable 169
        public readonly double* Data;
#pragma warning restore 169
#pragma warning restore 649
    }
}