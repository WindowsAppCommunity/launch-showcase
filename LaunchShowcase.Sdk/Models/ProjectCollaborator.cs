namespace LaunchShowcase.Sdk.Models
{
    public class ProjectCollaborator : User
    {
        public ProjectCollaborator(int id, string name, string discordId)
            : base(id, name, discordId)
        {
        }

        public bool IsOwner { get; set; }

        public Role Role { get; set; }
    }
}