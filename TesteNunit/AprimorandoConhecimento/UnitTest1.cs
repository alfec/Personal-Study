using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AprimorandoConhecimento
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Iniciar()
        {

        }

        [TestMethod, TestCategory("jorge")]
        public void TestMethod1()
        {
        }

        [TestMethod, TestCategory("jorge")]
        public void TestMethod2()
        {
        }

        [TestMethod, TestCategory("bogola")]
        public void TestMethod3()
        {
        }

        [TestMethod, TestCategory("bogola")]
        public void TestMethod4()
        {
        }
        
        [TestCleanup]
        public void Encerrar()
        {

        }
    }
}
