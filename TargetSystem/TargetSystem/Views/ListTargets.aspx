<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListTargets.aspx.cs" Inherits="TargetSystem.ListTargets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h5><%: Title %></h5>

    <asp:GridView ID="TargetsGV"
        OnRowCommand="Grid_RowCommand"
        OnRowDataBound="TargetsGV_RowDataBound"
        ItemType="TargetSystem.ViewModel.TargetView"
        runat="server"
        Width="1150px"
        CssClass="table  table-bordered table-condensed table-hover"
        AutoGenerateColumns="false">
        <Columns>

            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Goal" HeaderText="Goal" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="Percent" HeaderText="Percent" />
            <asp:BoundField DataField="Creator" HeaderText="Creator" />

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnDetails" class="btn btn-info" runat="server" Text="Details" CommandName="Details"
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

