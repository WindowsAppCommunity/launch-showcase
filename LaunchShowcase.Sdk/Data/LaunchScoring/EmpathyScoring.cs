using System.Collections.Generic;

namespace LaunchShowcase.Sdk.Data.LaunchScoring
{
    public static partial class LaunchData
    {
        public static Dictionary<int, double> EmpathyScoring { get; } = new Dictionary<int, double>
        {
            { LaunchProjects.FluentSearch, 31.5 },
            { LaunchProjects.FlairMax, 26 },
            { LaunchProjects.CryptoTracker, 35.5 },
            { LaunchProjects.Glif, 24 },
            { LaunchProjects.SpecsAnalysis, 34.5 },
            { LaunchProjects.TranslucentTB, 36 },
            { LaunchProjects.FluentScreenRecorder, 33.5 },
            { LaunchProjects.Stylophone, 36 },
            { LaunchProjects.FluentStore, 33 },
            { LaunchProjects.Ambie, 39 },
            { LaunchProjects.ShresthaFilesPro, 33 },
            { LaunchProjects.JitHub, 32.5 },
            { LaunchProjects.PlayingwithPhysicsCompoundOscillations, 31 },
            { LaunchProjects.Fiona, 28 },
            { LaunchProjects.Storylines, 35.5 },
            { LaunchProjects.Archon, 32 },
            { LaunchProjects.DesignMe, 36.5 },
            { LaunchProjects.ClipboardCanvas, 31 },
            { LaunchProjects.ExdPic, 29 },
            { LaunchProjects.FlowTeX, 32.5 },
            { LaunchProjects.Fluetropdf, 31 },
            { LaunchProjects.YugenDJ, 31 },
            { LaunchProjects.Guesio, 23 },
            { LaunchProjects.Yöti, 22.5 },
        };
    }
}
