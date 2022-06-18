using Microsoft.Extensions.Logging;
using SemanticAnalyzer.Interfaces;

namespace SemanticAnalyzer
{
    public class SemanticAnalyzer : ISemanticAnalyzer
    {
        private ILogger<SemanticAnalyzer> _logger;

        public SemanticAnalyzer(ILogger<SemanticAnalyzer> logger)
        {
            _logger = logger;
        }

        public bool Validate(String text, String characterPairs)
        {
            throw new NotImplementedException();
        }
    }
}