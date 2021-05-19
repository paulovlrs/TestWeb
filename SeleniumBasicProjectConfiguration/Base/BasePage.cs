using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SeleniumBasicProjectConfiguration.Base
{
  public abstract class BasePage : BaseDriver
  {
    // Inicializar os elementos da página se torna geral
    public BasePage()
    {
      DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    /// <summary>
    /// Escreve no elemento
    /// </summary>
    /// <param name="by">Elemento</param>
    /// <param name="text">Texto que será inserido no elemento</param>
    /// <param name="messageErro">Mensagem de erro que deseja que seja exibida</param>
    public static void writeElement(By by, string text)
    {
      DriverContext.Driver.FindElement(by).SendKeys(text);
    }

    public static void MessageFail(string message)
    {
      Assert.Fail(message);
    }

    public static void AssertTrueCondition(bool condition, string message = "")
    {
      Assert.True(condition, message);
    }

    public static void AssertFalseCondition(bool condition, string message = "")
    {
      Assert.False(condition, message);
    }

    public static string GetCurrentUrl()
    {
      return DriverContext.Driver.Url.ToString();
    }

    public static void ClickElement(By by)
    {
      DriverContext.Driver.FindElement(by).Click();
    }

    public static int CountElement(By by)
    {
      return DriverContext.Driver.FindElements(by).Count;
    }

    /// <summary>
    /// Clica no elemento especifico de uma lista. 
    /// Exemplo: contElement = 3, o terceiro elemento da lista será clicado
    /// </summary>
    /// <param name="byList">Elemento</param>
    /// <param name="contElement">número do elemento que será clicado</param>
    public static void ClickElementList(By byList, int contElement)
    {
      int cont = 1;
      IList<IWebElement> elements = DriverContext.Driver.FindElements(byList);
      foreach (IWebElement element in elements)
      {
        if (cont == contElement)
          element.Click();
        cont++;
      }
    }

    public static string GetTextElement(By by)
    {
      return DriverContext.Driver.FindElement(by).Text;
    }

    public static bool CompareStringListElements(By byList, string textCompare)
    {
      try
      {
        IList<IWebElement> elements = DriverContext.Driver.FindElements(byList);
        foreach (IWebElement element in elements)
        {
          if (element.Text == textCompare)
            return true;
        }
        return false;
      }
      catch (Exception e)
      {
        MessageFail("Erro ao verificar se o valor é igual ao do elemento, erro: " + e.Message);
        return false;
      }
    }

    public static bool ContainsStringListElements(By byList, string textCompare)
    {
      try
      {
        IList<IWebElement> elements = DriverContext.Driver.FindElements(byList);
        foreach (IWebElement element in elements)
        {
          if (element.Text.Contains(textCompare))
            return true;
        }
        return false;
      }
      catch (Exception e)
      {
        MessageFail("Erro ao verificar se contém o valor no elemento, erro: " + e.Message);
        return false;
      }
    }
  }
}
