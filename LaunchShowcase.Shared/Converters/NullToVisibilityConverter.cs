using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LaunchShowcase.Converters
{
    /// <summary>
    /// A converter that returns <see cref="Visibility.Visibility"/> if the object is not null, otherwise <see cref="Visibility.Collapsed"/>. 
    /// </summary>
    public sealed class NullToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Returns visible if the boolean is true.
        /// </summary>
        /// <param name="data">boolean to check.</param>
        /// <returns>Collapsed if false, otherwise Visible.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Visibility Convert(object data) => data is null ? Visibility.Collapsed : Visibility.Visible;

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Debug.WriteLine(value);
            return Convert(value);
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
