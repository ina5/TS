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

        HashSet<ListItem> items = new HashSet<ListItem>();
        TSDbContext context = new TSDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

            //Take TargetDetails with given Id
            var currentTarget = context.Targets.Find(id);


            if (!IsPostBack)
            {
                TGoalL.Text = currentTarget.TargetGoal;
                TDescriptionL.Text = currentTarget.TargetDescription;
                TTypeL.Text = currentTarget.TargetType.ToString();
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

            //int selectedPosId = int.Parse(PositionDdl.SelectedValue);
            if (PositionDdl.SelectedIndex != -1)
            {
                EmpListPanel.Visible = true;
                var posId = int.Parse(PositionDdl.SelectedValue);
                var selectedPos = context.Positions.Find(posId);
                var employees = context.Users.Where(y => y.PositionId == selectedPos.PositionId).ToList();


                foreach (var emp in employees)
                {
                    items.Add(new ListItem
                    {
                        Text = string.Concat(emp.FirstName, " ", emp.Surname, " ", emp.LastName),
                        Value = emp.Id,
                        Selected = true
                    });
                }

                EmployeesCbl.DataSource = items;
                EmployeesCbl.DataBind();

                employees.Clear();
                items.Clear();

                foreach (ListItem item in EmployeesCbl.Items)
                {
                    item.Selected = true;
                    item.Attributes.Add("class", "form-control");
                }


            }
            // Populate Employees


        }
    }
}
