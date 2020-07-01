using Newtonsoft.Json;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRateTests
    {        
        private RatingEngine _engine = null;
        private FakeLogger _logger;
        private FakePolicySource _policySource;
        private JsonPolicySerializer _policySerializer;

        public RatingEngineRateTests()
        {
            _logger = new FakeLogger();
            _policySource = new FakePolicySource();
            _policySerializer = new JsonPolicySerializer();

            _engine = new RatingEngine(_policySource, _policySerializer, _logger,
                new RaterFactory(_logger));
        }

        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy()
            {
                Type = "Land",
                BondAmount = 200000,
                Valuation = 200000
            };

            string json = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = json;
            var result = _engine.Rate();

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy()
            {
                Type = "Land",
                BondAmount = 200000,
                Valuation = 260000
            };

            string json = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = json;

            var result = _engine.Rate();

            Assert.Equal(0m, result);
        }

        [Fact]
        public void ReturnsDefaultPolicyFromEmptyJsonString(){
            var inputJson = "{}";
            var defaultPolicy = new Policy();

            var policy = _policySerializer.GetPolicyFromString(inputJson);

            AssertPoliciesEqual(defaultPolicy, policy);
        }

        private static void AssertPoliciesEqual(Policy result, Policy policy)
        {
            Assert.Equal(policy.Address, result.Address);
            Assert.Equal(policy.Amount, result.Amount);
            Assert.Equal(policy.BondAmount, result.BondAmount);
            Assert.Equal(policy.DateOfBirth, result.DateOfBirth);
            Assert.Equal(policy.Deductible, result.Deductible);
            Assert.Equal(policy.FullName, result.FullName);
            Assert.Equal(policy.IsSmoker, result.IsSmoker);
            Assert.Equal(policy.Make, result.Make);
            Assert.Equal(policy.Miles, result.Miles);
            Assert.Equal(policy.Model, result.Model);
            Assert.Equal(policy.Type, result.Type);
            Assert.Equal(policy.Valuation, result.Valuation);
            Assert.Equal(policy.Year, result.Year);
        }
    }
}
