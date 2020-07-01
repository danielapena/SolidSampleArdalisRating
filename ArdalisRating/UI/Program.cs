namespace ArdalisRating
{
    class Program
    {
        static void Main()
        {
            var logger = new ConsoleLogger();
            logger.Log("Ardalis Insurance Rating System Starting...");

            logger.Log("Loading policy.");
            var engine = new RatingEngine(
                new FilePolicySource("policy.json"),
                new JsonPolicySerializer(),
                logger,
                new RaterFactory(logger));

            var rating = engine.Rate();

            if (rating > 0)
            {
                logger.Log($"Rating: {rating}");
            }
            else
            {
                logger.Log("No rating produced.");
            }

        }
    }
}