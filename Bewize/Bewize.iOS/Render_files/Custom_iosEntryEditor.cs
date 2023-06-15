using System;
using Bewize.iOS.Render_files;
using Bewize.RenderFiles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly : ExportRenderer(typeof(CustomEntryEditor),typeof(Custom_iosEntryEditor))]
namespace Bewize.iOS.Render_files
{
    public class Custom_iosEntryEditor : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Layer.BorderColor = UIKit.UIColor.LightGray.ToColor().ToCGColor();
                Control.Layer.BorderWidth = (nfloat)0.8;
                Control.Layer.CornerRadius = 15;
                Control.Layer.BorderWidth = 0;
            }
        }
    }

}
