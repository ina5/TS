﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using TargetSystem.Models;
using System.Collections.Generic;

namespace TargetSystem.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (RoleDdl.SelectedIndex == 0)
            {
                posLabel.Visible = false;
                PositionDdl.Visible = false;

            }
            else if (RoleDdl.SelectedIndex == 1)
            {
                posLabel.Visible = true;
                PositionDdl.Visible = true;

            }


            if (!IsPostBack)
            {
                RoleDdl.Items.Add("manager");
                RoleDdl.Items.Add("employee");

                var db = new TSDbContext();

                var posNames = new List<string>();
                foreach (var item in db.Positions.ToList())
                {
                    posNames.Add(item.PositionName);
                }
                PositionDdl.DataSource = posNames;
                PositionDdl.DataBind();

            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var db = new TSDbContext();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser()
            {
                UserName = Email.Text,
                Email = Email.Text,
                FirstName = fName.Text,
                Surname = surname.Text,
                LastName = lName.Text,
                //check roles :
                //0) if the role is manager set position to None
                //1) or if is not set position which has the same name as the text from the dropDownList
                PositionId = RoleDdl.SelectedIndex == 0 ? 1 : db
                                                                .Positions
                                                                .FirstOrDefault(
                                                                 x => x.PositionName == PositionDdl.SelectedItem.Text)
                                                                .PositionId
            };





            IdentityResult result = manager.Create(user, Password.Text);

            var roleresult = manager.AddToRole(user.Id, RoleDdl.SelectedItem.Text);

            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }


    }
}