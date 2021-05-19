using NUnit.Framework;
using SeleniumBasicProjectConfiguration.Base;
using SeleniumBasicProjectConfiguration.Helpers;
using SeleniumUnitTestProjetc.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumUnitTestProjetc.Extensions
{
  [Binding]
  public class StepsExtensions : BaseSteps
  {
    internal string TestCase;

    [Given(@"Que eu esteja na tela principal")]
    public void GivenQueEuEstejaNaTelaPrincipal()
    {
      Navigate();
      CurrentPage = GetInstance<HomePage>();
      CurrentPage.As<HomePage>().CheckCurrentPage();
      LogHelpers.Write("Verifica se está na página principal");
      LogHelpers.PrintScreen();
    }
  }
}