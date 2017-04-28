using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TargetSystem.Models;
using TargetSystem.ViewModel;

namespace TargetSystem.Views
{
    public partial class CompletedTargets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TSDbContext context = new TSDbContext();
            Target currentTarget = null;

            if (!IsPostBack)
            {
                // Show types from DataBase
                TargetTypeRbl.DataSource = Enum.GetNames(typeof(TargetType));
                TargetTypeRbl.DataBind();
            }
            //  
            var targets = new List<Target>();
            if (TargetTypeRbl.SelectedValue == TargetType.Mandatory.ToString())
            {
                CTargetsGV.Visible = true;
                var selected = (TargetType)Enum.Parse(typeof(TargetType), TargetTypeRbl.SelectedValue, true);
                targets = context.Targets.Where(t => t.TargetType == selected).Where(x => x.EndDate < DateTime.Today).ToList();
            }
            else if (TargetTypeRbl.SelectedValue == TargetType.Bonus.ToString())
            {
                CTargetsGV.Visible = true;
                var selected = (TargetType)Enum.Parse(typeof(TargetType), TargetTypeRbl.SelectedValue, true);
                targets = context.Targets.Where(t => t.TargetType == selected).Where(x => x.EndDate < DateTime.Today).ToList();
            }

            var gv = targets.Select(x => new UserTargetView()
            {
                Id = x.TargetsId,
                Goal = x.TargetGoal,
                Percent = x.TargetPercent,

            })
                                     .ToList();
            CTargetsGV.DataSource = gv;
            CTargetsGV.DataBind();

            targets.Clear();


        }
        protected void CTargetsGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;

        }
        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Get details for specific Target Row
            int index = 0;
            int id = -1;
            GridViewRow row;
            GridView grid = sender as GridView;

            if (e.CommandName == "Details")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                id = int.Parse(row.Cells[1].Text);
            }
        }
    }
}
