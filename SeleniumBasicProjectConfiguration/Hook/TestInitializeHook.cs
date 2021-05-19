using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumBasicProjectConfiguration.Base;
using SeleniumBasicProjectConfiguration.Config;
using SeleniumBasicProjectConfiguration.Helpers;

namespace SeleniumBasicProjectConfiguration.Hook
{
  public abstract class TestInitializeHook : BaseDriver
  {
    public readonly BrowserType Browser;

    public TestInitializeHook(BrowserType browser)
    {
      Browser = browser;
    }

    public void Initialize()
    {
      // Atribuo as configurações do XML
      ConfigReader.SetFrameworkSettings("staging");

      // Crio o log
      LogHelpers.CreateLogFile();

      // Inicio e maximizo o navegador 
      OpenBrowser(Settings.BrowserType);
      Maximizar();
    }

    // Definir o browser que será usado
    public static void OpenBrowser(BrowserType browserType)
    {
      switch (browserType)
      {
        case BrowserType.InternetExplorer:
          DriverContext.Driver = new InternetExplorerDriver();
          DriverContext.Browser = new Browser(DriverContext.Driver);
          break;
        case BrowserType.FireFox:
          DriverContext.Driver = new FirefoxDriver();
          DriverContext.Browser = new Browser(DriverContext.Driver);
          break;
        case BrowserType.Chrome:
          DriverContext.Driver = new ChromeDriver(ChromeArguments());
          DriverContext.Browser = new Browser(DriverContext.Driver);
          break;
      }
    }

    public static void Navigate()
    {
      // Acesso o site da aplicação
      DriverContext.Browser.GoToUrl(Settings.AUT);
      LogHelpers.Write("Acessando o site da aplicação");
    }

    // COnfigurações do Chrome
    public static ChromeOptions ChromeArguments()
    {
      ChromeOptions options = new ChromeOptions();
      options.AddArguments("--disable-extensions"); // to disable extension
      options.AddArguments("--disable-notifications"); // to disable notification
      options.AddArguments("--disable-application-cache"); // to disable cache
      return options;
    }

    public static void Maximizar()
    {
      DriverContext.Driver.Manage().Window.Maximize();
    }

    public static void FinalizarDriver()
    {
      DriverContext.Driver.Close();
      DriverContext.Driver.Quit();
    }

    public enum BrowserType
    {
      InternetExplorer,
      FireFox,
      Chrome
    }
  }
}
