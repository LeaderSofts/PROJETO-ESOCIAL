using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Business.Repositories
{
    public class EFUnitOfWork
    {
        private static EFProvider _provider;

        public static T GetRepository<T>()
            where T : class
        {
            if(_provider == null)
                _provider = new EFProvider();

            return _provider.GetRepository<T>();
        }
    }
}