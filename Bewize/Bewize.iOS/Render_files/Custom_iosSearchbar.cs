using System;
using Bewize.iOS.Render_files;
using Bewize.RenderFiles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSearchbar), typeof(Custom_iosSearchbar))]
namespace Bewize.iOS.Render_files 

{
	public class Custom_iosSearchbar : SearchBarRenderer
	{
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.SearchBarStyle = UIKit.UISearchBarStyle.Minimal;
                Control.BarTintColor = UIKit.UIColor.White;
                Control.SearchTextField.BackgroundColor = UIKit.UIColor.White;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Text")
            {
                Control.ShowsCancelButton = false;
            }
        }
    }
}

