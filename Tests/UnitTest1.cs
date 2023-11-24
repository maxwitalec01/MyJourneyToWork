namespace Calculator
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ConvertDistance_ConvertsKilometersToMiles()
        {
            // Arrange
            Calculator calculator = new Calculator
            {
                distance = 160.9344, // 100 kilometers
                milesOrKms = DistanceMeasurement.kms
            };

            // Act
            double result = calculator.convertDistance();

            // Assert
            Assert.AreEqual(100, result, 0.001);
        }

        [Test]
        public void ConvertDistance_LeavesMilesUnchanged()
        {
            // Arrange
            Calculator calculator = new Calculator
            {
                distance = 100, // 100 miles
                milesOrKms = DistanceMeasurement.miles
            };

            // Act
            double result = calculator.convertDistance();

            // Assert
            Assert.AreEqual(100, result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForPetrol()
        {
            // Arrange
            Calculator calculator = new Calculator
            {
                distance = 50, // 50 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 3,
                transportMode = TransportModes.petrol
            };

            // Act
            double result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(2400, result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForWalking()
        {
            // Arrange
            Calculator calculator = new Calculator
            {
                distance = 2, // 2 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 5,
                transportMode = TransportModes.walking
            };

            // Act
            double result = calculator.sustainabilityWeighting;

            // Assert
            Assert.That(result, Is.EqualTo(0.1).Within(0.001));
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForElectricBike()
        {
            // Arrange
            Calculator calculator = new Calculator
            {
                distance = 10, // 10 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 2,
                transportMode = TransportModes.electricbike
            };

            // Act
            double result = calculator.sustainabilityWeighting;

            // Assert
            Assert.That(result, Is.EqualTo(80).Within(0.001));
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForElectric()
        {
            // Arrange
            Calculator calculator = new Calculator
            {
                distance = 30, // 30 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 4,
                transportMode = TransportModes.electric
            };

            // Act
            double result = calculator.sustainabilityWeighting;

            // Assert
            Assert.That(result, Is.EqualTo(960).Within(0.001));
        }

/*        [Test]
        public void SustainabilityWeighting_WithInvalidDistance_ReturnsZero()
        {
            // Arrange
            Calculator calculator = new Calculator
            {
                distance = 1200, // Invalid distance (beyond the allowed range)
                milesOrKms = DistanceMeasurement.miles,
                numDays = 3,
                transportMode = TransportModes.bus
            };

            // Act
            double result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(0, result, 0.001); // Allow for a small variation due to floating-point precision
        }*/
    }
}