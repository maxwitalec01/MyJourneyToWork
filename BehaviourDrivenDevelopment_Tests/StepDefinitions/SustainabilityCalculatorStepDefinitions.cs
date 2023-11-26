using Calculator; // Update the namespace as needed
using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace Calculator;

[Binding]
public class CalculatorSteps
{
    private Calculator calculator;
    private double calculatedSustainabilityWeighting;

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

    [Given(@"I travel to work by Diesel")]
    public void GivenITravelToWorkByDiesel()
    {
        calculator.transportMode = TransportModes.deisel;
    }

    [Given(@"I travel to work by Walking")]
    public void GivenITravelToWorkByWalking()
    {
        calculator.transportMode = TransportModes.walking;
    }

    [Given(@"I travel for (.*) days a week")]
    public void GivenITravelForDaysAWeek(double numDays)
    {
        calculator.numDays = numDays;
    }

    [When(@"I calculate the sustainability weighting")]
    public void WhenICalculateTheSustainabilityWeighting()
    {
        calculatedSustainabilityWeighting = calculator.sustainabilityWeighting;
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(double expectedValue)
    {
        Assert.AreEqual(expectedValue, calculatedSustainabilityWeighting, 0.001);
    }
}