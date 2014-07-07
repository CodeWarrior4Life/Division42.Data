using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Division42.Data.Repository;

namespace Division42.Data.ViewModels
{
    /// <summary>
    /// Class to refresh a ViewModel observable property from an underlying repository.
    /// </summary>
    /// <typeparam name="TEntity">The data type on which the observable collection operates.</typeparam>
    public class ViewModelRefresher<TEntity> : ICommand where TEntity : class, new()
    {
        /// <summary>
        /// Gets the collection in the ViewModel to refresh.
        /// </summary>
        public ObservableCollection<TEntity> CollectionToRefresh { get; protected set; }
        
        /// <summary>
        /// Gets the repository that is to be used to refresh the observable collection.
        /// </summary>
        public IRepository<TEntity> Repository { get; protected set; }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="collectionToRefresh">The ViewModel observable collection to refresh.</param>
        /// <param name="repository">The repository to use to refresh the collection.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ViewModelRefresher(ObservableCollection<TEntity> collectionToRefresh, 
            IRepository<TEntity> repository)
        {
            if (collectionToRefresh == null)
                throw new ArgumentNullException("collectionToRefresh");
            if (repository == null)
                throw new ArgumentNullException("repository");

            CollectionToRefresh = collectionToRefresh;
            Repository = repository;
        }

        /// <summary>
        /// Determines if the current command can execute or not, given the 
        /// specified <paramref name="parameter"/>.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Boolean CanExecute(Object parameter)
        {
            return _canExecute;
        }

        /// <summary>
        /// Executes the current command with the specified <paramref name="parameter"/>.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(Object parameter)
        {
            _canExecute = false;
            NotifyCanExecuteChanged();

            IEnumerable<TEntity> entitiesFromDataStore = Repository.GetAll().ToList();

            // Add missing items found in the data store
            foreach (TEntity item in entitiesFromDataStore)
            {
                if (!CollectionToRefresh.Contains(item))
                    CollectionToRefresh.Add(item);
            }

            // Remove items no longer in the data store.
            for (Int32 index = CollectionToRefresh.Count-1; index >= 0; index--)
            {
                if (!entitiesFromDataStore.Contains(CollectionToRefresh[index]))
                    CollectionToRefresh.RemoveAt(index);
            }

            _canExecute = true;
            NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Event for when the state changes, and the current command can or cannot be executed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event to notify observers 
        /// that the state has changed.
        /// </summary>
        protected void NotifyCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        /// <summary>
        /// Private field to store the state of whether this command can execute or not.
        /// </summary>
        private Boolean _canExecute = true;
    }
}