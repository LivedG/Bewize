using System;
using Xamarin.Forms;

namespace Bewize.HelperResource
{
	public class APIHelper
	{
        public static string url = "http://54.152.64.255:88/api/v1/";
        public static string loginAPI = url + "login";
        public static string loginout = url + "logout";
        public static string RegisterAPI = url + "register";
        public static string Getuserdetailsbyid = url + "getuserdtlbyid";
        public static string Updateuserdetails = url + "updateuser";
        public static string GetQuestionslist = url + "getque";
        public static string SendOTP = url + "sendOTP";
        public static string Verifyotp = url + "verifyotp";
        public static string Crimetypelist = url + "getcrimetype";
        public static string SubmitAns = url + "submitans";
        public static string Resetpwd = url + "resetpwd";
        public static string Forgotpwd = url + "forgotpwd";
        public static string Allcountrywithflag = url + "getallcountrywithflag";
        public static string UploadProfileimage = url + "upload_user_imp";
        public static string Currentlocationdetails = url + "currentlocationdtl";
        public static string Selectedlocationdetails = url + "selectedlocationdtl";
        public static string Currentlocationscore = url + "currentlocationscore";
        public static string Currentlocationrating = url + "currentlocationrating";
        public static string Selectedlocationfulldetails = url + "selectedlocationfulldtl";
        public static string myrating = url + "myratings";
        public static string Verifyemail = url + "verifyemail";
        public static string VerifyPhone = url + "verifyphone";
        public static string Getlocationswithinradius = url + "getlocationswithinradius";
        public static string ThirdpartyUserRegister = url + "thirdpartyregisteruser";
        public static string ThirdpartyUserLogin = url + "thirdpartyloginuser";


        public APIHelper()
		{
		}
	}
}

