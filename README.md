Division42.Data
===============
.NET portable class library (PCL) for managing SQLite and other data access across multiple platforms, including Xamarin support.

##What is this?
This is the Visual Studio 2013 / C# / Portable Class Library source code for the "Division42.Data - PCL" NuGet package found [here](http://todo).

##What does it do?
This is a library which wraps the [SQLite.NET PCL](https://www.nuget.org/packages/SQLite.Net-PCL/) functionality with the [Repository Pattern](http://www.remondo.net/repository-pattern-example-csharp/). There are also helpers for working with MVVM, such as an `ICommand` class which refreshes `ObservableCollection<T>`

>The intent is that if you want to put all of your data access for *all* platforms (Win8 Store, WP8, Android, iOS, etc) into a PCL, using this library along with the SQLite library we reference, you can do this very easily: having ORM-type access to data, and being MVVM-friendly.

##Background
Since Xamarin 3 came out, we looked at ways to simplify the way to write cross-platform applications. Once you use Xamarin and Mono to get your projects set up, probably one of the very next problems is: data.

How do I store my application data? Do I serialize it to XML or binary? Do I work entirely with a web service (sorry end-users, about your mobile data plan!) Can I use a database?

Since SQLite is the universal answer for a relational database, we next found that the world of SQLite is dark and dismal one. There are close to 19 bajillion different versions, off-shoots, add-ons, and custom frameworks written for it. And yes, the irony is not lost that this is yet ANOTHER one.

But wait, this is different. This library is meant to be a complete solution for this problem. This library, plus the SQLite PCL library adds significant data management functionality for your app.

##Goals
The goals for this project came about directly from the need.

* Be able to simply and easily: **c**reate, **r**ead, **u**pdate, and **d**elete data from a SQLite database, from any platform (Win8, WP8, Android, iOS, etc)
* Ideally, put all or almost all of that code into a PCL so that code exists in one place for all platforms.
* Include common features (especially MVVM) which are common to all/many platforms.

##Usage
There are arguably six (6) features which you can use from this library, as of this writing:

1. A generic repository `IRepository<T>` which you can use with your own data access. 
```C#
public interface IRepository<TEntity> : IDisposable
        where TEntity : class, new()
{
    IEnumerable<TEntity> GetAll();
    TEntity GetById(Guid id);
    TEntity GetByFilter(Expression<Func<TEntity, Boolean>> whereClause);
    void Insert(TEntity instance);
    void Update(TEntity instance);
    void Delete(TEntity instance);
}
```
2. A SQLite repository which gives you Insert, Delete, GetAll, Update type functionality. To get all the features for your entity/table in your SQLite database, simply inherit from this base class: 
```C#
    public class CustomerSqliteRepository : SqliteRepositoryBase<Customer>
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="sqlitePlatform">The SQLite platform to be used by the SQLite PCL library.</param>
        /// <param name="sqliteConnectionString">The SQLite connection string to be used by the SQLite PCL library.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public CustomerSqliteRepository(ISQLitePlatform sqlitePlatform, SQLiteConnectionString sqliteConnectionString)
            : base(sqlitePlatform, sqliteConnectionString)
        {
        }
    }
```
3. An in-memory repository to be used for unit testing and/or design-time for XAML, for example.
```C#
public class LegalEntityInProcRepository : InProcRepositoryBase<LegalEntity>, ILegalEntityRepository
{
    public LegalEntityInProcRepository() : this(false)
    {
    }
    public LegalEntityInProcRepository(Boolean useSampleData)
    {
        if (useSampleData)
        {
            Insert(new LegalEntity() {LegalEntityId = Guid.NewGuid(), Name = "ABC Company"});
            Insert(new LegalEntity() { LegalEntityId = Guid.NewGuid(), Name = "Company, Inc." });
            Insert(new LegalEntity() { LegalEntityId = Guid.NewGuid(), Name = "Liabilities Limited, LLC" });
        }
    }

    public override LegalEntity GetById(Guid id)
    {
        return this.GetAll().FirstOrDefault(item => item.LegalEntityId.Equals(id));
    }

    public override void Update(LegalEntity instance)
    {
        if (instance == null)
            throw new ArgumentNullException("instance");

        LegalEntity oldItem = GetById(instance.LegalEntityId);
        Delete(oldItem);
        Insert(instance);
    }
}
```
4. An abstract `ViewModelBase<T>` class which is based around an `ObservableCollection<T>` of some entity. Includes using an `ICommand` for binding a refresh button from the UI with no code. For example, 
```C#
public class CustomerViewModel : ViewModelBase<Customer>
{
    /// <summary>
    /// Creates a new instance of this type.
    /// </summary>
    /// <param name="repository">The repository to use for the primary data type.</param>
    public CustomerViewModel(IRepository<Customer> repository) : base(repository)
    {
    }
}
```
This class now has an `ObservableCollection<T>` of Customer, which can be refreshed by the UI, via an `ICommand` called Refresh, and which can be bound via XAML.

5. Instead of using our `ViewModelBase<T>`, use the `ViewModelRefresher<T>` directly in your own class. It refreshes an `ObservableCollection<T>` from an underlying `IRepository<T>` and can be bound directly to the UI via a XAML "Command".
6. An abstract implementation of mundane functionality via `ObservableBase` (for `INotifyPropertyChanged`) and `DisposableBase' (for `IDisposable`).
