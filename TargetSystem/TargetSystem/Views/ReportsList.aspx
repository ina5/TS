<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportsList.aspx.cs" Inherits="TargetSystem.Views.ReportsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h5><%: Title %></h5>

    <asp:GridView ID="ReportsGV"
        DataKeysNames="TargetsId, UserId"
        SelectMethod="ReportsGV_GetData"
        OnRowCommand="ReportsGV_RowCommand"
        ItemType="TargetSystem.ViewModel.ReportView"
        runat="server"
        Width="1150px"
        CssClass="table table-bordered table-condensed table-hover "
        AllowPaging="true"
        PageSize="8"
        AutoGenerateColumns="false">
        <Columns>

            <asp:BoundField DataField="TargetsId" HeaderText="UserId" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" ItemStyle-CssClass="hideId" HeaderStyle-CssClass="hideId" />
            <asp:BoundField DataField="Goal" HeaderText="Goal" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="Report" HeaderText="Report" />
            <asp:BoundField DataField="UserName" HeaderText="Reported By" />
            <asp:ButtonField ButtonType="Button"
                Text="Details"
                runat="server"
                CommandName="Details"
                ItemStyle-HorizontalAlign="center"
                ControlStyle-CssClass="btn btn-info" />
            <%-- <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnDetails"
                        class="btn btn-info"
                        runat="server"
                        Text="Details"
                        CommandName="Details"
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
</asp:Content>
