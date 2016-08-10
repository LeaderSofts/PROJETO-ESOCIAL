using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Business.Repositories
{
    public class EFProvider
    {
        public T GetRepository<T>()
            where T : class
        {
            return Activator.CreateInstance<T>();
        }
    }
}