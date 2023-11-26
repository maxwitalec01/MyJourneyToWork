global using FluentAssertions;
global using NUnit;
global using TechTalk.SpecFlow;
using NUnit.Framework;
using Calculator;

namespace BDD_tests.StepDefinitions;


[Binding]
public class CalculatorSteps
{
    private Calculator calculator;

    [Given(@"I have a distance of (.*) miles")]
    public void GivenIHaveADistanceOfMiles(double distance)
    {
        calculator = new Calculator { distance = distance, milesOrKms = DistanceMeasurement.miles };
    }

    [Given(@"I travel to work by Cycling")]
    public void GivenITravelToWorkByCycling()
    {
        calculator.transportMode = TransportModes.cycling;
    }

    [Given(@"I travel for (.*) days a week")]
    public void GivenITravelForDaysAWeek(double numDays)
    {
        calculator.numDays = numDays;
    }

    [When(@"I calculate the sustainability weighting")]
    public void WhenICalculateTheSustainabilityWeighting()
    {
        // Assuming the Calculator instance is already set up with the necessary properties
        calculator.convertDistance(); // Ensure distance is converted if needed
        calculator.sustainabilityWeighting = calculator.sustainabilityWeighting; // Trigger the calculation
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(double expectedResult)
    {
        Assert.AreEqual(expectedResult, calculator.sustainabilityWeighting, 0.001); // Adjust delta as needed
    }
}