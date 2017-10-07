using Intellectus_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intellectus_mvc
{
    public class CompanyAuthManager
    {
        public static Company LoggedCompany
        {
            get
            {
                CompanyAuthService authenticationService = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedCompany"] == null)
                    HttpContext.Current.Session["LoggedCompany"] = new CompanyAuthService();

                authenticationService = (CompanyAuthService)HttpContext.Current.Session["LoggedCompany"];
                return authenticationService.LoggedCompany;
            }
        }

        public static void Authenticate(string username, string password)
        {
            CompanyAuthService authenticationService = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedCompany"] == null)
                HttpContext.Current.Session["LoggedCompany"] = new CompanyAuthService();

            authenticationService = (CompanyAuthService)HttpContext.Current.Session["LoggedCompany"];
            authenticationService.AuthenticateCompany(username, password);
        }
        public static void Logout()
        {
            HttpContext.Current.Session["LoggedCompany"] = null;
        }
    }
}