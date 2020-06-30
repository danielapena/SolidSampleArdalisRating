using System;

namespace ArdalisRating
{
    public class LifePolicy : IPolicy 
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
        public PolicyType Type { get; set; }
        private ILogger Logger { get; }

        public LifePolicy(ILogger logger)
        {
            Logger = logger;
        }

        public bool IsValid()
        {
            if (this.DateOfBirth == DateTime.MinValue)
            {
                Logger.Log("Life policy must include Date of Birth.");
                return false;
            }
            if (this.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                Logger.Log("Centenarians are not eligible for coverage.");
                return false;
            }
            if (this.Amount == 0)
            {
                Logger.Log("Life policy must include an Amount.");
                return false;
            }
            return true;
        }

        public decimal Rate()
        {
            if (!IsValid())
            {
                return 0m;
            }

            int age = DateTime.Today.Year - this.DateOfBirth.Year;
            if (this.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < this.DateOfBirth.Day ||
                DateTime.Today.Month < this.DateOfBirth.Month)
            {
                age--;
            }

            var baseRate = this.Amount * age / 200;
            var rating = baseRate;
            if (this.IsSmoker)
            {
                rating = baseRate * 2;
            }
            return rating;
        }
    }
}
