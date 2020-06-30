namespace ArdalisRating
{
    public class LandPolicy: IPolicy
    {
        public string Address { get; set; }
        public decimal Size { get; set; }
        public decimal Valuation { get; set; }
        public decimal BondAmount { get; set; }
        public PolicyType Type { get; set; }
        private ILogger Logger { get; }

        public LandPolicy(ILogger logger)
        {
            Logger = logger;
        }

        public bool IsValid()
        {
            if (this.BondAmount == 0 || this.Valuation == 0)
            {
                Logger.Log("Land policy must specify Bond Amount and Valuation.");
                return false;
            }
            if (this.BondAmount < 0.8m * this.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
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
            return BondAmount * 0.05m;
        }
    }
}
