using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Division42.Data.Repository;
using Division42.Data.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.Win32;

namespace Division42.Data.Tests.Repository
{
    [TestClass]
    public class SqliteRepositoryBaseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullPlatform_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = null;
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullConnectionString_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = null;

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void GetAllAfterDispose_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString);

            repository.Dispose();
            repository.GetAll().ToList();

            Assert.Fail("Should have thrown an ObjectDisposedException.");
        }

        [TestMethod]
        [ExpectedException(typeof(DataException<Customer>))]
        public void GetAllWithMissingDBFile_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.GetAll().ToList();

                Assert.Fail("Should have thrown a DataException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DataException<Customer>))]
        public void GetByIdWithMissingDBFile_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.GetById(Guid.NewGuid());

                Assert.Fail("Should have thrown a DataException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DataException<Customer>))]
        public void GetByFilterWithValidArgumentAndMissingDBFile_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.GetByFilter(item=>item.CustomerId==Guid.NewGuid());

                Assert.Fail("Should have thrown a DataException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetByFilterWithNullArgument_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.GetByFilter(null);

                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DataException<Customer>))]
        public void InsertWithMissingDBFile_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.Insert(new Customer() {CustomerId = Guid.NewGuid()});

                Assert.Fail("Should have thrown a DataException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DataException<Customer>))]
        public void UpdateWithMissingDBFile_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.Update(new Customer() { CustomerId = Guid.NewGuid() });

                Assert.Fail("Should have thrown a DataException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DataException<Customer>))]
        public void DeleteWithMissingDBFile_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.Delete(new Customer() { CustomerId = Guid.NewGuid() });

                Assert.Fail("Should have thrown a DataException.");
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertWithNullArgument_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.Insert(null);

                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateWithNullArgument_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.Update(null);

                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteWithNullArgument_ShouldThrowException()
        {
            SQLitePlatformWin32 platform = new SQLitePlatformWin32();
            SQLiteConnectionString connectionString = new SQLiteConnectionString("C:\\Bogus\\DoesNotExist.db", false);

            using (CustomerSqliteRepository repository = new CustomerSqliteRepository(platform, connectionString))
            {
                repository.Delete(null);

                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }
    }


}
