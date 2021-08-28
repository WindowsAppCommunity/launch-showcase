using LaunchShowcase.Sdk.Data;
using LaunchShowcase.Sdk.ViewModels;
using Microsoft.Toolkit.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LaunchShowcase.TemplateSelectors
{
    public class ShowcasePageTemplateSelector : DataTemplateSelector
    {
        private DataTemplate GetTemplateByName(string name)
        {
            var resourceDict = new ResourceDictionary 
            {
                Source = new Uri($"ms-appx:///Themes/ShowcaseTemplates/{name}.xaml"),
            };

            if (resourceDict.TryGetValue(name, out var template))
                return (DataTemplate)template;
            else
                return ThrowHelper.ThrowInvalidOperationException<DataTemplate>($"Key not found in the given resource dictionary. Make sure you've placed your template in the correct path, and given your template x:Key=\"{name}\"");
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is null)
                return base.SelectTemplateCore(item);

            var project = (ProjectViewModel)item;

            return project.Id switch
            {
                // Example.
                // Your ResourceDictionary's XAML file should be placed under /Themes/ShowcaseTemplates,
                // and should match the x:Key given to the data template.
                LaunchProjects.Archon => GetTemplateByName("DefaultShowcaseTemplate"),
                LaunchProjects.FluentStore => GetTemplateByName("FluentStore"),
                _ => GetTemplateByName("DefaultShowcaseTemplate"),
            };
        }

    }
}
