using Bewize.Droid;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Android.Factories;
using AndroidBitmapDescriptor = Android.Gms.Maps.Model.BitmapDescriptor;
using AndroidBitmapDescriptorFactory = Android.Gms.Maps.Model.BitmapDescriptorFactory;


namespace Bewize.Droid.Renderfiles_
{
    public sealed class BitmapConfig : IBitmapDescriptorFactory
    {
        public AndroidBitmapDescriptor ToNative(BitmapDescriptor descriptor)
        {
            int iconId = 0;
            switch (descriptor.Id)
            {
                case "A":
                    iconId = Resource.Drawable.A_;
                    break;
                case "B":
                    iconId = Resource.Drawable.B_;
                    break;
                case "C":
                    iconId = Resource.Drawable.C_;
                    break;
                case "D":
                    iconId = Resource.Drawable.D_;
                    break;
                case "F":
                    iconId = Resource.Drawable.F_;
                    break;
                case "Gun":
                    iconId = Resource.Drawable.GunMark;
                    break;
            }
            return AndroidBitmapDescriptorFactory.FromResource(iconId);
        }
    }
}
