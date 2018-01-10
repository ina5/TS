<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportsList.aspx.cs" Inherits="TargetSystem.Views.ReportsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h5><%: Title %></h5>

    <asp:GridView ID="ReportsGV"
        OnRowCommand="ReportsGV_RowCommand"
        OnRowDataBound="ReportsGV_RowDataBound"
        ItemType="TargetSystem.ViewModel.ReportView"
        runat="server"
        Width="1150px"
        CssClass="table  table-bordered table-condensed table-hover "
        AutoGenerateColumns="false">
        <Columns>

            <asp:BoundField DataField="TargetsId" HeaderText="TargetsId" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" />
            <asp:BoundField DataField="Goal" HeaderText="Goal" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="Report" HeaderText="Report" />
            <asp:BoundField DataField="UserName" HeaderText="Reported By" />

             <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnDetails"
                        class="btn btn-info"
                        runat="server"
                        Text="Details"
                        CommandName="Details"
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
