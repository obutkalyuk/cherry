namespace Project.Entities
{
    
    public struct Bonus
    {
        public string Id;
        public string Name;
        public string Type;
        public string Reward;
        public bool IsPercentage;
        public string Currency;
        public string Wagering;
        public string Minimum;
        public string Status;

        public Bonus(string id, string name, string type, string reward, 
            bool isPercentage, string currency, string wagering, string minimum, string status)
        {
            Id = id;
            Name = name;
            Type = type;
            Reward = reward;
            IsPercentage = isPercentage;
            Currency = currency;
            Wagering = wagering;
            Minimum = minimum;
            Status = status;
        }

        public Bonus(string type, string reward, string name,
            bool isPercentage, string currency, string wagering, string minimum)
        {
            Id = "";
            Type = type;
            Reward = reward;
            Name = name;
            IsPercentage = isPercentage;
            Currency = currency;
            Wagering = wagering;
            Minimum = minimum;
            Status = "ACTIVE";

        }
    }
}
