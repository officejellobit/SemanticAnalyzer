namespace SemanticAnalyzer.Interfaces
{
    /// <summary>
    /// performs semantic analysis based on given input texts
    /// </summary>
    public interface ISemanticAnalyzer
    {
        /// <summary>
        /// checks if for each opening character given in characterPairs there is a corresponding closing character (so that the characters are balanced)
        /// </summary>
        /// <param name="text">input text for which the semantic analysis is done</param>
        /// <param name="characterPairs">list of of opening and closing characters (for example "(){}")</param>
        /// <returns>true if characters are balanced, otherwise false</returns>
        bool Validate(String text, String characterPairs);
    }
}
