using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bewize.Models;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Xamarin.Forms;
using System.Net.Http;

namespace Bewize.HelperResource
{
	
    public class SQLiteHelper
    {
            SQLiteAsyncConnection db;
            public SQLiteHelper(string dbPath)
            {
                db = new SQLiteAsyncConnection(dbPath);
                db.CreateTableAsync<UserDetails>().Wait();
            }

            //Insert and Update new record  
            public Task<int> SaveItemAsync(UserDetails person)
            {
                    return db.InsertAsync(person);
            
            }

            //update
            public Task<int> UpdateItemAsync(UserDetails person)
            {
                return db.UpdateAsync(person);
            }
            //Delete  
            public Task<int> DeleteItemAsync(UserDetails person)
                {
                    return db.DeleteAsync(person);
                }

            //Read All Items  
            public Task<List<UserDetails>> GetItemsAsync()
            {
                return db.Table<UserDetails>().ToListAsync();
            }


            //Read Item  
            public Task<UserDetails> GetItemAsync(string personId)
            {
                return db.Table<UserDetails>().Where(i => i._id == personId).FirstOrDefaultAsync();
            }

            public Task<int> DeleteAllItemAsync()
            {
              return db.DeleteAllAsync<UserDetails>();
            } 

    }



    public class ImageService
    {
        static readonly HttpClient http_client = new HttpClient();
        

        public static byte[] DownlodaImage(string imageurl)
        {
            if (!imageurl.Trim().StartsWith("https", StringComparison.OrdinalIgnoreCase))
                throw new Exception("iOS and android require https");

           

            return http_client.GetByteArrayAsync(imageurl).Result;
        }

        public static void SavetoDisk(string imagename, byte[] image64basestring) {
            Xamarin.Essentials.Preferences.Set(imagename, Convert.ToBase64String(image64basestring));
        }

        public static Xamarin.Forms.ImageSource GetFromDisk(string imagefilename) {
            var image64string = Xamarin.Essentials.Preferences.Get(imagefilename, string.Empty);
            return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(image64string)));
        }
    }
}

