using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        private readonly ILogger _Logger;
        public RatingEngineRate()
        {
            _Logger = new ConsoleLogger();
        }
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new LandPolicy(_Logger)
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };

            var result = policy.Rate();

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new LandPolicy(_Logger)
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };

            var result = policy.Rate();

            Assert.Equal(0m, result);
        }

        // [Fact]
        // public void ReturnsDefaultPolicyFromEmptyJsonString(){
        //     var inputJson = "{}";
        //     var serializer = new JsonPolicySerializer();
        //     var defaultPolicy = new Policy();

        //     var policy = serializer.GetPolicyFromJsonString(inputJson);

        //     Assert.True(defaultPolicy.Equals(policy));
        // }
    }
}
