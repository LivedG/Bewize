using System;
using System.Collections.Generic;
using Bewize.ViewModels;
using Bewize.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.IO;
using Xamarin.Forms.Shapes;
using Bewize.HelperResource;

namespace Bewize.Views.Profile
{	
	public partial class EditAccountDetailspage : ContentPage
	{
		EditAccountdetailsVM VM;
		public Updateduserdetails _profiledetails { get; set; }
        public string PhotoPath { get; private set; }
        public byte[] ProfilepicbytesData { get; private set; }
        public FileResult selectedpic { get; set; }
        public UserDetails profiledata = new UserDetails();

        public EditAccountDetailspage (UserDetails details)
		{
			InitializeComponent ();

			VM = new EditAccountdetailsVM();
            BindingContext = VM;
            this.profiledata = details;
          
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Object, Country>(this, "selectedcountry", async (obj, item) =>
            {
                var i = item as Country;
              
                if ((VM.Profiledetails.country_code != null || VM.Profiledetails.country_code != "") || VM.selectedCountry != null)
                {
                    VM.selectedCountry = i;
                    VM.Profiledetails.country_code = VM.selectedCountry.country_code;

                }
            });

            MessagingCenter.Subscribe<Object, String>(this, "Profilepic", async (obj, item) =>
            {
                var i = item as String;
                this.setupProfilepicture(i);
            });
            if (this.profiledata != null)
            {
                VM.setProfiledata(this.profiledata);
            }
           
        }

        async void setupProfilepicture(string picurl)
        {
            try
            {
                var imagebytes = ImageService.DownlodaImage(picurl);
                ImageService.SavetoDisk("Profilepic", imagebytes);
                Profileimage.Source = ImageService.GetFromDisk("Profilepic");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");
            }
        }

        public void Savebtn_Clicked(System.Object sender, System.EventArgs e)
        {
			_profiledetails = new Updateduserdetails();
			_profiledetails.lname = VM.Profiledetails.lname;
			_profiledetails.fname = Firstnametxt.Text;
            _profiledetails.email = emailtxt.Text;
            _profiledetails.username = Usernametxt.Text;
            _profiledetails.phone = Phonenumbertxt.Text;
            _profiledetails.public_name = Publicnametxt.Text;
            _profiledetails.zipcode = locationtxt.Text;
             _profiledetails.country_code = Countrycodetxt.Text;
            VM.ProfiledetailsupdateSucesfully(_profiledetails);
        }

        public async void Uploadimg_Clicked(System.Object sender, System.EventArgs e)
        {
           
                try
                {
                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Please, pick a photo"});
                
                await LoadPhotoAsync(photo);
                   
                    //Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Feature is not supported on the device
                }
                catch (PermissionException pEx)
                {
                    // Permissions not granted
                }
                catch (Exception ex)
                {
                   // Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
                }
            
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            FileStream newstream;
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            // save the file into local storage
            var newFile = System.IO.Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (newstream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newstream);
             
            PhotoPath = newFile;
            using (var streamReader = new StreamReader(PhotoPath))
            {
                var bytes = default(byte[]);
                using (var memstream = new MemoryStream())
                {
                    streamReader.BaseStream.CopyTo(memstream);
                    bytes = memstream.ToArray();
                    this.uploadprofilepicturetoserver(bytes);
                    
                }
            }
                Profileimage.Source = PhotoPath;
           

        }
        public void uploadprofilepicturetoserver(byte[] bytesdata)
        {
            VM.Update_profilepicture(bytesdata);
        }

        public void Phonenumbertxt_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (VM.Profiledetails.phone == "" || VM.Profiledetails.phone == null)
            {
                this.Phonenumbertxt.IsReadOnly = false;
            }
            else {
                this.Phonenumbertxt.IsReadOnly = true;
            }
        }

        public void emailtxt_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (VM.Profiledetails.email == "" || VM.Profiledetails.email == null)
            {
                this.emailtxt.IsReadOnly = false;
            }
            else
            {
                this.emailtxt.IsReadOnly = true;
            }
        }

        void Countrycodetxt_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            VM.CountrycodeselectionAsync();
        }

        void Phonenumbertxt_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if(VM.selectedCountry.country_code == this.Countrycodetxt.Text && Phonenumbertxt.Text != "")
            {
                VM.Checkfornumberdublication(this.Countrycodetxt.Text,Phonenumbertxt.Text);
            }
        }
    }
}

