// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="Bridgelabz">
//   Copyright � 2018 Company
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
    }
}