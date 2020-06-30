namespace ArdalisRating
{
    public interface IPolicySource
    {
        public string GetFromSource(string sourceName);
    }
}