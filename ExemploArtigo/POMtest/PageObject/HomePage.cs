using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public void FazLogin()
        {
            IWebElement signIn = browser.FindElement(By.LinkText("https://www.linkedin.com/start/join?trk=guest_homepage-basic_nav-header-join"));
            signIn.Click();

            IWebElement email = browser.FindElement(By.Id("username"));
            email.SendKeys("andreluiz217@gmail.com");

            IWebElement password = browser.FindElement(By.Id("password"));
            password.SendKeys("1573ALfc");

            IWebElement botao = browser.FindElement(By.ClassName("btn__primary--large from__button--floating"));
            botao.Click();
        }
    }
}
