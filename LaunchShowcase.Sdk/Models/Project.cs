using Newtonsoft.Json;
using System;

namespace LaunchShowcase.Sdk.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string AppName { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public string DownloadLink { get; set; }

        public string GithubLink { get; set; }

        public string ExternalLink { get; set; }

        public string HeroImage { get; set; }

        public string[] Images { get; set; }

        public string AppIcon { get; set; }

        public string AccentColor { get; set; }

        public bool? AwaitingLaunchApproval { get; set; }

        public bool NeedsManualReview { get; set; }

        public string LookingForRoles { get; set; }

        public ProjectCollaborator[] Collaborators { get; set; }

        public Tag[] Tags { get; set; }

        public string Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
