using System;

namespace RSignSDK
{
    public class AuthenticationException : Exception
    {
        /// <summary>
        /// Construct instance of AuthenticationException.
        /// </summary>
        public AuthenticationException()
            : base()
        { }

        /// <summary>
        /// Construct instance of AuthenticationException.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public AuthenticationException(string message)
            : base(message)
        { }
    }
}