using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace CorrecaoTesteAC2
{
    [TestClass]
    public class US2
    {
        private IWebDriver browser;
        public string pastaPrint;
        int x = 1;
        int y = 1;

        [TestInitialize]
        public void Iniciar()
        {
            browser = new ChromeDriver();

            browser.Navigate().GoToUrl("https://qa-test.avenuecode.com/"); //   
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

            //Clica no botão Manage Tasks
            IWebElement manageTasks = browser.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div/table/tbody/tr[1]/td[4]/button"));
            manageTasks.Click();
        }

        [TestMethod]
        public void CriaNovaSubTasks()
        {
            IWebElement subTasksDescr = browser.FindElement(By.XPath("//*[@id='new_sub_task']")); //Cria o textarea subtaskDescription
            IWebElement dueDate = browser.FindElement(By.XPath("//*[@id='dueDate']")); //Cria o textarea Due Date
            IWebElement addMais = browser.FindElement(By.XPath("//*[@id='add-subtask']")); //Cria o botão +Add

            subTasksDescr.SendKeys("Han Solo");
            dueDate.SendKeys("12/12/2019");
            addMais.Click();
            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[4]/div/div")).Text;
            Assert.AreEqual("Han Solo", texto);

        }

        [TestMethod]
        public void ValidacaoSemNome()
        {
            IWebElement subTasksDescr = browser.FindElement(By.XPath("//*[@id='new_sub_task']")); //Cria o textarea subtaskDescription
            IWebElement dueDate = browser.FindElement(By.XPath("//*[@id='dueDate']")); //Cria o textarea Due Date
            IWebElement addMais = browser.FindElement(By.XPath("//*[@id='add-subtask']")); //Cria o botão +Add

            subTasksDescr.SendKeys("");
            dueDate.SendKeys("12/12/2019");
            addMais.Click();
            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[1]/div[2]/div[2]/div/table/tbody/tr[" + y++ + "]/td[2]/a")).Text;
            Assert.AreNotEqual(texto, "empty");
        }

        [TestMethod]
        public void NomeSubMtoGrande()
        {
            //VALIDAÇÃO SUBTASK COM NOME MUITO GRANDE
            IWebElement subTasksDescr = browser.FindElement(By.XPath("//*[@id='new_sub_task']")); //Cria o textarea subtaskDescription
            IWebElement dueDate = browser.FindElement(By.XPath("//*[@id='dueDate']")); //Cria o textarea Due Date
            IWebElement addMais = browser.FindElement(By.XPath("//*[@id='add-subtask']")); //Cria o botão +Add

            subTasksDescr.SendKeys("Cheeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeewbbaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaacaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            dueDate.SendKeys("12/12/2019");
            addMais.Click();
            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[4]/div/div")).Text;
            Assert.AreNotEqual(texto, "Cheeeeeeeeeeeeeeeeeeeeeeeee" +
                "eeeeeeeeeeeeeeeeeeeeewbbaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaacaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }

        [TestMethod]
        public void MascaraErradaDate()
        {
            //VALIDAÇÃO MASCARA ERRADA PARA DUEDATE
            IWebElement subTasksDescr = browser.FindElement(By.XPath("//*[@id='new_sub_task']")); //Cria o textarea subtaskDescription
            IWebElement dueDate = browser.FindElement(By.XPath("//*[@id='dueDate']")); //Cria o textarea Due Date
            IWebElement addMais = browser.FindElement(By.XPath("//*[@id='add-subtask']")); //Cria o botão +Add

            subTasksDescr.SendKeys("Anakin");
            dueDate.SendKeys("0/42/209");
            addMais.Click();
            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[4]/div/div")).Text;
            Assert.AreNotEqual(texto, "Anakin");
        }

        [TestMethod]
        public void CriarSubSemDate()
        {
            //VALIDAÇÃO CRIAR SUBTASK SEM DATA
            IWebElement subTasksDescr = browser.FindElement(By.XPath("//*[@id='new_sub_task']")); //Cria o textarea subtaskDescription
            IWebElement dueDate = browser.FindElement(By.XPath("//*[@id='dueDate']")); //Cria o textarea Due Date
            IWebElement addMais = browser.FindElement(By.XPath("//*[@id='add-subtask']")); //Cria o botão +Add

            subTasksDescr.SendKeys("Captain Jean-Luc Picard");
            dueDate.SendKeys("");
            addMais.Click();
            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[4]/div/div")).Text;
            Assert.AreNotEqual(texto, "Captain Jean-Luc Picard");
        }

        [TestMethod]
        public void CriarSubBranco()
        {
            //VALIDAÇÃO SEM NOME E DATA
            IWebElement subTasksDescr = browser.FindElement(By.XPath("//*[@id='new_sub_task']")); //Cria o textarea subtaskDescription
            IWebElement dueDate = browser.FindElement(By.XPath("//*[@id='dueDate']")); //Cria o textarea Due Date
            IWebElement addMais = browser.FindElement(By.XPath("//*[@id='add-subtask']")); //Cria o botão +Add

            subTasksDescr.SendKeys("");
            dueDate.SendKeys("");
            addMais.Click();
            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[4]/div/div")).Text;
            Assert.AreNotEqual(texto, "Empty");
        }

        [TestMethod]
        public void CriarSubEnter()
        {
            //VALIDAÇÃO CRIANDO SUBTASK APERTANDO ENTER TECLADO
            IWebElement subTasksDescr = browser.FindElement(By.XPath("//*[@id='new_sub_task']")); //Cria o textarea subtaskDescription
            IWebElement dueDate = browser.FindElement(By.XPath("//*[@id='dueDate']")); //Cria o textarea Due Date
            //IWebElement addMais = browser.FindElement(By.XPath("//*[@id='add-subtask']")); //Cria o botão +Add

            subTasksDescr.SendKeys("Commander Riker");
            dueDate.SendKeys("12/12/2019");
            dueDate.SendKeys(Keys.Enter);
           // addMais.Click();
            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("//html/body/div[4]/div/div/div[2]/div[2]")).Text;
            Assert.AreNotEqual(texto, "Commander Riker");
        }

        [TestMethod]
        public void AlterarTaskName()
        {
            //VALIDAÇÃO para alterar o nome da task dentro da subtask no campo "Todo"
            IWebElement todo = browser.FindElement(By.XPath("//*[@id='edit_task']"));
            IWebElement fechar = browser.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/button"));
            todo.SendKeys("");
            todo.SendKeys("ALTERADO");
            fechar.Click();
            TiraPrint();
            Thread.Sleep(1000);

            var texto = browser.FindElement(By.XPath("/html/body")).Text;
            Assert.AreNotEqual(texto, "ALTERADO");
        }

        public void TiraPrint()
        {
            Screenshot ss = ((ITakesScreenshot)browser).GetScreenshot();
            string shot = "C:\\Users\\bogola\\Desktop\\Automação\\CorrecaoTesteAC\\US2\\screenshot\\US2_Imagem_ " + x + ".png";
            ss.SaveAsFile(shot, ScreenshotImageFormat.Png);
            x++;
        }

        [TestCleanup]
        public void Finalizar()
        {
            browser.Quit();
        }

    }
}
