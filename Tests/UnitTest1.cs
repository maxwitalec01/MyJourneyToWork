namespace Calculator
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ConvertDistance_ConvertsKilometersToMiles()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 160.9344, // 100 kilometers
                milesOrKms = DistanceMeasurement.kms
            };

            // Testing converting distance
            double result = calculator.convertDistance();

            // Testing
            Assert.AreEqual(100, result, 0.001);
        }

        [Test]
        public void ConvertDistance_LeavesMilesUnchanged()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 100, // 100 miles
                milesOrKms = DistanceMeasurement.miles
            };

            // Testing converting distance 
            double result = calculator.convertDistance();

            // Testing
            Assert.AreEqual(100, result);
        }

        [Test]
        public void SustainabilityWeighting_CorrectForPetrol()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 50, // 50 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 3,
                transportMode = TransportModes.petrol
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.AreEqual(2400, result);
        }

        [Test]
        public void SustainabilityWeighting_CorrectForWalking()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 2, // 2 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 5,
                transportMode = TransportModes.walking
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.That(result, Is.EqualTo(0.1).Within(0.001));
        }

        [Test]
        public void SustainabilityWeighting_CorrectForElectricBike()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 10, // 10 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 2,
                transportMode = TransportModes.electricbike
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.That(result, Is.EqualTo(80).Within(0.001));
        }

        [Test]
        public void SustainabilityWeighting_CorrectForElectric()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 30, // 30 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 4,
                transportMode = TransportModes.electric
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.That(result, Is.EqualTo(960).Within(0.001));
        }

        /*        [Test]
                public void SustainabilityWeighting_WithInvalidDistance_ReturnsZero()
                {
                    // Construct Calculator
                    Calculator calculator = new Calculator
                    {
                        distance = 1200, // Invalid distance (beyond the allowed range)
                        milesOrKms = DistanceMeasurement.miles,
                        numDays = 3,
                        transportMode = TransportModes.bus
                    };

                    // Testing sustainability weighting
                    double result = calculator.sustainabilityWeighting;

                    // Testing
                    Assert.AreEqual(0, result, 0.001); // Allow for a small variation due to floating-point precision
                }*/
        [Test]
        public void SustainabilityWeighting_CorrectForDiesel()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 40, // 40 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 3,
                transportMode = TransportModes.deisel
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.That(result, Is.EqualTo(2400).Within(0.001));
        }

        [Test]
        public void SustainabilityWeighting_CorrectForHybrid()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 20, // 20 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 5,
                transportMode = TransportModes.hybrid
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.That(result, Is.EqualTo(1200).Within(0.001));
        }

        [Test]
        public void SustainabilityWeighting_CorrectForMotorbike()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 15, // 15 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 2,
                transportMode = TransportModes.motorbike
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.That(result, Is.EqualTo(180).Within(0.001));
        }

        [Test]
        public void SustainabilityWeighting_CorrectForTrain()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 100, // 100 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 4,
                transportMode = TransportModes.train
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.That(result, Is.EqualTo(2400).Within(0.001));
        }

        [Test]
        public void SustainabilityWeighting_CorrectForBus()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 30, // 30 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 7,
                transportMode = TransportModes.bus
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.That(result, Is.EqualTo(1260).Within(0.001));
        }

    }
}