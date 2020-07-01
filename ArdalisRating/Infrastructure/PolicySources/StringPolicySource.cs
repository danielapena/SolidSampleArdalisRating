namespace ArdalisRating
{
    public class StringPolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = "";

        public string GetFromSource() => PolicyString;
    }
}