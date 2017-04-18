<%@ Page Title="List Target" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListTargets.aspx.cs" Inherits="TargetSystem.ListTargets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:GridView ID="TargetsGV" runat="server" AutoGenerateColumns="False" DataSourceID="DataTargets">
            <Columns>
                <asp:BoundField DataField="TargetGoal" HeaderText="TargetGoal" SortExpression="TargetGoal" />
                <asp:BoundField DataField="TargetType" HeaderText="TargetType" SortExpression="TargetType" />
<%--                <asp:BoundField DataField="CreatorId" HeaderText="CreatorId" SortExpression="CreatorId" />--%>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Look More" ShowHeader="True" Text="Details" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="DataTargets" runat="server" ConnectionString="<%$ ConnectionStrings:TargetSystem %>" SelectCommand="SELECT DISTINCT [TargetGoal], [TargetType], [CreatorId] FROM [Targets]"></asp:SqlDataSource>
    </div>

</asp:Content>
