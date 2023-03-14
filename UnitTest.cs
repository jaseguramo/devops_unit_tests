using SeleniumExtras.WaitHelpers;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace SeleniumForAzurePipelines;

[TestFixture("edge")]
public class UnitTest : TestMaster
{
    public UnitTest(string browser) : base(browser) { }

    [Test]
    public void checkWebAppTitle()
    {
        driver.Navigate().GoToUrl(url);
        bool webAppTitleIsOk = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("//a[@class=\"navbar-brand\"]"), "TestForAzurePipelines"));

        Assert.That(webAppTitleIsOk, Is.EqualTo(true));
    }

    [Test]
    public void checkHelloWorldLabel()
    {
        driver.Navigate().GoToUrl(url);

        bool HelloWorldLabelIsOk = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.Id("helloWorldLabel"), "Hello world from my Web app with ASP.NET 7."));

        Assert.That(HelloWorldLabelIsOk, Is.EqualTo(true));
    }
}