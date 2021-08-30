using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LaunchShowcase.Converters
{
    /// <summary>
    /// A converter that converts a given <see cref="bool"/> a <see cref="Visibility"/>.
    /// </summary>
    public sealed class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Returns visible if the boolean is true.
        /// </summary>
        /// <param name="data">boolean to check.</param>
        /// <returns>Collapsed if false, otherwise Visible.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Visibility Convert(bool data) => data ? Visibility.Visible : Visibility.Collapsed;

        public bool Invert { get; set; }

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Convert(value is bool bValue && (Invert ? !bValue : bValue));
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}