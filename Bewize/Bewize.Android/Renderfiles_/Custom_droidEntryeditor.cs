
using System;
using Bewize.Droid.Renderfiles_;
using Bewize.RenderFiles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.PlatformConfiguration;

[assembly: ExportRenderer(typeof(CustomEntryEditor), typeof(Custom_droidEntryeditor))]
namespace Bewize.Droid.Renderfiles_
{
    [Obsolete]
    public class Custom_droidEntryeditor : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}
