using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Interface.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
