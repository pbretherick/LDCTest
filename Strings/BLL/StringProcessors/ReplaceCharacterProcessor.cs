namespace Strings.BLL.StringProcessors
{
    public class ReplaceCharacterProcessor : StringProcessor
    {
        private string _findCharacter;

        private string _replaceCharacter;

        public ReplaceCharacterProcessor(string findCharacter, string replaceCharacter)
        {
            _findCharacter = findCharacter;
            _replaceCharacter = replaceCharacter;
        }

        protected override string ProcessString(string stringToProcess)
        {
            return stringToProcess.Replace(_findCharacter, _replaceCharacter);
        }
    }
}