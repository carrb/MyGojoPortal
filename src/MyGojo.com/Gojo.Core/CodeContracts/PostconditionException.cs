using System;

namespace Gojo.Core.CodeContracts
{
    /// Exception raised when a postcondition fails.
    ///
    public class PostconditionException : DesignByContractException
    {
        /// Postcondition Exception.
        /// 
        public PostconditionException() { }

        /// Postcondition Exception.
        /// 
        public PostconditionException(string message) : base(message) { }

        /// Postcondition Exception.
        /// 
        public PostconditionException(string message, Exception inner) : base(message, inner) { }
    }
}
