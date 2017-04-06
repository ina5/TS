using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TargetSystem.Models;
using TargetSystem.Migrations;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using TargetSystem.ViewModel;

namespace TargetSystem
{
    public partial class CreateTarget : System.Web.UI.Page
    {
        TSDbContext context = new TSDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Show Positions from DataBase
                TargetTypeRbl.DataSource = Enum.GetNames(typeof(TargetType));
                TargetTypeRbl.DataBind();

                var targetPositions = context.Positions.ToList();
                foreach (var position in targetPositions)
                {
                    PositionDdl.Items.Add(new ListItem()
                    {
                        Value = position.PositionId.ToString(),
                        Text = position.PositionName
                    });
                }

                targetPositions.Clear();


            }

            //Show Employees by Positions from DataBase
            int selectedPosId = int.Parse(PositionDdl.SelectedValue);

            //Grid View from employees
            var gridData = context.Users.ToList()
                .Where(y => y.PositionId == selectedPosId)
                .Select(x => new EmployeeView()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,

                })

                  .ToList();


            EmployeesGV.DataSource = gridData;
            EmployeesGV.DataBind();

        }
        //Hide an existing column "IsSelected"
        protected void EmployeesGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            var rows = EmployeesGV.Rows;
            int count = EmployeesGV.Rows.Count;
            var listEmails = new List<string>();
            for (int i = 0; i < count; i++)
            {
                bool isChecked = ((CheckBox)rows[i].FindControl("chkIsSelected")).Checked;
                GridViewRow row;

                if (isChecked)
                {

                    row = EmployeesGV.Rows[i];
                    listEmails.Add(row.Cells[4].Text);


                }
            }


            TextArea1.Value = string.Join(", ", listEmails);


            Target target = new Target()
            {
                TargetGoal = goalTextBox.Text,
                TargetDescription = textArea.Value,
                TargetType = (TargetType)Enum.Parse(typeof(TargetType), TargetTypeRbl.SelectedValue),
                StartDate = StartDateCal.SelectedDate.Date,
                EndDate = EndDateCal.SelectedDate.Date,
                Creator = HttpContext.Current.User.Identity.Name
            };
            context.Targets.Add(target);

            context.SaveChanges();

            //Response.Redirect("~/Default.aspx");
        }
    }
}