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
    }
}