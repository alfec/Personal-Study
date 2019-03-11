using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System.Drawing.Imaging;
using System.Threading;

namespace SecondPage
{
    class SecondPage
    {
        static void Main()
        {

            IWebDriver browser = new ChromeDriver();

            browser.Navigate().GoToUrl("https://www.google.com.br/"); //acessa o navegador

            IWebElement pesquisar = browser.FindElement(By.Name("q")); // Procura pelo nome da barra de pesquisa

            if (pesquisar.Displayed)
            {
                System.Console.WriteLine("Encontrou A BARRA");

                pesquisar.SendKeys("Summoners War"); //digita na barra

                Thread.Sleep(500);

                Actions clique = new Actions(browser); // cria um obj para fazer uma ação
                IWebElement botao = browser.FindElement(By.XPath("//*[@id='tsf']/div[2]/div/div[3]/center/input[1]"));
                System.Console.WriteLine("Encontrou o botão");

                browser.FindElement(By.XPath("//*[@id='gsr']")).Click();
                clique.Click(botao).Perform();

                Thread.Sleep(1000);

                browser.TakeScreenshot().SaveAsFile("C:\\personal study\\AutomationQA\\AutomationQA\\ScreenShot\\sreenshot.jpeg", ScreenshotImageFormat.Png);

                Screenshot ss = ((ITakesScreenshot)browser).GetScreenshot();
                string shot = "C:\\personal study\\AutomationQA\\AutomationQA\\ScreenShot\\sreenshot.png";
                ss.SaveAsFile(shot, ScreenshotImageFormat.Png);
                browser.Quit();
            }
            else
            {
                System.Console.WriteLine("Deu ruim e não achou nada");
                browser.Quit();
            }
            


        }
    }
}
