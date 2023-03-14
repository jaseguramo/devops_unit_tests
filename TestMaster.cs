namespace SeleniumForAzurePipelines;

[TestFixture]
public class TestMaster
{
    protected dynamic options;
    protected IConfigurationRoot config;
    protected IWebDriver driver;
    protected string browser;
    protected WebDriverWait wait;
    protected string url;

    #region"constructor"
    public TestMaster()
    {
        config = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();
        url = config["webapp_url"].ToString();
    }

    public TestMaster(string browser) : this()
    {
        this.browser = browser;
    }
    #endregion

    #region "Setup"
    [SetUp]
    public void Setup()
    {
        if (browser == "edge")
        {
            options = new EdgeOptions();
            options.AddArgument("use-fake-ui-for-media-stream");
            driver = new EdgeDriver(options);
        }
        else if (browser == "chrome")
        {
            options = new ChromeOptions();
            options.AddArgument("use-fake-ui-for-media-stream");
            options.AddArguments("--disable-features=EnableEphemeralFlashPermission");
            driver = new ChromeDriver(options);
        }

        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(config["time_out"])));
    }
    #endregion

    #region "TearDown"
    [TearDown]
    public void CleanUp()
    {
        driver.Close();
        driver.Quit();
    }
    #endregion
}