using System;
using Bewize.RenderFiles;
using Bewize.Droid.Renderfiles_;
using Xamarin.Forms;
using Android.Widget;
using System.ComponentModel;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(Dropdownlist), typeof(Dropdownlist_Droid))]

namespace Bewize.Droid.Renderfiles_
{
	public class Dropdownlist_Droid : ViewRenderer<Dropdownlist, Spinner>  
    {  
        Spinner spinner;
        public Dropdownlist_Droid(Context context) : base(context)
        {

        }

       protected override void OnElementChanged(ElementChangedEventArgs<Dropdownlist> e)
    {
        base.OnElementChanged(e);

        if (Control == null)
        {
            spinner = new Spinner(Context);
            SetNativeControl(spinner);
        }

        if (e.OldElement != null)
        {
            Control.ItemSelected -= OnItemSelected;
        }
        if (e.NewElement != null)
        {
            var view = e.NewElement;

            ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleListItem1, view.ItemsSource);
            Control.Adapter = adapter;

            if (view.SelectedIndex != -1)
            {
                Control.SetSelection(view.SelectedIndex);
            }

            Control.ItemSelected += OnItemSelected;
        }
    }

       protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var view = Element;
        if (e.PropertyName == Dropdownlist.ItemsSourceProperty.PropertyName)
        {
            ArrayAdapter adapter = new ArrayAdapter(Context, Android.Resource.Layout.SimpleListItem1, view.ItemsSource);
            Control.Adapter = adapter;
        }
        if (e.PropertyName == Dropdownlist.SelectedIndexProperty.PropertyName)
        {
            Control.SetSelection(view.SelectedIndex);
        }
        base.OnElementPropertyChanged(sender, e);
    }

       private void OnItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
      {
        var view = Element;
        if (view != null)
        {
            view.SelectedIndex = e.Position;
            view.OnItemSelected(e.Position);
        }
      }
   }
}

