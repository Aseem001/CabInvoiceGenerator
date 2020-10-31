// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RideRepository.cs" company="Bridgelabz">
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
    /// Class to add the ride data into dictionary and retrieve ride details of a particular user
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// Dictionary with key as user id and ride details list as value
        /// </summary>
        Dictionary<string, List<Ride>> userRideRepo = null;

        public RideRepository()
        {
            this.userRideRepo= new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Adds the ride details into the dictionary.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        /// <exception cref="CabInvoiceCustomException">Rides are null</exception>
        public void AddRideDetails(string userId,Ride[] rides)
        {
            try
            {
                if (!userRideRepo.ContainsKey(userId))
                {
                    List<Ride> rideList = new List<Ride>();
                    foreach (var ride in rides)
                    {
                        rideList.Add(ride);
                    }
                    /// Adds the data into the dictionary
                    this.userRideRepo.Add(userId, rideList);
                }
            }
            catch
            {
                /// If the rides array does not contain any ride
                if (rides == null)
                    throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        /// <summary>
        /// Gets the ride details of a particular user with given user id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceCustomException">Invalid UserID</exception>
        public Ride[] GetRides(string userId)
        {
            try
            {
                /// Converting the list into an array
                return this.userRideRepo[userId].ToArray();
            }
            catch
            {
                /// If the user id entered does not exist
                throw new CabInvoiceCustomException(CabInvoiceCustomException.ExceptionType.INVALID_USER_ID, "Invalid UserID");
            }
        }
    }
}
