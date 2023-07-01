using Bewize.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace Bewize.HelperResource
{
    public class HttpHelper
    {

        public async Task<APIResponse> callAPI(string url, string json)
        {
            APIResponse res = new APIResponse();
            try
            {
                string content = string.Empty;
                var httpClient = new HttpClient();

                AuthenticationHeaderValue authHeader;

                json = json.Replace(@"\", String.Empty);


                HttpResponseMessage httpResponse = null;
                if (String.IsNullOrWhiteSpace(json))
                {

                    if (url.Contains("getuserdtlbyid") || url.Contains("getcrimetype"))
                    {

                        if (Preferences.ContainsKey("Token"))
                        {
                            var token = Preferences.Get("Token", "");

                            authHeader = new AuthenticationHeaderValue("Bearer", (string)token);
                            httpClient.DefaultRequestHeaders.Authorization = authHeader;
                        }
                        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                        httpResponse = await httpClient.PostAsync(url, httpContent);

                        content = await httpResponse.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<APIResponse>(content);


                    }
                    else
                    {
                        if (Preferences.ContainsKey("Token"))
                        {
                            var token = Preferences.Get("Token", "");
                            Debug.WriteLine("token ----> ", token);

                            authHeader = new AuthenticationHeaderValue("Bearer", (string)token);
                            httpClient.DefaultRequestHeaders.Authorization = authHeader;
                        }
                        httpResponse = await httpClient.GetAsync(url);
                        content = await httpResponse.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<APIResponse>(content);
                    }
                }
                else
                {

                    if (url.Contains("login"))
                    {
                        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                        httpResponse = await httpClient.PostAsync(url, httpContent);

                        content = await httpResponse.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<APIResponse>(content);

                    }
                    else
                    {
                        if (Preferences.ContainsKey("Token"))
                        {
                            //var token = Application.Current.Properties["Token"] as string;
                            var token = Preferences.Get("Token", "");
                            authHeader = new AuthenticationHeaderValue("Bearer", (string)token);
                            httpClient.DefaultRequestHeaders.Authorization = authHeader;
                        }
                        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                        httpResponse = await httpClient.PostAsync(url, httpContent);

                        content = await httpResponse.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<APIResponse>(content);

                    }
                }
                if (res.statusCode == 401)
                {
                    FileInfo fi = new FileInfo(App.DatabaseLocation);
                    try
                    {
                        if (fi.Exists)
                        {
                            SQLiteConnection connection = new SQLiteConnection("Data Source=" + App.DatabaseLocation + ";");
                            connection.Close();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            fi.Delete();
                        }
                        // Application.Current.Properties.Clear();
                        App.Current.MainPage = new NavigationPage(new Views.Signup_Login.MainPage_());
                        App.Current.MainPage.Navigation.PopToRootAsync();
                    }
                    catch (Exception ex)
                    {
                        fi.Delete();
                    }


                }
                else
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        content = await httpResponse.Content.ReadAsStringAsync();
                        res = JsonConvert.DeserializeObject<APIResponse>(content);
                    }
                    else
                    {
                        res.response = null;
                        // res.message = "Invalid Response";
                        res.success = false;
                    }
                }
                Debug.WriteLine("Res ----> ", res);
                return res;
            }
            catch (Exception ex)
            {
                res.response = ex.Message.ToString();
                res.message = "Invalid Response";
                res.success = false;
                return res;
            }
        }

        public async Task<APIResponse> Multiforn_callAPI(string url, byte[] file_bytes)
        {

            APIResponse res = new APIResponse();
            string content = string.Empty;
            var httpClient = new HttpClient();

            AuthenticationHeaderValue authHeader;


            HttpResponseMessage httpResponse = null;

            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();


                form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "profile_img", "profile_img.jpg");
                if (Preferences.ContainsKey("Token"))
                {
                    //var token = Application.Current.Properties["Token"] as string;
                    var token = Preferences.Get("Token", "");

                    authHeader = new AuthenticationHeaderValue("Bearer", (string)token);
                    httpClient.DefaultRequestHeaders.Authorization = authHeader;
                }
                // var httpContent = new StringContent(form, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(url, form);

                response.EnsureSuccessStatusCode();
                httpClient.Dispose();


                if (response.IsSuccessStatusCode)
                {
                    content = response.Content.ReadAsStringAsync().Result;

                    res = JsonConvert.DeserializeObject<APIResponse>(content);
                }
                else
                {
                    res.response = null;
                    // res.message = "Invalid Response";
                    res.success = false;
                }
                return res;

            }
            catch (Exception ex)
            {
                res.response = ex.Message.ToString();
                res.message = "Invalid Response";
                res.success = false;
                return res;
            }
        }
    }

}


