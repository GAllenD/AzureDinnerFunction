using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AzureDinnerFunction;

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
            Assert.AreEqual(3, generator.GetDinnerOptions(3));
        }
    }
}
