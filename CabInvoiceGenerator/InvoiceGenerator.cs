// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceGenerator.cs" company="Bridgelabz">
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
    /// Invoice Generator class
    /// </summary>
    public class InvoiceGenerator
    {        
        private readonly double COST_PER_KM;
        private readonly int COST_PER_MINUTE;
        private readonly double MINIMUM_FARE;

        /// UC 4        
        RideRepository rideRepository = null;

        public InvoiceGenerator()
        {
            rideRepository = new RideRepository();
            /// Initialization of constants
            COST_PER_KM = 10;
            COST_PER_MINUTE = 1;
            MINIMUM_FARE = 5;
        }

        /// <summary>
        /// UC 1 : Calculates the fare given time and distance.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="minutes">The minutes.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceCustomException">
        /// Distance travelled is invalid
        /// or
        /// Invalid travel time
        /// </exception>
        public double CalculateFare(double distance,int minutes)
        {
            double totalFare =0;
            try
            {
                totalFare = COST_PER_KM * distance + COST_PER_MINUTE * minutes;
            }
            catch
            {
                /// If the distance is invalid, throw exception
                if (distance <= 0)
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_DISTANCE, "Distance travelled is invalid");
                /// If the travel time is invalid throw exception
                if (minutes <= 0)
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_TIME, "Invalid travel time");
            }
            /// Returns the maximum value between calculated total fare and minimum fare
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        /// <summary>
        /// UC 2 & 3 : Calculates the total fare for multiple rides and average Fare per ride.
        /// </summary>
        /// <param name="rides">The rides.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceCustomException">Rides are null</exception>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            double averageFare = 0;
            try
            {
                foreach(Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.minutes);
                }
                /// UC 3
                averageFare = totalFare / rides.Length;
            }
            catch
            {
                /// If the rides array does not contain any ride
                if (rides == null)
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.NULL_RIDES, "Rides are null");
            }
            return new InvoiceSummary(rides.Length, totalFare,averageFare);
        }

        /// <summary>
        /// UC 4 : Adds the rides of a particular user with given user Id into the dictionary collection.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        public void AddRides(string userId,Ride[] rides)
        {
            rideRepository.AddRideDetails(userId, rides);
        }

        /// <summary>
        /// UC 4 : Gets the invoice summary of the user with given user Id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return CalculateFare(rideRepository.GetRides(userId));
        }
    }
}
