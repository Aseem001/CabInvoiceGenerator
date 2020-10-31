// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceSummary.cs" company="Bridgelabz">
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
    /// Invoice summary class gives info about the number of rides and total fare for all the rides collectively
    /// </summary>
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totalFare;

        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is InvoiceSummary))
            {
                return false;
            }
            // returns true only if the following values of BOTH the objects are equal
            return (this.numberOfRides == ((InvoiceSummary)obj).numberOfRides)
                && (this.totalFare == ((InvoiceSummary)obj).totalFare);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {           
            return numberOfRides.GetHashCode() ^ totalFare.GetHashCode();
        }
    }
}
