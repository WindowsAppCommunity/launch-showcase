using System.Collections.Generic;

namespace LaunchShowcase.Sdk.Data.LaunchScoring
{
    public static partial class LaunchData
    {
        public static Dictionary<int, double> PotentialScoring { get; } = new Dictionary<int, double>
        {
            { LaunchProjects.FluentSearch, 5 },
            { LaunchProjects.FlairMax, 6 },
            { LaunchProjects.CryptoTracker, 8.5 },
            { LaunchProjects.Glif, 6 },
            { LaunchProjects.SpecsAnalysis, 1.5 },
            { LaunchProjects.TranslucentTB, 2.5 },
            { LaunchProjects.FluentScreenRecorder, 8.5 },
            { LaunchProjects.Stylophone, 5 },
            { LaunchProjects.FluentStore, 3.5 },
            { LaunchProjects.Ambie, 9.5 },
            { LaunchProjects.ShresthaFilesPro, 3.5 },
            { LaunchProjects.JitHub, 9 },
            { LaunchProjects.PlayingwithPhysicsCompoundOscillations, 4.5 },
            { LaunchProjects.Fiona, 1.5 },
            { LaunchProjects.Storylines, 3 },
            { LaunchProjects.Archon, 2 },
            { LaunchProjects.DesignMe, 9.5 },
            { LaunchProjects.ClipboardCanvas, 8.5 },
            { LaunchProjects.ExdPic, 7.5 },
            { LaunchProjects.FlowTeX, 8 },
            { LaunchProjects.Fluetropdf, 0.5 },
            { LaunchProjects.YugenDJ, 6.5 },
            { LaunchProjects.Guesio, 6.5 },
            { LaunchProjects.Yöti, 0.5 },
        };
    }
}
