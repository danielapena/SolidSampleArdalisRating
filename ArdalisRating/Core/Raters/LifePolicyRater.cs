using System;

namespace ArdalisRating
{
    public class LifePolicyRater : IRater, IPolicy 
    {
        private ILogger _logger { get; }

        public LifePolicyRater(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsValid(Policy policy)
        {
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                _logger.Log("Life policy must include Date of Birth.");
                return false;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _logger.Log("Centenarians are not eligible for coverage.");
                return false;
            }
            if (policy.Amount == 0)
            {
                _logger.Log("Life policy must include an Amount.");
                return false;
            }
            return true;
        }

        public decimal Rate(Policy policy)
        {
            if (!IsValid(policy))
            {
                return 0m;
            }

            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }

            var baseRate = policy.Amount * age / 200;
            var rating = baseRate;
            if (policy.IsSmoker)
            {
                rating = baseRate * 2;
            }
            return rating;
        }
    }
}