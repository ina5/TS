using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TargetSystem.Models;
using System.Data.Entity;
using TargetSystem.ViewModel;

namespace TargetSystem
{
    public partial class ListTargets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TSDbContext context = new TSDbContext();
                var gv = context.Targets.Include(x => x.TargetGoal)
                    .Include(x => x.TargetType)
                    .Include(x => x.TargetPercent)
                    .Include(x => x.Creator)
                    .Select(x => new TargetView()
                    {
                        Id = x.TargetsId,
                        Goal = x.TargetGoal,
                        Type = x.TargetType.ToString(),
                        Percent = x.TargetPercent,
                        Creator = x.Creator


                    })
                    .ToList();
                TargetsGV.DataSource = gv;
                TargetsGV.DataBind();
            }
        }
        //protected void TargetsGV_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    e.Row.Cells[1].Visible = false;

        //}
        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            int id = -1;
            GridViewRow row;
            GridView grid = sender as GridView;

            if (e.CommandName == "Details")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                id = int.Parse(row.Cells[0].Text);  // PROBLEM / I tried with [0], but the same mistake again.
            }
            Response.Redirect("~/Views/TargetDetails.aspx?id=" + id.ToString());
        }

        protected void TargetsGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;

        }
    }
}
