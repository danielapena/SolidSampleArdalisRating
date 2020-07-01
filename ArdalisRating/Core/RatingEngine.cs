namespace ArdalisRating
{
    public class RatingEngine
    {
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly ILogger _logger;
        private readonly RaterFactory _rateFactory;

        public RatingEngine(IPolicySource policySource,
                            IPolicySerializer policySerializer,
                            ILogger logger,
                            RaterFactory raterFactory)
        {
            _policySource = policySource;
            _policySerializer = policySerializer;
            _logger = logger;
            _rateFactory = raterFactory;
        }

        public decimal Rate()
        {
            _logger.Log("Starting Rate");
            _logger.Log("Loading policy...");
            
            var policySource = _policySource.GetFromSource();
            var policy = _policySerializer.GetPolicyFromString(policySource);
            var rater = _rateFactory.Create(policy);

            _logger.Log("Rating policy...");
            var rating = rater.Rate(policy);

            _logger.Log("Rating completed.");
            return rating;
        }        
    }
}