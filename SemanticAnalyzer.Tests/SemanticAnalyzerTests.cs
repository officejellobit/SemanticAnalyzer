using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemanticAnalyzer.Interfaces;

#nullable disable

namespace SemanticAnalyzer.Tests
{
    [TestClass]
    public class SemanticAnalyzerTests
    {
        private ISemanticAnalyzer _semanticAnalyzer;

        [TestInitialize]
        public void Initialize()
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<ISemanticAnalyzer, SemanticAnalyzer>();
            }).Build();

            _semanticAnalyzer = host.Services.GetRequiredService<ISemanticAnalyzer>();
        }

        [TestMethod]
        public void Validate_OnePair_OK()
        {
            Assert.IsTrue(_semanticAnalyzer.Validate("(This looks great!)", "()"));
        }

        [TestMethod]
        public void Validate_OnePair_NotOK()
        {
            Assert.IsFalse(_semanticAnalyzer.Validate("(This looks bad!", "()"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Validate_NoPairs_Error()
        {
           _semanticAnalyzer.Validate("(This has no pairs!)", "()[");
        }

        [TestMethod]
        public void Validate_TwoPairs_OK()
        {
            Assert.IsTrue(_semanticAnalyzer.Validate("(This [looks] great!)", "()[]"));
        }

        [TestMethod]
        public void Validate_TwoPairs_NotOK()
        {
            Assert.IsFalse(_semanticAnalyzer.Validate("(This [looks) bad!]", "()[]"));
        }

        [TestMethod]
        public void Validate_ThreePairs_OK()
        {
            Assert.IsTrue(_semanticAnalyzer.Validate("(This {[looks], [great]}!)", "()[]{}"));
        }

        [TestMethod]
        public void Validate_ThreePairs_NotOK()
        {
            Assert.IsFalse(_semanticAnalyzer.Validate("(This {[looks], [bad])!", "()[]{}"));
        }
    }
}