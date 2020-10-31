// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ride.cs" company="Bridgelabz">
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
    /// Ride class to classify each ride based on the travel time and distance
    /// </summary>
    public class Ride
    {
        public double distance;
        public int minutes;

        public Ride(double distance,int minutes)
        {
            this.distance = distance;
            this.minutes = minutes;
        }
    }
}
