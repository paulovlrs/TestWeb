using OpenQA.Selenium;
using SeleniumBasicProjectConfiguration.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUnitTestProjetc.Pages
{
  public class SearchPage : BasePage
  {
    internal ProductPage ClickProductList(int numberList)
    {
      try
      {
        ClickElementList(By.Id("produto-href"), numberList);
        return new ProductPage();
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível clicar no item da lista de produtos, erro: " + e.Message);
        return null;
      }
    }
  }
}
