using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace SecondPage
{
    class SecondPage
    {
        static void Main()
        {

            IWebDriver browser = new ChromeDriver();

            browser.Navigate().GoToUrl("www.google.com.br"); //acessa o navegador

            Thread.Sleep(2000);

            IWebElement pesquisar = browser.FindElement(By.Name("q")); // Procura pelo nome da barra de pesquisa

            if (pesquisar.Displayed)
            {
                System.Console.WriteLine("eNCONTROU A BARRA");

                Thread.Sleep(2500);

                pesquisar.SendKeys("Summoners War"); //digita na barra

                Actions clique = new Actions(browser); // cria um obj para fazer uma ação
                IWebElement botao = browser.FindElement(By.Name("btnK"));
                clique.Click(botao);

                browser.SaveAsFile(String, ScreenshotImageFormat);
            }
            else
            {
                System.Console.WriteLine("Deu ruim e não achou nada");
            }
            


        }
    }
}
