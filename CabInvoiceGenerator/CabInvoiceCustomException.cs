// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CabInvoiceCustomException.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Custom Exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class CabInvoiceCustomException:Exception
    {
        /// <summary>
        /// Enum class Exception Type
        /// </summary>
        public enum ExceptionType
        {            
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID,
            INVALID_RIDE_TYPE
        }

        public ExceptionType exceptionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceCustomException"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message.</param>
        public CabInvoiceCustomException(ExceptionType exception,string message):base(message)
        {
            this.exceptionType = exception;
        }
    }
}
