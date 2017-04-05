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

namespace TargetSystem
{
    public partial class CreateTarget : System.Web.UI.Page
    {
        TSDbContext context = new TSDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            Target target = new Target()
            {
                TargetGoal = goalTextBox.Text,
                TargetDescription = textArea.Value,
                TargetType = (TargetType)Enum.Parse(typeof(TargetType), TargetTypeRbl.SelectedValue),
                StartDate = StartDateCal.SelectedDate.Date,
                EndDate = EndDateCal.SelectedDate.Date,
                CreatorId = User.Identity.GetUserId()
        };
            context.Targets.Add(target);

            context.SaveChanges();

            Response.Redirect("~/Default.aspx");
        }
    }
}