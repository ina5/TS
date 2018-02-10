using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TargetSystem.Models;

namespace TargetSystem.Views
{
    public partial class TargetDetails : System.Web.UI.Page
    {
        TSDbContext context = new TSDbContext();
        // Declare Id
        int id = 0;
        // Declare currentTarget
        Target currentTarget = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Take an Id
            id = int.Parse(Request.QueryString["id"]);

            //Take TargetDetails with given Id
            currentTarget = context.Targets.Find(id);


            if (!IsPostBack)
            {
                // Display Panel - Info for Current Target
                TGoalL.Text = currentTarget.TargetGoal;
                TDescriptionL.Text = currentTarget.TargetDescription;
                TTypeL.Text = currentTarget.TargetType.ToString();
                TPercentL.Text = currentTarget.TargetPercent.ToString() + " %";
                TStartDateL.Text = currentTarget.StartDate.ToShortDateString();
                TEndDateL.Text = currentTarget.EndDate.ToShortDateString();
                // Populate positions
                PositionsDropDownPopulate();
                //PositionDdl.SelectedIndex = -1;

                // Show and Check all Employees
                //foreach (ListItem item in EmployeesCbl.Items)
                //{
                //    item.Selected = true;
                //    item.Attributes.Add("class", "form-control");
                //}

            }

            this.ToggleAssignButton();

        }

        private void PositionsDropDownPopulate()
        {
            var positions = context.Positions.ToList();
            foreach (var pos in positions)
            {
                PositionDdl.Items.Add(new ListItem
                {
                    Text = pos.PositionName,
                    Value = pos.PositionId.ToString()
                });
            }
            positions.Clear();
        }

        // Add Id in the connection Table between Targets and Users
        protected void AssignB_Click(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"]);

            currentTarget = context.Targets.Find(id);

            ApplicationUser selectedEmp;

            foreach (ListItem emp in EmployeesCbl.Items)
            {
                if (emp.Selected)
                {
                    selectedEmp = (context.Users.Find(emp.Value));

                    selectedEmp.TargetApplicationUser.Add(new TargetApplicationUser()
                    {
                        TargetsId = currentTarget.TargetsId,
                        UserId = selectedEmp.Id
                    });
                    context.SaveChanges();

                }
            }
            // HERE
            //PositionDdl.ClearSelection();
            //PositionDdl.SelectedIndex = 0;
            //EmployeesCbl.Items.Clear();
            HttpContext.Current.Response.Redirect($"TargetDetails?id={id}");
                
            MessageBox.Show("Task has been sent !", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void PositionDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeesCbl.Items.Clear();

            if (PositionDdl.SelectedIndex != -1)
            {
                //ToggleAssignButton();

                EmpListPanel.Visible = true;
                var posId = int.Parse(PositionDdl.SelectedValue);
                var selectedPos = context.Positions.Find(posId);
                //var employeesId = context.Users.Where(y => y.PositionId == selectedPos.PositionId).Select(u=>u.Id);

                var targetId = this.currentTarget.TargetsId;
                var userIds = context.TargetApplicationUsers
                    .Where(x => x.TargetsId == targetId)
                    .Select(x => x.UserId);

                var employees = context.Users
                    .Where(y => y.PositionId == selectedPos.PositionId && !userIds.Contains(y.Id))
                    .ToList();

                foreach (var emp in employees)
                {
                    EmployeesCbl.Items.Add(new ListItem
                    {
                        Text = string.Concat(emp.FirstName, " ", emp.Surname, " ", emp.LastName),
                        Value = emp.Id,
                    });
                }
            }
        }

        private void ToggleAssignButton()
        {
            if (PositionDdl.SelectedIndex == 0)
            {
                AssignB.Visible = false;
            }
            else
            {
                AssignB.Visible = true;
            }
        }
    }
}
