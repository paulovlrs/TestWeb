using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumBasicProjectConfiguration.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace SeleniumUnitTestProjetc.Pages
{
  public class PrincipalPage : BasePage
  {
    #region Elementos da Página
    private IWebElement buttonComecarAutomacaoWeb => DriverContext.Driver.FindElement(By.XPath("//a[contains(text(),'Começar Automação Web')]"));
    private IWebElement buttonComecarAutomacaoAPI => DriverContext.Driver.FindElement(By.XPath("//a[contains(text(),'Começar Automação de Api')]"));
    #endregion

    #region Variáveis
    private WebDriverWait _wait = WaitContext.WaitDriver;
    #endregion

    /// <summary>
    /// Acessa a página de "Começar Automação".
    /// </summary>
    public HomePage ClickButtonComecarAutomacaoWeb()
    {
      try
      {
        _wait.Until(ExpectedConditions.ElementToBeClickable(buttonComecarAutomacaoWeb));
        buttonComecarAutomacaoWeb.Click();
        return new HomePage();
      }
      catch (Exception e)
      {
        Assert.Fail("Não foi possível clicar no botão da tela de Começar Automação, erro: " + e.Message);
        return null;
      }
    }
  }
}
