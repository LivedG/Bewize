using System;
using Bewize.iOS.Render_files;
using Bewize.RenderFiles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly : ExportRenderer(typeof(CustomEntry),typeof(Custom_iosEntry))]
namespace Bewize.iOS.Render_files
{
	public class Custom_iosEntry : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
	
}

