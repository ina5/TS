<%@ Page Title="Create Target" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTarget.aspx.cs" Inherits="TargetSystem.CreateTarget" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <div class="form-group">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Goal</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="goalTextBox" CssClass="form-control" />

        </div>
    </div>
    <div class="form-group">
        <label for="textArea" class="col-lg-2 control-label">Description</label>
        <div class="col-lg-10">
            <textarea class="form-control" runat="server" rows="3" id="textArea"></textarea>
            <span class="help-block">Set task/s</span>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-2 control-label">Type</label>
        <div class="col-lg-10">

            <asp:RadioButtonList ID="TargetTypeRbl" runat="server"></asp:RadioButtonList>

        </div>
    </div>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label">Select Position</label>
        <div class="col-lg-3">
            <asp:DropDownList ID="PositionDdl" runat="server"></asp:DropDownList>
            <br>
        </div>
    </div>
    <%-- Calendar --%>
    <table>
        <tr>
            <td>
                <div id="div1">
                    <div class="col-lg-10">
                        <label class="col-lg-2 control-label">Start Date</label>
                        <asp:Calendar ID="StartDateCal" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                    </div>
                </div>
                <td>
            <td>
                <div id="div2">
                    <div class="col-lg-10">
                        <label class="col-lg-2 control-label">End Date</label>
                        <asp:Calendar ID="EndDateCal" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                    </div>
                </div>
                <td>
        </tr>
    </table>

    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button ID="CreateButton" CssClass="btn btn-default" runat="server" Text="Create" OnClick="CreateButton_Click" />
            <asp:Button ID="CancelButton" CssClass="btn btn-default" runat="server" Text="Cancel" />
        </div>
    </div>


</asp:Content>
