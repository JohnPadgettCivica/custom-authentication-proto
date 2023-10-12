#region
// Copyright (c) 2016 Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License (MIT)
/*============================================================================
  File:     Logon.aspx.cs
  Summary:  The code-behind for a logon page that supports Forms
            Authentication in a custom security extension    
--------------------------------------------------------------------
  This file is part of Microsoft SQL Server Code Samples.
    
 This source code is intended only as a supplement to Microsoft
 Development Tools and/or on-line documentation. See these other
 materials for detailed information regarding Microsoft code 
 samples.

 THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
 ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
 THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
 PARTICULAR PURPOSE.
===========================================================================*/
#endregion

using System;
using System.Web.Security;

namespace Ludus.ReportingServices.CustomSecurity
{
    public class Logon : System.Web.UI.Page
   {
        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var isLocalConn = System.Web.HttpContext.Current.Request.IsLocal;
                if (isLocalConn && !Properties.Settings.Default.bypasslocalogin)
                {
                    FormsAuthentication.RedirectFromLoginPage("username", true);
                }
                else
                {
                    //var decryptUri = Encryption.Decrypt(ExtractEncQs(System.Web.HttpContext.Current.Request.Url.PathAndQuery), Properties.Settings.Default.cle);
                    //FormsAuthentication.RedirectFromLoginPage($"{AuthenticationUtilities.ExtractedUser}_TestUserGroup1", true);
                    FormsAuthentication.RedirectFromLoginPage("User1_TestUserGroup", true);

                }
            }
            catch (Exception ex)
            {
                FormsAuthentication.SignOut();
            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
      {
            InitializeComponent();
            base.OnInit(e);
      }
      
      private void InitializeComponent()
      {    
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion
   }
}
