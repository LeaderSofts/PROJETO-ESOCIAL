using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class PortalException : Exception
    {
        public PortalException() { }

        public PortalException(string message) : base(message) { }
        
        public PortalException(string message, Exception ex) : base(message, ex) { }
    }
}
