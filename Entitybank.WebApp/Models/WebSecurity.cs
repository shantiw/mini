﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Security;
using XData.Data.Services;

namespace XData.Web.Models
{
    public static class WebSecurity
    {
        private static AccountService AccountService = new AccountService();

        public static string Name => AccountService.GetLoginedUser(Thread.CurrentPrincipal.Identity.Name).Element("Name").Value;

        public static bool Login(LoginModel model, out string errorMessage)
        {
            bool result = AccountService.Login(model.UserName, model.Password, out errorMessage);
            if (result) FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            return result;
        }

        public static void Logout()
        {
            AccountService.Logout();
            FormsAuthentication.SignOut();
        }

        public static void ChangePassword(string password, string newPassword)
        {
            AccountService.ChangePassword(password, newPassword);
        }

    }
}