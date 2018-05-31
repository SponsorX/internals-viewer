using InternalsViewer.Internals.Engine.Parsers.PageParsers;
using InternalsViewer.Internals.Engine.Readers.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Parsers.PageParsers
{
    [TestClass]
    public class AllocationMapParserTests
    {
        [TestMethod]
        public void Can_Parse_Gam()
        {
            var page = new FilePageReader().Read(@".\TestPages\Allocation\GamPage1.txt");

            var result = new AllocationMapParser().Parse(page);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Can_Parse_SGam()
        {
            var page = new FilePageReader().Read(@".\TestPages\Allocation\SGamPage1.txt");

            var result = new AllocationMapParser().Parse(page);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Can_Parse_Bcm()
        {
            var page = new FilePageReader().Read(@".\TestPages\Allocation\BcmPage1.txt");

            var result = new AllocationMapParser().Parse(page);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Can_Parse_Dcm()
        {
            var page = new FilePageReader().Read(@".\TestPages\Allocation\DcmPage1.txt");

            var result = new AllocationMapParser().Parse(page);

            Assert.IsNotNull(result);
        }
    }
}