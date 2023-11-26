using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyJourneyToWork.Pages;
using Moq;

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
        [Test]
        public void SustainabilityWeighting_CorrectForCycling()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 20, // Replace with your desired distance
                milesOrKms = DistanceMeasurement.miles,
                numDays = 5, // Replace with your desired number of days
                transportMode = TransportModes.cycling
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.AreEqual(0.005 * 20 * (5 * 2), result, 0.001); // Adjust the expected value and delta as needed
        }

        [Test]
        public void SustainabilityWeighting_CorrectForTram()
        {
            // Construct Calculator
            Calculator calculator = new Calculator
            {
                distance = 15, // Replace with your desired distance
                milesOrKms = DistanceMeasurement.miles,
                numDays = 3, // Replace with your desired number of days
                transportMode = TransportModes.tram
            };

            // Testing sustainability weighting
            double result = calculator.sustainabilityWeighting;

            // Testing
            Assert.AreEqual(3 * 15 * (3 * 2), result, 0.001);
        }
        [Test]
        public void TestSustainabilityMessage_GreatJob()
        {
            // Construct Calculator
            Calculator calculator = new Calculator();
            calculator.transportMode = TransportModes.petrol;
            calculator.distance = 1; // Set a value within the range
            calculator.milesOrKms = DistanceMeasurement.miles;
            calculator.numDays = 1;

            // Retrieve Sustainability message
            string message = calculator.SustainabilityMessage;

            // Testing
            Assert.AreEqual("Great job! Your transportation choice is environmentally friendly.", message);
        }


        [Test]
        public void TestSustainabilityMessage_ConsiderChoosing()
        {
            // Construct Calculator
            Calculator calculator = new Calculator();
            calculator.transportMode = TransportModes.deisel;
            calculator.distance = 70; // Set a value within the range
            calculator.milesOrKms = DistanceMeasurement.miles;
            calculator.numDays = 7;

            // Retrieve Sustainability message
            string message = calculator.SustainabilityMessage;

            // Testing
            Assert.AreEqual("Consider choosing a more sustainable mode of transportation for a greener impact.", message);
        }

        [Test]
        public void TestSustainabilityMessage_GoodEffort()
        {
            // Arrange
            Calculator calculator = new Calculator();
            calculator.transportMode = TransportModes.hybrid;
            calculator.distance = 5; // Set a value within the range
            calculator.milesOrKms = DistanceMeasurement.miles;
            calculator.numDays = 1;

            // Retrieve Sustainability message
            string message = calculator.SustainabilityMessage;

            // Testing
            Assert.AreEqual("Good effort! There's room for improvement, but you're on the right track.", message);
        }

        [Test]
        public void NumDays_ValidRange_ReturnsTrue()
        {
            // Construct Calculator
            Calculator calculator = new Calculator();

            // Assign number of days
            calculator.numDays = 4; // Any value between minimum and maximum

            // Testing
            Assert.That(calculator.numDays, Is.InRange(Calculator.daysMin, Calculator.daysMax));
        }

        [Test]
        public void NumDays_OutsideRange_ReturnsFalse()
        {
            // Construct Calculator
            Calculator calculator = new Calculator();

            // Assign number of days
            calculator.numDays = 8; // Any value between minimum and maximum

            // Testing
            Assert.That(calculator.numDays, Is.Not.InRange(Calculator.daysMin, Calculator.daysMax));
        }
    }
}

namespace MyJourneyToWork.Tests.Pages
{
    [TestFixture]
    public class CalculatorModelTests
    {
        [Test]
        public void OnGet_Always_ShouldDoNothing()
        {
            // Create CalculatorModel
            var calculatorModel = new CalculatorModel();

            // GET request
            calculatorModel.OnGet();

            // Testing
            Assert.Pass("OnGet method executed without errors");
        }

        [Test]
        public void BindProperty_ShouldBeSetOnPostRequest()
        {
            // Create CalculatorModel and Calculator
            var calculatorModel = new CalculatorModel();
            var calculator = new Calculator.Calculator();

            calculatorModel.calculator = calculator;

            // Testing
            Assert.AreEqual(calculator, calculatorModel.calculator);
        }
    }

    [TestFixture]
    public class IndexModelTests
    {
        [Test]
        public void OnGet_ShouldNotThrowException()
        {
            // Create mock logger and index model
            var loggerMock = new Mock<ILogger<IndexModel>>();
            var indexModel = new IndexModel(loggerMock.Object);

            // Test
            Assert.DoesNotThrow(() => indexModel.OnGet());
        }
    }

    [TestFixture]
    public class PrivacyModelTests
    {
        [Test]
        public void OnGet_ShouldNotThrowException()
        {
            // Create mock logger and privacy model
            var loggerMock = new Mock<ILogger<PrivacyModel>>();
            var privacyModel = new PrivacyModel(loggerMock.Object);

            // Test
            Assert.DoesNotThrow(() => privacyModel.OnGet());
        }
    }
}
