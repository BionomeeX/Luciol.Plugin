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
            var list = this.FindControl<StackPanel>("AnnotationList");
            list.Children.AddRange(
                annotator.GetAnnotations().Select(x =>
                {
                    var label = new TextBlock
                    {
                        Text = x.Name
                    };
                    var checkbox = new CheckBox
                    { };
                    var content = new StackPanel();
                    content.Children.AddRange(new IControl[] { label, checkbox });
                    return content;
                })
            );
        }
    }
}
