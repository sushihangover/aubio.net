﻿using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Aubio.NET
{
    public abstract class AubioObject : IDisposable
    {
        internal AubioObject()
        {
            // make this public object not inheritable
        }

        private bool IsDisposed { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [PublicAPI]
        [SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
        public virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            DisposeNative();

            if (disposing)
            {
                // nothing
            }

            IsDisposed = true;
        }

        protected abstract void DisposeNative();

        ~AubioObject()
        {
            Dispose(false);
        }

        [PublicAPI]
        protected void ThrowIfDisposed()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(GetType().Name);
        }

        [PublicAPI]
        internal abstract IntPtr ToPointer();
    }
}