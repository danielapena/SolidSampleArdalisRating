using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        private readonly ILogger _logger;

        public RaterFactory(ILogger logger)
        {
            _logger = logger;
        }

        public IRater Create(Policy policy){
            try{
                return (IRater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                        new Object[] { _logger });

            }catch{
                return null;
                // TODO: refactor to unknown type rater class
            }
        }
    }
}