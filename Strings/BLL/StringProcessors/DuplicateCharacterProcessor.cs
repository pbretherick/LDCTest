namespace Strings.BLL.StringProcessors
{
    public class DuplicateCharacterProcessor : StringProcessor
    {
        protected override string ProcessString(string stringToProcess)
        {
            var returnString = string.Empty;
            char? lastChar = null;
            var chars = stringToProcess.ToCharArray();

            foreach(var chr in stringToProcess.ToCharArray())
            {
                returnString += char.IsLetter(chr) && chr == lastChar ? string.Empty : chr;
                lastChar = chr;
            }

            return returnString;
        }
    }
}