using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Division42.Data.Repository;

namespace Division42.Data.ViewModels
{
    public abstract class ViewModelBase<TEntity>
        where TEntity : class, new()
    {
        public IRepository<TEntity> Repository { get; protected set; }

        protected ViewModelBase(IRepository<TEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Repository = repository;
            Entities = new ObservableCollection<TEntity>();
        }

        public ICommand Refresh
        {
            get
            {
                if (_refresh == null)
                    _refresh = new ViewModelRefresher<TEntity>(this.Entities, Repository);

                return _refresh;
            }
            protected set { _refresh = value; }
        } private ICommand _refresh = null;

        public ObservableCollection<TEntity> Entities { get; protected set; }
    }
}