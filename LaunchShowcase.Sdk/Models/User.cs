namespace LaunchShowcase.Sdk.Models
{
    public class User
    {
        public User(int id, string name, string discordId)
        {
            Id = id;
            Name = name;
            DiscordId = discordId;
        }

        public User()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string DiscordId { get; set; }

        public string Email { get; set; }
    }
}