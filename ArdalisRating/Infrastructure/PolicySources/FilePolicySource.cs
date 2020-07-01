using System.IO;

namespace ArdalisRating
{
    public class FilePolicySource: IPolicySource
    {
        private readonly string _source;

        public FilePolicySource(string source) => _source = source;
        public string GetFromSource() => File.ReadAllText(_source);
    }
}