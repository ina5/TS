using Microsoft.AspNet.Identity;
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
    public partial class CurrentTargets : System.Web.UI.Page
    {
        TSDbContext context = new TSDbContext();
        Target currentTarget = null;
        string currentUserId = HttpContext.Current.User.Identity.GetUserId();

        List<Target> allTargetsForCurrentUser = new List<Target>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Show types from DataBase
                TargetTypeRbl.DataSource = Enum.GetNames(typeof(TargetType));
                TargetTypeRbl.DataBind();
            }


            var currentUser = context.Users.Find(currentUserId);
            var allTargetAppUsers = currentUser.TargetApplicationUser.ToList();
            var targetsIds = new List<int>();
            foreach (var item in allTargetAppUsers)
            {
                targetsIds.Add(item.TargetsId);
            }


            foreach (var targetId in targetsIds)
            {
                allTargetsForCurrentUser.Add(context.Targets.Find(targetId));
            }

            //  
            var targets = new List<Target>();

            //Hide PanelDetails 
            panelDetails.Visible = false;

            if (TargetTypeRbl.SelectedValue == TargetType.Mandatory.ToString())
            {
                CTargetsGV.Visible = true;
                var selected = (TargetType)Enum.Parse(typeof(TargetType), TargetTypeRbl.SelectedValue, true);
                targets = allTargetsForCurrentUser.Where(t => t.TargetType == selected).ToList();
            }
            else if (TargetTypeRbl.SelectedValue == TargetType.Bonus.ToString())
            {


                CTargetsGV.Visible = true;
                var selected = (TargetType)Enum.Parse(typeof(TargetType), TargetTypeRbl.SelectedValue, true);
                targets = allTargetsForCurrentUser.Where(t => t.TargetType == selected).ToList();
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
            //       allTargetsForCurrentUser.Clear();

          


        }
        protected void CTargetsGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;

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
                id = int.Parse(row.Cells[0].Text);

                Mark_btn.Visible = true;
                panelDetails.Visible = true;
                ReportTextArea.Value = "";

                currentTarget = context.Targets.Find(id);

                // how to get a report from database
                var rowTAU = context.TargetApplicationUsers.
                    Where(x => x.UserId == currentUserId
                    && x.TargetsId == currentTarget.TargetsId).FirstOrDefault();
                string report = null;

                if (rowTAU != null)
                {
                    report = rowTAU.Report;
                }
                // condition
                if (report != null)
                {
                    ReportTextArea.Value = report;
                    ReportTextArea.Disabled = true;
                   Send_btn.Visible = false;
                    Mark_btn.Visible = false;
                    Cancel_btn.Visible = false;
                    panelMark.Visible = true;

                }
                else
                {
                    ReportTextArea.Disabled = false;
                    Send_btn.Visible = true;
                    Mark_btn.Visible = true;
                    Cancel_btn.Visible = true;
                    panelMark.Visible = false;
                }



                // Hide percent depending on TargetType:
                if (currentTarget.TargetType.ToString() == "Mandatory")
                {
                    TPercent.Visible = false;
                    TPercentL.Visible = false;

                }
                else
                {
                    TPercent.Visible = true;
                    TPercentL.Visible = true;
                }

                TGoalL.Text = currentTarget.TargetGoal;
                TDescriptionL.Text = currentTarget.TargetDescription;
                TTypeL.Text = currentTarget.TargetType.ToString();
                TPercentL.Text = currentTarget.TargetPercent.ToString() + " %";
                TStartDateL.Text = currentTarget.StartDate.ToShortDateString();
                TEndDateL.Text = currentTarget.EndDate.ToShortDateString();
                TCreator.Text = currentTarget.Creator;
                TargetIdHiden.Text = currentTarget.TargetsId.ToString();

            }
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            panelMark.Visible = false;
            Mark_btn.Visible = true;
        }

        protected void Mark_btn_Click(object sender, EventArgs e)
        {
            //Show again PanelDetails 
            panelDetails.Visible = true;

            panelMark.Visible = true;
            Mark_btn.Visible = false;

        }

        protected void Close_btn_Click(object sender, EventArgs e)
        {
            panelMark.Visible = false;
            panelDetails.Visible = false;
        }

        protected void Send_btn_Click(object sender, EventArgs e)
        {
            //Show again PanelDetails 
            panelDetails.Visible = true;
            // context.TargetAppkicationUsers
            //.FirstOrDefault(x => x.UserId == currentUserId && x.TargetsId == currentTarget.TargetsId)
            //.Report = ReportTextArea.Value;
            // context.SaveChanges();

            context.TargetApplicationUsers.Find(currentUserId, int.Parse(TargetIdHiden.Text)).Report = ReportTextArea.Value;
            context.SaveChanges();

            Mark_btn.Visible = false;
            Cancel_btn.Visible = false;
            Send_btn.Visible = false;
            ReportTextArea.Disabled = true;

        }
    }
}