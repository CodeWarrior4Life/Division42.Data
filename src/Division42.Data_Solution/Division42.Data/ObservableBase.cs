using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Division42.Data
{
    /// <summary>
    /// Abstract base implementation of <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public abstract class ObservableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event for the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        /// <exception cref="ArgumentException"></exception>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            // Don't check for String.IsNullOrEmpty, because an empty property is populate by CallerMemberName.

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}