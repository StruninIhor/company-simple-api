using System;

namespace Company.Interface.Common
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string message = "Validation exception!") : base(message) { }
    }
}
