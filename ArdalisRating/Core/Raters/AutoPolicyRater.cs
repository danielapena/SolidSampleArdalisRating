namespace ArdalisRating
{
    public class AutoPolicyRater : IRater, IPolicy
    {
        private ILogger _logger { get; set; }

        public AutoPolicyRater(ILogger logger)
        {
            this._logger = logger;
        }

        public bool IsValid(Policy policy)
        {
            var valid = true;
            if (string.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
                valid = false;
            }
            return valid;
        }

        public decimal Rate(Policy policy)
        {

            if (!this.IsValid(policy))
            {
                return 0m;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    return 1000m;
                }
                return 900m;
            }

            return 0m;
        }
    }
}