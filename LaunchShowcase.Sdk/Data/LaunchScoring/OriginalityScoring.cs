using System.Collections.Generic;

namespace LaunchShowcase.Sdk.Data.LaunchScoring
{
    public static partial class LaunchData
    {
        public static Dictionary<int, double> OriginalityScoring { get; } = new Dictionary<int, double>
        {
            { LaunchProjects.FluentSearch, 6 },
            { LaunchProjects.FlairMax, 7 },
            { LaunchProjects.CryptoTracker, 4 },
            { LaunchProjects.Glif, 7 },
            { LaunchProjects.SpecsAnalysis, 6 },
            { LaunchProjects.TranslucentTB, 5 },
            { LaunchProjects.FluentScreenRecorder, 6 },
            { LaunchProjects.Stylophone, 8 },
            { LaunchProjects.FluentStore, 9 },
            { LaunchProjects.Ambie, 8 },
            { LaunchProjects.ShresthaFilesPro, 6 },
            { LaunchProjects.JitHub, 8 },
            { LaunchProjects.PlayingwithPhysicsCompoundOscillations, 9 },
            { LaunchProjects.Fiona, 6 },
            { LaunchProjects.Storylines, 6 },
            { LaunchProjects.Archon, 9 },
            { LaunchProjects.DesignMe, 9 },
            { LaunchProjects.ClipboardCanvas, 9 },
            { LaunchProjects.ExdPic, 8 },
            { LaunchProjects.FlowTeX, 4 },
            { LaunchProjects.Fluetropdf, 0 },
            { LaunchProjects.YugenDJ, 8 },
            { LaunchProjects.Guesio, 4 },
            { LaunchProjects.Yöti, 3 },
        };
    }
}
