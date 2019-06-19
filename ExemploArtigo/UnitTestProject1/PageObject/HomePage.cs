using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POMtest.PageObject
{
    class HomePage
    {
        private IWebDriver browser;

        public HomePage(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
        }

        public void NavegaTo()
        {
            browser.Navigate().GoToUrl("https://www.linkedin.com/");
            Thread.Sleep(1000);
        }

        public void FazLogin()
        {
            IWebElement signIn = browser.FindElement(By.XPath("/html/body/nav/a[3]"));
            signIn.Click();

            IWebElement email = browser.FindElement(By.Id("username"));
            email.SendKeys("andreluiz217@gmail.com");

            IWebElement password = browser.FindElement(By.Id("password"));
            password.SendKeys("1573alfc");

            IWebElement botao = browser.FindElement(By.XPath("//*[@id='app__container']/main/div/form/div[3]/button"));
            botao.Click();

            Thread.Sleep(5000);
        }
    }
}
