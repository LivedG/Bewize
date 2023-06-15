using System;
using Bewize.Droid.Renderfiles_;
using Bewize.RenderFiles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchbar), typeof(Custom_droidSearchbar))]
namespace Bewize.Droid.Renderfiles_
{
    [Obsolete]
    public class Custom_droidSearchbar : SearchBarRenderer
	{
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.White);
            }
        }
    }
}

