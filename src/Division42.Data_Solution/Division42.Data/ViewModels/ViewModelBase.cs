using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Division42.Data.Repository;

namespace Division42.Data.ViewModels
{
    /// <summary>
    /// Abstract base implementation of a ViewModel which provides some common features.
    /// </summary>
    /// <typeparam name="TEntity">The primary data structure type on which this ViewModel operates.</typeparam>
    public abstract class ViewModelBase<TEntity> : DisposableBase
        where TEntity : class, new()
    {
        /// <summary>
        /// Gets the current repository.
        /// </summary>
        public IRepository<TEntity> Repository { get; protected set; }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="repository">The repository to use for the primary data type.</param>
        protected ViewModelBase(IRepository<TEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
            Entities = new ObservableCollection<TEntity>();
        }

        /// <summary>
        /// Refresh command for use with MVVM/WPF/XAML.
        /// </summary>
        public ICommand Refresh
        {
            get
            {
                if (_refresh == null)
                    _refresh = new ViewModelRefresher<TEntity>(this.Entities, Repository);

                return _refresh;
            }
        } private ICommand _refresh = null;

        /// <summary>
        /// Gets the observable collection of the primary entities.
        /// </summary>
        public ObservableCollection<TEntity> Entities { get; protected set; }

        /// <summary>
        /// When overridden in a sub-class, closes instance-specific resources 
        /// before the object is sent to garbage collection.
        /// </summary>
        /// <param name="isDisposing">True if being called from the public 
        /// <see cref="DisposableBase.Dispose"/> method.</param>
        protected override void Dispose(bool isDisposing)
        {
            if (Repository != null)
            {
                Repository.Dispose();
                Repository = null;
            }

            base.Dispose(isDisposing);
        }
    }
}