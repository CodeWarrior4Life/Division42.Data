using System;

namespace Division42.Data
{
    /// <summary>
    /// Abstract implementation which helps execute disposable behavior.
    /// </summary>
    public abstract class DisposableBase : IDisposable
    {
        /// <summary>
        /// Disposes of the current instance by cleaning up and closing 
        /// open resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// When overridden in a sub-class, closes instance-specific resources 
        /// before the object is sent to garbage collection.
        /// </summary>
        /// <param name="isDisposing">True if being called from the public 
        /// <see cref="Dispose"/> method.</param>
        protected virtual void Dispose(Boolean isDisposing)
        {
            _isDisposed = true;
        }

        /// <summary>
        /// Checks if the current instance is disposed. If it is, 
        /// an <see cref="ObjectDisposedException"/> is thrown.
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        protected void CheckIfDisposed()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(this.GetType().ToString());
        }

        /// <summary>
        /// Field to hold whether the current object is currently disposed.
        /// </summary>
        private Boolean _isDisposed = false;
    }
}
