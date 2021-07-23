using System.Linq;

namespace Strings.BLL.StringProcessors
{
    public abstract class StringProcessor
    {
        protected StringProcessor _next;
 
        public StringProcessor()
        {
        }

        public StringProcessor SetNext(StringProcessor nextlogger)
        {
            StringProcessor lastLogger = this;

            while (lastLogger._next != null)
            {
                lastLogger = lastLogger._next;
            }

            lastLogger._next = nextlogger;

            return this;
        }
 
        public string Process(string stringToProcess)
        {
            if (!string.IsNullOrEmpty(stringToProcess))
            {
                stringToProcess = ProcessString(stringToProcess);

                if (_next != null && !string.IsNullOrEmpty(stringToProcess)) 
                {
                    stringToProcess = _next.Process(stringToProcess); 
                }
                else if(_next == null)
                {
                    stringToProcess = stringToProcess.Length > 15 ? stringToProcess.Substring(0, 15) : stringToProcess;
                }
            }

            return stringToProcess;
        }
 
        abstract protected string ProcessString(string stringToProcess);
    }

}