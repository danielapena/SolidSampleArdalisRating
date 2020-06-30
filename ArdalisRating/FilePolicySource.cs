using System.IO;

namespace ArdalisRating
{
    public class FilePolicySource: IPolicySource
    {
        public string GetFromSource(string source){            
            return File.ReadAllText(source);
        }
    }
}