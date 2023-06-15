using System;
using Bewize.Droid.Renderfiles_;
using Bewize.RenderFiles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.PlatformConfiguration;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(Custrom_droidEntry))]
namespace Bewize.Droid.Renderfiles_
{
    [Obsolete]
    public class Custrom_droidEntry : EntryRenderer
	{
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}
