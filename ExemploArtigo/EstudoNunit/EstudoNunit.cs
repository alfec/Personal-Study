using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoNunit
{
    [TestFixture("Classe1")]
    public class EstudoNunit
    {
        private IWebDriver browser;

        [SetUp]
        public void Iniciar()
        {

        }

        [Test]
        public void Method2()
        {

        }
        
        [TearDown]
        public void Finalizar()
        {

        }
    }

    [TestFixture("Classe2")]
    public class EsutdoNunit2
    {
        private IWebDriver browser;

        [SetUp]
        public void Iniciar()
        {

        }

        [Test]
        public void Method1()
        {

        }
        
        [TearDown]
        public void Finalizar()
        {

        }
    }
}
