using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                TPercentL.Text = currentTarget.TargetPercent.ToString()+" %";
                TStartDateL.Text = currentTarget.StartDate.ToShortDateString();
                TEndDateL.Text = currentTarget.EndDate.ToShortDateString();
                // Populate positions
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
                //PositionDdl.SelectedIndex = -1;
            }


            if (PositionDdl.SelectedIndex != -1)
            {
                EmpListPanel.Visible = true;
                var posId = int.Parse(PositionDdl.SelectedValue);
                var selectedPos = context.Positions.Find(posId);
                var employees = context.Users.Where(y => y.PositionId == selectedPos.PositionId).ToList();

                if (EmployeesCbl.Items.Count!=0)
                {
                    EmployeesCbl.Items.Clear();
                }

                foreach (var emp in employees)
                {
                    EmployeesCbl.Items.Add(new ListItem
                    {
                        Text = string.Concat(emp.FirstName, " ", emp.Surname, " ", emp.LastName),
                        Value = emp.Id,
                    });
                }

             ;

                employees.Clear();

                // Show and Check all Employees
                foreach (ListItem item in EmployeesCbl.Items)
                {
                    item.Selected = true;
                    item.Attributes.Add("class", "form-control");
                }


            }



        }
        // Add Id in the connection Table between Targets and Users
        protected void AssignB_Click(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"]);

            currentTarget = context.Targets.Find(id);

            ApplicationUser selectedEmp;

            foreach (ListItem emp in EmployeesCbl.Items)
            {
                if (emp.Selected == true)
                {
                   selectedEmp= (context.Users.Find(emp.Value));

                    selectedEmp.Targets.Add(currentTarget);
                    currentTarget.User.Add(selectedEmp);
                    context.SaveChanges();
                }
            }

        }
    }
}
