using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using TargetSystem.Models;
using TargetSystem.Account.Service;


namespace TargetSystem.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide Positions from Role Manager
            if (RoleDdl.SelectedIndex == 0)
            {
                posLabel.Visible = false;
                PositionDdl.Visible = false;

            }
            //Show Positions for Role Employee
            else if (RoleDdl.SelectedIndex == 1)
            {
                posLabel.Visible = true;
                PositionDdl.Visible = true;

            }


            if (!IsPostBack)
            {

                RoleDdl.Items.Add("manager");
                RoleDdl.Items.Add("employee");

                //Show Positions from DataBase
                var db = new TSDbContext();

                var posNames = new List<string>();
                foreach (var item in db.Positions.ToList())
                {
                    if (item.PositionName != "None")
                    {
                        posNames.Add(item.PositionName);
                    }


                }
                PositionDdl.DataSource = posNames;
                PositionDdl.DataBind();

            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var databaseTS = new TSDbContext();
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
                PositionId = RoleDdl.SelectedIndex == 0 ? 1 : databaseTS
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

                //signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                //Cleaning textboxes:

            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }

            //Send Email to Employees



            //using (MailMessage mm = new MailMessage("managertest17@gmail.com", pEmail.Text))
            //{
            //    Uri uri = new Uri("http://tempuri.org/");
            //    ICredentials credentials = CredentialCache.DefaultCredentials;
            //    NetworkCredential credential = credentials.GetCredential(uri, "Basic");


            //    mm.Subject = "Hello from Gmail";
            //    mm.Body = "Hello, friend :)";
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.EnableSsl = true;
            //    NetworkCredential NetworkCred = credential;
            //    smtp.Credentials = NetworkCred;
            //    smtp.Port = 587;
            //    smtp.Send(mm);
            //}

            var client = new SmtpClient();
            var service = new MyEmailService(client);
            service.SendEmail(pEmail.Text, Email.Text, Password.Text);

            Email.Text = String.Empty;
            fName.Text = String.Empty;
            surname.Text = String.Empty;
            lName.Text = String.Empty;
            roleLabel.Text = String.Empty;
            Password.Text = String.Empty;
            ConfirmPassword.Text = String.Empty;
            pEmail.Text = String.Empty;
        }


    }
}