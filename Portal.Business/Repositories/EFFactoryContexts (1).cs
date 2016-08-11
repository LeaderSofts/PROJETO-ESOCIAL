using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Erp.Business.Repositories
{
    public partial class EFContextContainer : DbContext
    {
        public EFContextContainer()
            : base("dbEF")
        {

        }

        public EFContextContainer(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

         // Constructor to use on a DbConnection that is already opened
        public EFContextContainer(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }        

    }

    public static class EFDatabase
    {
        public static DbContext EFContextContainerGetContext()
        {
            return new EFContextContainer();
        }

        public static DbContext EFContextContainerGetContext(DbConnection existingConnection, bool contextOwnsConnection)
        {
            return new EFContextContainer();
        }

        public static DbContext EFContextContainerGetContext(string nameOrConnectionString)
        {
            return new EFContextContainer(nameOrConnectionString);
        }

    }
}