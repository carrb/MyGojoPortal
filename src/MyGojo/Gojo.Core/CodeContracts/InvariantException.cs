using System;

namespace Gojo.Core.CodeContracts
{
    /// Exception raised when an invariant fails.
    /// 
    public class InvariantException : DesignByContractException
    {
        /// Invariant Exception.
        /// 
        public InvariantException() { }

        /// Invariant Exception.
        /// 
        public InvariantException(string message) : base(message) { }

        /// Invariant Exception.
        /// 
        public InvariantException(string message, Exception inner) : base(message, inner) { }
    }
}
