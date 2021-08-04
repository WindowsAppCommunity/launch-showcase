namespace LaunchShowcase.Sdk.Services
{
    /// <summary>
    /// The categories that a project is judged on for the Launch event.
    /// </summary>
    public enum LaunchScoringCategory
    {
        /// <summary>
        /// A Fluent Design principle. Responsive layouts, adaptive input methods, and a natural UI fit on every device.
        /// </summary>
        Flexibility,

        /// <summary>
        /// A Fluent Design principle. The user experience is stable, intuitive, and delightful to use.
        /// </summary>
        Empathy,

        /// <summary>
        /// A Fluent Design principle. The app is engaging and immersive. Shadows, animations, depth, general design.
        /// </summary>
        Beauty,

        /// <summary>
        /// Apps are built on a great idea and have the potential to grow into something even bigger.
        /// </summary>
        Potential,

        /// <summary>
        /// Apps that do something very original, unique, or uncommon, or serves an unfilled niche. Yugen Mosaic is a good example of this.
        /// </summary>
        Originality,

        /// <summary>
        /// Screen reader support, localization, high contrast themes, and keyboard navigation make your app more accessible to users around the world.
        /// </summary>
        Accessiblity,
    }

}