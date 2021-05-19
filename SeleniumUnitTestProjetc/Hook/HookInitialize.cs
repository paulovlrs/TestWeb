using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumBasicProjectConfiguration.Helpers;
using SeleniumBasicProjectConfiguration.Hook;
using TechTalk.SpecFlow;

namespace SeleniumUnitTestProjetc.Hook
{
  [Binding]
  public class HookInitialize : TestInitializeHook
  {
    [AssemblyInitialize()]
    public static void MyTestInitialize(TestContext testContext)
    { }
    [AssemblyCleanup]
    public static void TearDown()
    { }

    public HookInitialize() : base(BrowserType.Chrome)
    {
      Initialize();
    }

    [BeforeFeature]
    public static void TestStart()
    {
      HookInitialize init = new HookInitialize();
    }

    [AfterFeature]
    public static void TestEnd()
    {
      FinalizarDriver();
      ReportHelpers.Flush();    
    }
  }
}
