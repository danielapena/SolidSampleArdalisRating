namespace ArdalisRating.Tests
{
    public class FakePolicySource: IPolicySource
    {
        public string PolicyString { get; set; } = "";

        public string GetFromSource() => PolicyString;
    }
}