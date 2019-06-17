using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace CorrecaoTesteAC
{
    [TestClass]
    public class US1
    {
        private IWebDriver browser;
        public string pastaPrint;
        int x = 1;


        [TestInitialize]
        public void Iniciar()
        {
            browser = new ChromeDriver();

            browser.Navigate().GoToUrl("https://qa-test.avenuecode.com/");
            browser.Manage().Window.Maximize();

            //Clica no botão Sign In na navbar
            IWebElement link = browser.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/ul[2]/li[1]/a"));
            link.Click();

            //Localiza e preenche o campo Email
            IWebElement email = browser.FindElement(By.Id("user_email"));
            email.SendKeys("andreluiz217@gmail.com");

            //Localiza e preenche o campo Password
            IWebElement senha = browser.FindElement(By.Id("user_password"));
            senha.SendKeys("1573alfc");

            //Clica no botão Sign in
            IWebElement signIn = browser.FindElement(By.XPath("//*[@id='new_user']/input"));
            signIn.Click();

            //Clica no botão Mytasks na navbar
            IWebElement myTasks = browser.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/ul[1]/li[2]/a"));
            myTasks.Click();

        }

        [TestMethod]
        public void CriarNovaTask()
        {
            IWebElement newTask = browser.FindElement(By.Id("new_task"));
            newTask.SendKeys("Nova Task");

            IWebElement botaoAdd = browser.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[2]/span"));
            botaoAdd.Click();

            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[1]/div[2]/div[2]/div/table/tbody/tr[1]/td[2]/a")).Text;
            Assert.AreEqual(texto, "Nova Task");
        }

        [TestMethod]
        public void ValidarNomePequeno()
        {
            //Validação nome com menos de 3 caracteres
            IWebElement newTask = browser.FindElement(By.Id("new_task"));
            newTask.SendKeys("AC");

            IWebElement botaoAdd = browser.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[2]/span"));
            botaoAdd.Click();

            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[1]/div[2]/div[2]/div/table/tbody/tr[1]/td[2]/a")).Text;
            Assert.AreNotEqual(texto, "AC");
        }

        [TestMethod]
        public void ValidarNomeGrande()
        {
            //Validação nome com mais de 250 caracteres
            IWebElement newTask = browser.FindElement(By.Id("new_task"));
            newTask.SendKeys("Lorem ipsum justo massa vestibulum ante platea semper leo, " +
                "senectus blandit scelerisque condimentum nunc curabitur in tristique malesuada, " +
                "ac integer non scelerisque lectus habitant egestas. at euismod ac" +
                "donec fames turpis curabitur at pulvinar augue");

            IWebElement botaoAdd = browser.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[2]/span"));
            botaoAdd.Click();

            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[1]/div[2]/div[2]/div/table/tbody/tr[1]/td[2]/a")).Text;
            Assert.AreNotEqual(texto, "Lorem ipsum justo massa vestibulum ante platea semper leo, " +
                "senectus blandit scelerisque condimentum nunc curabitur in tristique malesuada, " +
                "ac integer non scelerisque lectus habitant egestas. at euismod ac" +
                "donec fames turpis curabitur at pulvinar augue");
        }

        [TestMethod]
        public void CriarNovaTaskBranco()
        {
            IWebElement botaoAdd = browser.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/form/div[2]/span"));
            botaoAdd.Click();

            var texto = browser.FindElement(By.XPath("//html/body/div[1]/div[2]/div[2]/div")).Text;
            Assert.AreEqual(texto, "empty");
            
        }


        public void TiraPrint()
        {
            Screenshot ss = ((ITakesScreenshot)browser).GetScreenshot();
            string shot = "C:\\Users\\bogola\\Desktop\\Automação\\CorrecaoTesteAC\\CorrecaoTesteAC\\screenshot\\US1_Imagem_ " + x + ".png";
            ss.SaveAsFile(shot, ScreenshotImageFormat.Png);
            x++;
        }

        [TestCleanup]
        public  void Finalizar()
        {
            browser.Close();
        }
    }
}
