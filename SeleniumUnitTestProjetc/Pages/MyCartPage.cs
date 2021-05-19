using OpenQA.Selenium;
using SeleniumBasicProjectConfiguration.Base;
using System;

namespace SeleniumUnitTestProjetc.Pages
{
  public class MyCartPage : BasePage
  {
    private string priceAd;
    private string subscriberPriceAd;

    internal void ComparePriceProduct()
    {
      try
      {
        AssertTrueCondition(CompareStringListElements(By.CssSelector("[class='preco']"), priceAd), "O preço do produto é o mesmo do carrinho?");
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível verificar os valores do produto e do carrinho, erro: " + e.Message);
      }
    }

    internal void ComparesubscriberPriceProduct()
    {
      try
      {
        AssertFalseCondition(CompareStringListElements(By.CssSelector("[class='preco']"), subscriberPriceAd), "O preço do produto de assinante é o mesmo do carrinho?");
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível verificar os valores do produto e do carrinho, erro: " + e.Message);
      }
    }

    internal void SetPriceCart(string price, string subscriberPrice)
    {
      try
      {
        priceAd = price;
        subscriberPriceAd = subscriberPrice;
      }
      catch (Exception e)
      {
        MessageFail("Não foi atribuir o valor dos produtos, erro: " + e.Message);
      }
    }

    internal void ExistItemInMyCart(string item)
    {
      try
      {
        AssertTrueCondition(ContainsStringListElements(By.XPath("//td[@class='td-resumo']//a"), item), "O produto está no carrinho de compra?");
      }
      catch (Exception e)
      {
        MessageFail("Não foi possível verificar os valores do produto e do carrinho, erro: " + e.Message);
      }
    }
  }
}
