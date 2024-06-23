using FluentAssertions;
using OpenQA.Selenium;
using SpecflowLikeTests.Drivers;

namespace SpecflowLikeTests.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;
    private readonly Driver _driver;

    public CalculatorStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = new Driver();
        _driver.Start();
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        var element = _driver.DriverInstance.FindElement(By.Id("first-number"));
        element.Displayed.Should().BeTrue();
        
        element.SendKeys(number.ToString());
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        var element = _driver.DriverInstance.FindElement(By.Id("second-number"));
        element.Displayed.Should().BeTrue();
        element.Enabled.Should().BeTrue();
        
        element.SendKeys(number.ToString());
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        var element = _driver.DriverInstance.FindElement(By.Id("add-button"));
        element.Displayed.Should().BeTrue();
        element.Enabled.Should().BeTrue();
        
        element.Click();
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        var element = _driver.DriverInstance.FindElement(By.Id("result"));
        element.Displayed.Should().BeTrue();
        
        var actualResult = element.Text;
        actualResult.Should().Be(result.ToString());
    }
}