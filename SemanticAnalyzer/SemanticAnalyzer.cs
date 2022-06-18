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
            // validation
            if (characterPairs.Length % 2 > 0)
                throw new ArgumentException("no pairs sepecified", nameof(characterPairs));

            // store characterPairs structured
            var pairs = (from pair in characterPairs.Chunk(2)
                         where pair.Length == 2
                         select new CharacterPair(pair.First(), pair.Last())).ToList();

            var closingCharStack = new Stack<Char>();

            foreach (var currentChar in text)
            {
                // if opening character is found put closing character to stack
                var openingMatch = pairs.FirstOrDefault(p => p.OpeningChar == currentChar);
                if (openingMatch != null)
                {
                    closingCharStack.Push(openingMatch.ClosingChar);
                    continue;
                }

                // if closing character is found popped stack entry has to match
                var closingMatch = pairs.FirstOrDefault(p => p.ClosingChar == currentChar);
                if (closingMatch != null && (!closingCharStack.Any() || closingCharStack.Pop() != closingMatch.ClosingChar))
                    return false;
            }

            // only valid if no more closing character are in stack
            return !closingCharStack.Any();
        }
    }
}