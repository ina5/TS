<%@ Page Title="Create Target" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTarget.aspx.cs" Inherits="TargetSystem.CreateTarget" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
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
        <%-- Calendar --%>

        <div>
            <asp:Label class="col-lg-2 control-label" ID="calendarLabel" runat="server" Text="Start date"></asp:Label>
            <br />
            <asp:TextBox ID="CalendarTextBox" runat="server" ReadOnly="true"></asp:TextBox>
            <img class="calendar" src="Images/calendar.ico" />
            <br />
        </div>
        <div style="float: right;">
            <asp:Label class="col-lg-2 control-label" ID="Label1" runat="server" Text="End date"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
            <img class="calendar" src="Images/calendar.ico" />
            <br />
        </div>

        <%-- <div class="form-group">
            <label for="select" class="col-lg-2 control-label">Select Position</label>
            <div class="col-lg-3">
                <asp:DropDownList ID="PositionDdl" runat="server" AutoPostBack="True"></asp:DropDownList>
                <br>
            </div>
        </div>--%>

        <%--<div class="form-group">
            <label for="select" class="col-lg-2 control-label">Select Employee</label>
            <div class="col-lg-3">

                <asp:UpdatePanel ID="UpdatePanelEmployee" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="EmployeesGV" OnRowCommand="EmployeeGv_RowCommand" OnRowDataBound="EmployeesGV_RowDataBound" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderText="Add">
                                    <ItemTemplate>

                                        <asp:CheckBox
                                            ID="chkIsSelected" runat="server" HeaderText="IsSelected"
                                            Checked='<%#Eval("IsSelected").ToString()=="1"?true:false %>' />
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>--%>
        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <asp:Button ID="CreateButton" CssClass="btn btn-default" runat="server" Text="Create" OnClick="CreateButton_Click" />
                <asp:Button ID="CancelButton" CssClass="btn btn-default" runat="server" Text="Cancel" />
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="Content/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=CalendarTextBox.ClientID %>").dynDateTime({
                showsTime: false,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m, %Y",
                align: "BR",
                electric: true,
                singleClick: true,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>


</asp:Content>

