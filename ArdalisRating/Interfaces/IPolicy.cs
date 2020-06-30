namespace ArdalisRating
{
    public interface IPolicy
    {
        public PolicyType Type { get; set; }
        public bool IsValid();
        public decimal Rate();
    }
}