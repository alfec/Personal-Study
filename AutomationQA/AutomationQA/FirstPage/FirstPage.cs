using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace FirstPage
{
    class Program
    {
        static void Main()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.linkedin.com/in/alcarvalho3-1994/");
            Thread.Sleep(3000);

            driver.Quit();

        }
    }
}
