using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main()
        {
            var logger = new ConsoleLogger();
            logger.Log("Ardalis Insurance Rating System Starting...");

            logger.Log("Loading policy.");
            var policy = LoadPolicy();

            logger.Log("Rating policy...");
            logger.Log("Starting rate.");
            if (!policy.IsValid())
            {
                logger.Log("Unknown policy type");
            }

            var rating = policy.Rate();

            if (rating > 0)
            {
                logger.Log($"Rating: {rating}");
            }
            else
            {
                logger.Log("No rating produced.");
            }

        }

        private static IPolicy LoadPolicy()
        {
            var sourceName = "policy.json";
            var policySource = new FilePolicySource().GetFromSource(sourceName);
            JsonPolicySerializer jsonPolicySerializer = new JsonPolicySerializer();
            return jsonPolicySerializer.GetPolicyFromJsonString(policySource);
        }
    }
}
