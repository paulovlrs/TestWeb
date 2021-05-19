using OpenQA.Selenium;
using SeleniumBasicProjectConfiguration.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUnitTestProjetc.Pages
{
  public class HomePage : BasePage
  {
    internal void CheckCurrentPage()
    {
      AssertTrueCondition((GetCurrentUrl() == "https://www.petz.com.br/"), "Está na página principal?");
    }

    internal void WriteSearch(string text)
    {
      try
      {
        writeElement(By.Id("search"), text);
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível inserir o texto na barra de pesquisa, erro: " + e.Message);
      }
    }

    internal SearchPage ClickButtonSearch()
    {
      try
      {
        ClickElement(By.CssSelector("[class='button-search']"));
        return new SearchPage();
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível clicar no botão pesquisa, erro:" + e.Message);
        return null;
      }
    }
  }
}
