namespace ArdalisRating
{
    public class LandPolicyRater: IRater, IPolicy
    {
        private ILogger _logger { get; }

        public LandPolicyRater(ILogger logger)
        {
            _logger = logger;
        }
        public decimal Rate(Policy policy)
        {
            if (!IsValid(policy))
            {
                return 0m;
            }
            return policy.BondAmount * 0.05m;
        }

        public bool IsValid(Policy policy)
        {
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Log("Land policy must specify Bond Amount and Valuation.");
                return false;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logger.Log("Insufficient bond amount.");
                return false;
            }
            return true;
        }
    }
}