namespace Project.Entities
{
    
    public struct Player
    {
        public string Id;
        public string Email;
        public string Password;
        public string Name;
        public string LastName;
        public string Age;
        public string Gender;
        public string Created;
        public string Updated;

        public Player(string id, string email, string password, string name,
            string lastName, string age, string gender, string created, string updated)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Created = created;
            Updated = updated;
        }

        public Player(string email, string password, string name,
            string lastName, string age, string gender)
        {
            Id = "";
            Email = email;
            Password = password;
            Name = name;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Created = "";
            Updated = "";

        }
    }
}
