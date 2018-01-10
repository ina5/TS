using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TargetSystem.Models;

namespace TargetSystem.Views
{
    public partial class ReportDetails : System.Web.UI.Page
    {
        TSDbContext context = new TSDbContext();
        // Declare Id
        int targetId = 0;
        string userId = "";
        // Declare currentTarget
        Target currentTarget = null;
        ApplicationUser reportingUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Take an Id
            targetId = int.Parse(Request.QueryString["targetid"]);
            userId = Request.QueryString["userid"];
            //Take TargetDetails with given Id
            currentTarget = context.Targets.Find(targetId);
            reportingUser = context.Users.Find(userId);

            if (!IsPostBack)
            {
                TGoal.Text = currentTarget.TargetGoal;
                TDescription.Text = currentTarget.TargetDescription;
                TType.Text = currentTarget.TargetType.ToString();
                TPercent.Text = currentTarget.TargetPercent.ToString() + " %";
                TStartDate.Text = currentTarget.StartDate.ToShortDateString();
                TEndDate.Text = currentTarget.EndDate.ToShortDateString();
                TReportBy.Text = string.Concat(reportingUser.FirstName, " ", reportingUser.Surname, " ", reportingUser.LastName);

               
            }

        }
    }
}