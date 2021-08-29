using System.Collections.Generic;

namespace LaunchShowcase.Sdk.Data.LaunchScoring
{
    public static partial class LaunchData
    {
        static LaunchData()
        {
            Scoring = new Dictionary<LaunchScoringCategory, Dictionary<int, double>>
            {
                { LaunchScoringCategory.Accessiblity, AccessibilityScoring },
                { LaunchScoringCategory.Beauty, BeautyScoring },
                { LaunchScoringCategory.Empathy, EmpathyScoring },
                { LaunchScoringCategory.Flexibility, FlexibilityScoring },
                { LaunchScoringCategory.Originality, OriginalityScoring },
                { LaunchScoringCategory.Potential, PotentialScoring },
            };

            MaxScoringPoints = new Dictionary<LaunchScoringCategory, double>()
            {
                { LaunchScoringCategory.Accessiblity, 50 },
                { LaunchScoringCategory.Beauty, 50 },
                { LaunchScoringCategory.Empathy, 40 },
                { LaunchScoringCategory.Flexibility, 28 },
                { LaunchScoringCategory.Originality, 10 },
                { LaunchScoringCategory.Potential, 10 },
            };
        }

        /// <summary>
        /// The score for each project in each category. The inner dictionary is keyed by project's ID, the value is compound score from all judges.
        /// </summary>
        /// <remarks>
        /// We aren't storing or pulling this data from the backend due to time constraints, but it will eventually need to be moved there.
        /// We could have used JSON, but there's no reason to add deserialization weight.
        /// </remarks>
        public static Dictionary<LaunchScoringCategory, Dictionary<int, double>> Scoring { get; }

        public static Dictionary<LaunchScoringCategory, double> MaxScoringPoints { get; }
    }
}
