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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

                int selectedPosId = int.Parse(PositionDdl.SelectedValue);
                //?????

                //var EmployeeCbl = context.Users.ToList()
                //    .Where(y => y.PositionId == selectedPosId)
                //    .Select(x => new Emp()
                //    {
                //        Id = x.Id,
                //        FirstName = x.FirstName,
                //        LastName = x.LastName,
                //        Email = x.Email,

                //    })
                //    .ToList();


                //Emp.DataSource = EmployeeCbl;
                //Emp.DataBind();

                // Populate Employees
                var employees = context.Users.Where(x => x.Email != "admin@admin.com").Where(y => y.PositionId == selectedPosId).ToList();

                foreach (var emp in employees)
                {
                    EmployeesCbl.Items.Add(new ListItem
                    {
                        Text = string.Concat(emp.FirstName, " ", emp.Surname, " ", emp.LastName),
                        Value = emp.Id,
                        Selected = true
                    });
                }
                //employees.Clear();

            }
        }
    }
}