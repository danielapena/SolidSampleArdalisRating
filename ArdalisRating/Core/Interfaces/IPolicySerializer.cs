namespace ArdalisRating
{
    public interface IPolicySerializer
    {
        public Policy GetPolicyFromString(string input);
    }
}