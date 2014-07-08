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
            if (String.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Argument \"propertyName\" cannot be null or empty.", "propertyName");

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}