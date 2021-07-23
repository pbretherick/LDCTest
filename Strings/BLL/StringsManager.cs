using System.Collections.Generic;
using Strings.BLL.StringProcessors;
using System.Linq;

namespace Strings.BLL
{
    public class StringsManager : IStringsManager
    {
        public List<string> Process(List<string> strings)
        {
            var returnStrings = new List<string>();
            if (strings != null && strings.Count() > 0)
            {
                var stringProcessor = new DuplicateCharacterProcessor()
                    .SetNext(new ReplaceCharacterProcessor("$", "£"))
                    .SetNext(new ReplaceCharacterProcessor("_", string.Empty))
                    .SetNext(new ReplaceCharacterProcessor("4", string.Empty));

                strings.ForEach(s => returnStrings.Add(stringProcessor.Process(s)));
            }

            return returnStrings.Where(s => !string.IsNullOrEmpty(s)).ToList();
        }
    }
}
