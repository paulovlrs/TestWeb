using OpenQA.Selenium;
using SeleniumBasicProjectConfiguration.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUnitTestProjetc.Pages
{
  public class ProductPage : BasePage
  {
    private  string price;
    private  string subscriberPrice;

    internal void GetPriceProduct()
    {
      try
      {
        price = GetTextElement(By.CssSelector("[class='price-current']"));
        subscriberPrice = GetTextElement(By.CssSelector("[class='price-subscriber']"));
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível verificar os valores do produto, erro: " + e.Message);
      }
    }

    internal string SetPriceProduct()
    {
      try
      {
        return price;
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível enviar o valor do produto, erro: " + e.Message);
        return null;
      }
    }

    internal string SetSubscriberPriceProduct()
    {
      try
      {
        return subscriberPrice;
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível enviar o valor do produto de , erro: " + e.Message);
        return null;
      }
    }

    internal MyCartPage AddToCart()
    {
      try
      {
        ClickElement(By.Id("adicionarAoCarrinho"));
        return new MyCartPage();
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível adicionar o produto ao carrinho de compra, erro: " + e.Message);
        return null;
      }
    }
  }
}
