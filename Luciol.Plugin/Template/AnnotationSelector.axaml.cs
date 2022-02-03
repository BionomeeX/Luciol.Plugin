using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Luciol.Plugin.Context.Annotation;
using System.Linq;

namespace Luciol.Plugin.Template
{
    public partial class AnnotationSelector : UserControl
    {
        public AnnotationSelector()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void Init(IAnnotator annotator)
        {
            AvaloniaXamlLoader.Load(this);
            UpdateDisplay(annotator);
            annotator.OnAnnotationAdd += (sender, e) =>
            {
                UpdateDisplay(annotator);
            };
            annotator.OnAnnotationRemove += (sender, e) =>
            {
                UpdateDisplay(annotator);
            };
        }

        private void UpdateDisplay(IAnnotator annotator)
        {
            var list = this.FindControl<StackPanel>("AnnotationList");
            var selected = annotator.GetSelected();
            list.Children.Clear();
            list.Children.AddRange(
                annotator.GetAnnotations().Select(x =>
                {
                    var label = new TextBlock
                    {
                        Text = $"{x}"
                    };
                    var checkbox = new CheckBox
                    {
                        IsChecked = selected.Contains(x)
                    };
                    checkbox.Checked += (sender, e) =>
                    {
                        annotator.Select(x);
                    };
                    checkbox.Unchecked += (sender, e) =>
                    {
                        annotator.Unselect(x);
                    };
                    var content = new StackPanel();
                    content.Children.AddRange(new IControl[] { label, checkbox });
                    return content;
                })
            );
        }
    }
}
