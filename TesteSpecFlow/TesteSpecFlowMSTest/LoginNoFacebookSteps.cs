using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteSpecFlowMSTest
{
    [Binding]
    public class LoginNoFacebookSteps
    {
        private IWebDriver browser;
        
        [Given(@"que estou na tela de login")]
        public void DadoQueEstouNaTelaDeLogin()
        {
            browser.Navigate().GoToUrl("https://www.facebook.com/");
        }
        
        [When(@"eu colocar meu login")]
        public void QuandoEuColocarMeuLogin()
        {
            IWebElement email = browser.FindElement(By.Id("email"));
            email.SendKeys("andreluiz217@gmail.com");
        }
        
        [When(@"a minha senha")]
        public void QuandoAMinhaSenha()
        {
            IWebElement senha = browser.FindElement(By.Id("pass"));
            senha.SendKeys("1573ALfc");
        }
        
        [When(@"clicar em entrar")]
        public void QuandoClicarEmEntrar()
        {
            IWebElement botao = browser.FindElement(By.Id("loginbutton"));
            botao.Click();
        }
        
        [Then(@"eu devo fazer o login no sistema")]
        public void EntaoEuDevoFazerOLoginNoSistema()
        {
            IWebElement confirmacao = browser.FindElement(By.XPath("//*[@id='js_5']/div/div/div[1]/div[1]/h1/a"));
            Assert.AreEqual(true, confirmacao);
        }
    }
}
