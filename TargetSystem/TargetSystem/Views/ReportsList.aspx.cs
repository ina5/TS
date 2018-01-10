using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TargetSystem.Models;
using TargetSystem.ViewModel;

namespace TargetSystem.Views
{
    public partial class ReportsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TSDbContext context = new TSDbContext();
            if (!IsPostBack)
            {
                var gv = context.TargetApplicationUsers
                                 .Include(x => x.User)
                                 .Include(x => x.Target)
                                 .Select(x => new ReportView()
                                 {
                                     TargetsId = x.TargetsId,
                                     UserId = x.UserId,
                                     Type = x.Target.TargetType.ToString(),
                                     Goal = x.Target.TargetGoal,
                                     Report = x.Report,
                                     UserName = x.User.FirstName
                                 })
                                 .ToList();

                ReportsGV.DataSource = gv;
                ReportsGV.DataBind();
            }
        }

        protected void ReportsGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            string targetId = "";
            string userId = "";
            GridViewRow row;
            GridView grid = sender as GridView;

            if (e.CommandName == "Details")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                targetId = row.Cells[0].Text;
                userId = row.Cells[1].Text;
            }
            Response.Redirect($"~/Views/ReportDetails.aspx?targetid={targetId}&userid={userId}");
        }

        protected void ReportsGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        }
    }
}