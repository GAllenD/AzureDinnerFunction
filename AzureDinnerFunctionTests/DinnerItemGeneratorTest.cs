using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AzureDinnerFunction;
using System.Linq;

namespace AzureDinnerFunctionTests
{
    [TestClass]
    public class DinnerItemGeneratorTest
    {
        private DinnerItemGenerator generator;

        public DinnerItemGeneratorTest() => generator = new DinnerItemGenerator();

        [TestMethod]
        public void ShouldGenerateListOfItems()
        {
            Assert.AreEqual(15, generator.GetDinnerOptions(15).Count);
        }
    }
}
