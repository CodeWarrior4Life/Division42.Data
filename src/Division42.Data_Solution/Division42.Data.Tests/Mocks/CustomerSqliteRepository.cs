﻿using System;
using Division42.Data.Repository;
using SQLite.Net;
using SQLite.Net.Interop;

namespace Division42.Data.Tests.Mocks
{
    public class CustomerSqliteRepository : SqliteRepositoryBase<Customer, Guid>
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
}