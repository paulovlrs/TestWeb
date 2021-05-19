using SeleniumBasicProjectConfiguration.Base;
using SeleniumBasicProjectConfiguration.Helpers;
using SeleniumUnitTestProjetc.Pages;
using TechTalk.SpecFlow;

namespace SeleniumUnitTestProjetc.Steps
{
  [Binding]
  public class MeuCarrinhoSteps : BaseSteps
  {
    [When(@"Preencher a barra de pesquisa (.*)")]
    public void QuandoPreencherABarraDePesquisa(string fillTextSearch)
    {
      CurrentPage.As<HomePage>().WriteSearch(fillTextSearch);
      LogHelpers.Write("Preencher a barra de pesquisa");
      LogHelpers.PrintScreen();
    }

    [When(@"Clicar no botão pesquisa")]
    public void QuandoClicarNoBotaoPesquisa()
    {
      CurrentPage = CurrentPage.As<HomePage>().ClickButtonSearch();
      LogHelpers.Write("Clicar no botão pesquisa");
      LogHelpers.PrintScreen();
    }

    [When(@"clicar no produto (.*)")]
    public void QuandoClicarNoProduto(int itemProduto)
    {
      CurrentPage = CurrentPage.As<SearchPage>().ClickProductList(itemProduto);
      LogHelpers.Write("clicar no produto");
      LogHelpers.PrintScreen();
    }

    [When(@"salvar as informações dos valores do produto")]
    public void QuandoSalvarAsInformacoesDosValoresDoProduto()
    {
      CurrentPage.As<ProductPage>().GetPriceProduct();
      LogHelpers.Write("salvar as informações dos valores do produto");
      LogHelpers.PrintScreen();
    }

    [When(@"clicar no botão adicionar ao carrinho")]
    public void QuandoClicarNoBotaoAdicionarAoCarrinho()
    {
      string price = CurrentPage.As<ProductPage>().SetPriceProduct();
      string subscriberPrice = CurrentPage.As<ProductPage>().SetSubscriberPriceProduct();
      CurrentPage = CurrentPage.As<ProductPage>().AddToCart();
      CurrentPage.As<MyCartPage>().SetPriceCart(price, subscriberPrice);
      LogHelpers.Write("clicar no botão adicionar ao carrinho");
      LogHelpers.PrintScreen();
    }

    [Then(@"Devo visualizar o\(s\) produto\(s\) no meu carrinho (.*)")]
    public void EntaoDevoVisualizarOSProdutoSNoMeuCarrinho(string produto)
    {
      CurrentPage.As<MyCartPage>().ExistItemInMyCart(produto);
      LogHelpers.Write("Visualizar produto(s) no carrinho");
      LogHelpers.PrintScreen();
    }

    [Then(@"Devo verificar se os valores não foram alterados")]
    public void EntaoDevoVerificarSeOsValoresNaoForamAlterados()
    {
      CurrentPage.As<MyCartPage>().ComparePriceProduct();
      CurrentPage.As<MyCartPage>().ComparesubscriberPriceProduct();
      LogHelpers.Write("Checar valores de venda e assinante");
      LogHelpers.PrintScreen();
    }
  }
}
