using System;

namespace ArdalisRating
{
    public class AutoPolicy : IPolicy
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
        public int Deductible { get; set; }
        public PolicyType Type { get; set; }
        private ILogger Logger { get; }

        public AutoPolicy(ILogger logger)
        {
            this.Logger = logger;
        }

        public bool IsValid()
        {
            var valid = true;
            if (String.IsNullOrEmpty(Make))
            {
                Logger.Log("Auto policy must specify Make");
                valid = false;
            }
            return valid;
        }

        public decimal Rate()
        {
            var rating = 0m;
            if (!IsValid())
            {
                return 0m;
            }
            if (Make == "BMW")
            {
                rating = 900m;
                if (Deductible < 500)
                {
                    rating = 1000m;
                }
            }
            return rating;
        }
    }
}