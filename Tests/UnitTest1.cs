using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyJourneyToWork.Pages;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Transactions;


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
                distance = 160.9344,
                milesOrKms = DistanceMeasurement.kms
            };

            // Testing converting distance
            double result = calculator.convertDistance();

            // Testing
            Assert.That(result, Is.EqualTo(100).Within(0.001));
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
            Assert.That(result, Is.EqualTo(100));
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
            Assert.That(result, Is.EqualTo(2400));
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
            Assert.That(result, Is.EqualTo(0.005 * 20 * (5 * 2)).Within(0.001));
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
            Assert.That(result, Is.EqualTo(3 * 15 * (3 * 2)).Within(0.001));
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
            Assert.That(message, Is.EqualTo("Great job! Your transportation choice is environmentally friendly."));
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
            Assert.That(message, Is.EqualTo("Consider choosing a more sustainable mode of transportation for a greener impact."));
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
            Assert.That(message, Is.EqualTo("Good effort! There's room for improvement, but you're on the right track."));
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
            Assert.That(calculatorModel.calculator, Is.EqualTo(calculator));
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
    [TestFixture]
    public class ErrorModelTests
    {
        [Test]
        public void OnGet_SetsRequestId_WhenActivityCurrentIsNull()
        {
            // Create mock logger, privacy model
            var loggerMock = new Mock<ILogger<ErrorModel>>();
            var errorModel = new ErrorModel(loggerMock.Object);
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.Setup(c => c.TraceIdentifier).Returns("HttpContextTestId");

            var pageContext = new PageContext
            {
                HttpContext = httpContextMock.Object
            };

            errorModel.PageContext = pageContext;
            errorModel.OnGet();

            // Test
            Assert.That(errorModel.RequestId, Is.EqualTo("HttpContextTestId"));
            Assert.IsTrue(errorModel.ShowRequestId);
        }
    }
}

namespace PlaywrightTests
{
	[Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
		[Test]
		public async Task HomePageTest()
		{
			await Page.GotoAsync("https://ca3devopsmjtw-qa.azurewebsites.net/");

			// Assert Statement to make sure "Welcome" is displaying on this page
			var welcomeHeading =  Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome" });
			Assert.IsNotNull(welcomeHeading, "The 'Welcome' heading is not displayed on the page.");
			await welcomeHeading.ClickAsync();

		}

		[Test]
		public async Task PrivacyPageTest()
		{

			await Page.GotoAsync("https://ca3devopsmjtw-qa.azurewebsites.net/");

			await Page.GetByRole(AriaRole.List).GetByRole(AriaRole.Link, new() { Name = "Privacy" }).ClickAsync();

			// Assert Statement to make sure "Privacy Policy" is displaying on this page
			var privacyPolicyHeading = Page.GetByRole(AriaRole.Heading, new() { Name = "Privacy Policy" });
			Assert.IsNotNull(privacyPolicyHeading, "The 'Privacy Policy' heading is not displayed on the page.");
			await privacyPolicyHeading.ClickAsync();

			// Assert Statement to make sure "Use this page to detail your" is displaying on this page
			var privacyDetailText = Page.GetByText("Use this page to detail your");
			Assert.IsNotNull(privacyDetailText, "The text 'Use this page to detail your' is not displayed on the page.");
			await privacyDetailText.ClickAsync();

		}

		[Test]
		public async Task PetrolKilometersCalculatorTest()
		{
           
			await Page.GotoAsync("https://ca3devopsmjtw-qa.azurewebsites.net/");

            // Nav to Calc
			await Page.GetByRole(AriaRole.Link, new() { Name = "Calculator" }).ClickAsync();

            // Enter number of days
			await Page.GetByLabel("Enter the number of days you").ClickAsync();
			await Page.GetByLabel("Enter the number of days you").FillAsync("2");

            // Enter Distance travelled to Work
			await Page.GetByLabel("Enter Your Distance to work (").ClickAsync();
			await Page.GetByLabel("Enter Your Distance to work (").FillAsync("2");


			// Select Distance Measurement
			await Page.GetByLabel("Select A Distance Measurement:").SelectOptionAsync("Kilometers");

			// Select the transport mode
			await Page.GetByLabel("Select A Transport mode:").SelectOptionAsync("Petrol");

			// Press the calculate button
			await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync();

            // Assert to check sustainability weightting.
			var SustainabilityWeighting = await Page.GetByText("Your Sustainability Weighting: 39.76775630318937").InnerTextAsync();
            Assert.AreEqual("Your Sustainability Weighting: 39.76775630318937", SustainabilityWeighting);

			// Assert message about sustainability weighting
			var SustainabilityWeightingMessage = await Page.GetByText("Sustainability Message: Good effort! There's room for improvement, but you're on the right track.").InnerTextAsync();
			Assert.AreEqual("Sustainability Message: Good effort! There's room for improvement, but you're on the right track.", SustainabilityWeightingMessage);
		}

		[Test]
		public async Task DieselMilesCalculatorTest()
		{

			await Page.GotoAsync("https://ca3devopsmjtw-qa.azurewebsites.net/");

			// Nav to Calc
			await Page.GetByRole(AriaRole.Link, new() { Name = "Calculator" }).ClickAsync();

			// Enter number of days
			await Page.GetByLabel("Enter the number of days you").ClickAsync();
			await Page.GetByLabel("Enter the number of days you").FillAsync("5");

			// Enter Distance travelled to Work
			await Page.GetByLabel("Enter Your Distance to work (").ClickAsync();
			await Page.GetByLabel("Enter Your Distance to work (").FillAsync("10");

			// Select the transport mode
			await Page.GetByLabel("Select A Distance Measurement:").SelectOptionAsync("Miles");

			// Select Distance Measurement
			await Page.GetByLabel("Select A Transport mode:").SelectOptionAsync("Diesel");

			// Press the calculate button
			await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync();

			// Assert to check sustainability weightting.
			var SustainabilityWeighting = await Page.GetByText("Your Sustainability Weighting: 1000").InnerTextAsync();
			Assert.AreEqual("Your Sustainability Weighting: 1000", SustainabilityWeighting);

			// Assert message about sustainability weighting
			var SustainabilityWeightingMessage = await Page.GetByText("Sustainability Message: Consider choosing a more sustainable mode of transportation for a greener impact.").InnerTextAsync();
			Assert.AreEqual("Sustainability Message: Consider choosing a more sustainable mode of transportation for a greener impact.", SustainabilityWeightingMessage);
		}


	}


}

