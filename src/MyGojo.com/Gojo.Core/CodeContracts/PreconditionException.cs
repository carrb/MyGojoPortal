using System;

namespace Gojo.Core.CodeContracts
{
    /// Exception raised when a precondition fails.
    /// 
    public class PreconditionException : DesignByContractException
    {
        /// Precondition Exception.
        ///
        public PreconditionException() { }

        /// Precondition Exception.
        /// 
        public PreconditionException(string message) : base(message) { }

        /// Precondition Exception.
        /// 
        public PreconditionException(string message, Exception inner) : base(message, inner) { }
    }
}
