﻿using System.Collections.Generic;

namespace LaunchShowcase.Sdk.Data.LaunchScoring
{
    public static partial class LaunchData
    {
        public static Dictionary<int, int> PotentialScoring { get; } = new Dictionary<int, int>
        {
            { LaunchProjects.Archon, 0 }, // example
        };
    }
}