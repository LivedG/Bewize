using System;
using SQLite;

namespace Bewize.Models
{
    public class UserDetails
    {
        [PrimaryKey]
        public int user_id { get; set; }
        public string _id { get; set; }
        public string username { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string fcm_token { get; set; }
        public string social_login_token { get; set; }
        public string role { get; set; }
        public bool is_active { get; set; }
        public string zipcode { get; set; }
        public string public_name { get; set; }
        public string phone { get; set; }
        public string profile_img { get; set; }
        public string country_code { get; set; }

    }

    public class Users_reqPara
    {
        public string country_code { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
    }

    public class AuthToken
    {
        public string Token { get; set; }
    }


    public class Resetpassword
    {
        public string password { get; set; }
    }
    public class EmailRequestPara
    {
        public string email { get; set; }
    }

    public class Forgetpassword_reqpara
    {
        public string country_code { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    }

    public class Sendotp_reqPara
    {
        public string phone { get; set; }
        public string country_code { get; set; }
    }

    public class Verifyotp_reqPara
    {
        public string country_code { get; set; }
        public string phone { get; set; }
        public string otp { get; set; }
    }

    public class Registeruserbynumber
    {
        public string country_code { get; set; }
        public string phone { get; set; }

    }

    public class Locationinfo_reqPara
    {
        public string latitude { get; set; }
        public string longitude { get; set; }

    }

    public class Registeruserbyemail
    {
        public string username { get; set; }
        public string password { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
     }

    public class Updateduserdetails
    {
       
        public string email { get; set; }
        public string username { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string zipcode { get; set; }
        public string public_name { get; set; }
        public string phone { get; set; }
        public string country_code { get; set; }
  }
    public class Updateprofilepicture
    {
        public string profile_img { get; set; }
    }


    public class AppleAccount
    {
        public string Email { get; set; }
        public string Name { get; set; }
        //public string Token { get; set; }
        //public string RealUserStatus { get; set; }
        //public string UserId { get; set; }
        //public Uri Picture { get; set; }
        //public string lname { get; set; }
        //public string zipcode { get; set; }
        //public string public_name { get; set; }
        //public string phone { get; set; }
        //public string country_code { get; set; }


    }

    public enum AppleSignInCredentialState
    {
        Authorized,
        Revoked,
        NotFound,
        Unknown
    }
}