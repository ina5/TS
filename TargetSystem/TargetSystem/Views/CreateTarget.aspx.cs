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
using System.Threading;
using System.Globalization;

namespace TargetSystem
{
    public partial class CreateTarget : System.Web.UI.Page
    {
        TSDbContext context = new TSDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {

                //    //Show Positions from DataBase

                TargetTypeRbl.DataSource = Enum.GetNames(typeof(TargetType));
                TargetTypeRbl.DataBind();

                //    var targetPositions = context.Positions.ToList();
                //    foreach (var position in targetPositions)
                //    {
                //        PositionDdl.Items.Add(new ListItem()
                //        {
                //            Value = position.PositionId.ToString(),
                //            Text = position.PositionName
                //        });
                //    }

                //    targetPositions.Clear();


            }

            //Show Employees by Positions from DataBase

            //int selectedPosId = int.Parse(PositionDdl.SelectedValue);

            //Grid View from employees

            //var gridData = context.Users.ToList()
            //    .Where(y => y.PositionId == selectedPosId)
            //    .Select(x => new EmployeeView()
            //    {
            //        Id = x.Id,
            //        FirstName = x.FirstName,
            //        LastName = x.LastName,
            //        Email = x.Email,

            //    })
            //    .ToList();


            //EmployeesGV.DataSource = gridData;
            //EmployeesGV.DataBind();

        }

        //Hide an existing column "IsSelected" and Id
        protected void EmployeesGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            //e.Row.Cells[5].Visible = false;

        }

        protected void EmployeeGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            int id = -1;
            GridViewRow row;
            GridView grid = sender as GridView;

            if (e.CommandName == "Add")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                id = int.Parse(row.Cells[1].Text);
            }

            Response.Redirect("Details.aspx?id=" + id.ToString());

        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {

            //Create Target
            Target target = new Target();

            target.TargetGoal = goalTextBox.Text;
            target.TargetDescription = textArea.Value;
            target.TargetType = (TargetType)Enum.Parse(typeof(TargetType), TargetTypeRbl.SelectedItem.Text);

            target.Creator = HttpContext.Current.User.Identity.Name;

            //Working on a start and end Date
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
            target.StartDate = DateTime.ParseExact(CalendarStartTB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            target.EndDate = DateTime.ParseExact(CalendarEndTB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //Add create Target in TargetsTable
            context.Targets.Add(target);

            context.SaveChanges();

            //
            var currentTarget = context.Targets.Find(target.TargetsId);


            //var rows = EmployeesGV.Rows;
            //int count = EmployeesGV.Rows.Count;

            //for (int i = 0; i < count; i++)
            //{
            //    bool isChecked = ((CheckBox)rows[i].FindControl("chkIsSelected")).Checked;
            //    GridViewRow row;
            //    int selectedEmployeeId;
            //    if (isChecked)
            //    {
            //        row = EmployeesGV.Rows[i];
            //        selectedEmployeeId = int.Parse(row.Cells[1].Text);
            //        currentTarget.ApplicationUser.Add(context.Users.Find(selectedEmployeeId));
            //        context.SaveChanges();
            //    }
            //}



            goalTextBox.Text = String.Empty;
            textArea.InnerText = String.Empty;

            Response.Redirect("~/Default.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}