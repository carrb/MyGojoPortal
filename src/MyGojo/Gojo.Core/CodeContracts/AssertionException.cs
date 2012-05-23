using System;

namespace Gojo.Core.CodeContracts
{
    /// Exception raised when an assertion fails.
    /// 
    public class AssertionException : DesignByContractException
    {

        /// Assertion Exception.
        /// 
        public AssertionException() { }

        /// Assertion Exception.
        /// 
        public AssertionException(string message) : base(message) { }

        /// Assertion Exception.
        /// 
        public AssertionException(string message, Exception inner) : base(message, inner) { }
    }
}
