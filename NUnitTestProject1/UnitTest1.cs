// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace NUnitTestProject1
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    public class Tests
    {
        public InvoiceGenerator invoiceGenerator = null;

        /// <summary>
        /// UC 1 : Given the distance and time should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            // Arrange
            double expectedFare = 70;
            double distance = 5;
            int minutes = 20;
            invoiceGenerator = new InvoiceGenerator();
            // Act
            double actualFare = invoiceGenerator.CalculateFare(distance, minutes);
            //Assert
            Assert.AreEqual(expectedFare,actualFare);
        }

        /// <summary>
        /// UC 2 & 3 : Given multiple rides should return invoice summary with aggregate totalFare and average Fare
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            // Arrange
            Ride[] rides = { new Ride(3, 5), new Ride(5, 4), new Ride(2, 5) };
            InvoiceSummary expectedSummary = new InvoiceSummary(3,114,38);
            invoiceGenerator = new InvoiceGenerator();
            // Act
            InvoiceSummary actualSummary = invoiceGenerator.CalculateFare(rides);            
            //Assert
            Assert.AreEqual(expectedSummary, actualSummary);
        }

        /// <summary>
        /// UC 4 : Given the user id, invoice service gets list of rides and returns invoice summary.
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRides_ShouldReturnInvoiceSummary()
        {
            // Arrange
            invoiceGenerator = new InvoiceGenerator();
            string userId1 = "USER1";
            string userId2 = "USER2";
            Ride[] rides1 = { new Ride(3, 5), new Ride(5, 4), new Ride(2, 5) };
            Ride[] rides2 = { new Ride(0.1, 1), new Ride(0.1, 3), new Ride(0.1, 2) };
            invoiceGenerator.AddRides(userId1, rides1);
            invoiceGenerator.AddRides(userId2, rides2);
            InvoiceSummary expectedSummary1 = new InvoiceSummary(3, 114, 38);
            InvoiceSummary expectedSummary2 = new InvoiceSummary(3, 15, 5);

            // Act
            InvoiceSummary actualSummary1 = invoiceGenerator.GetInvoiceSummary(userId1);
            InvoiceSummary actualSummary2 = invoiceGenerator.GetInvoiceSummary(userId2);

            //Assert
            Assert.AreEqual(expectedSummary1, actualSummary1);
            Assert.AreEqual(expectedSummary2, actualSummary2);
        }
    }
}