using LaunchShowcase.Sdk.Services;
using System.Collections.Generic;

namespace LaunchShowcase.Sdk.Data.LaunchScoring
{
    public static partial class LaunchData
    {
        /// <summary>
        /// The score for each project in each category. The inner dictionary is keyed by project's ID, the value is compound score from all judges.
        /// </summary>
        /// <remarks>
        /// We aren't storing or pulling this data from the backend.
        /// We could have used JSON, but there's no reason to add deserialization weight.
        /// </remarks>
        public static Dictionary<LaunchScoringCategory, Dictionary<int, int>> Scoring { get; } = new Dictionary<LaunchScoringCategory, Dictionary<int, int>>
        {
            { LaunchScoringCategory.Accessiblity, AccessibilityScoring },
            { LaunchScoringCategory.Beauty, BeautyScoring },
            { LaunchScoringCategory.Empathy, EmpathyScoring },
            { LaunchScoringCategory.Flexibility, FlexibilityScoring },
            { LaunchScoringCategory.Originality, OriginalityScoring },
            { LaunchScoringCategory.Potential, PotentialScoring },
        };
    }
}
