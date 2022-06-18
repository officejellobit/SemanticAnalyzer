namespace SemanticAnalyzer
{
    /// <summary>
    /// helper class for holding the combination of opening and closing character
    /// </summary>
    internal class CharacterPair
    {
        public Char OpeningChar { get; }
        public Char ClosingChar { get; }

        public CharacterPair(Char openingChar, Char closingChar)
        {
            OpeningChar = openingChar;
            ClosingChar = closingChar;
        }
    }
}
