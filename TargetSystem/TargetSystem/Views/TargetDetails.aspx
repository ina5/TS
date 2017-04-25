<%@ Page Title="Target Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TargetDetails.aspx.cs" Inherits="TargetSystem.Views.TargetDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2><%: Title %>.</h2>
        <div class="row">
            <div class="col-lg-6">
                <asp:Label ID="PositionsL" runat="server" CssClass="col-lg-12" Text="Select Position:"></asp:Label>
                <div class="col-lg-6">
                    <asp:DropDownList ID="PositionDdl" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

            </div>
            <div class="col-lg-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <asp:Label ID="TGoalL" runat="server" Text=""></asp:Label></h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">

                            <label class="col-lg-3 control-label">Description</label>
                            <div class="col-lg-9">
                                <div class="pull-right">
                                    <asp:Label ID="TDescriptionL" Style="text-align: right" runat="server" Text="DescriptionL"></asp:Label>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <label class="col-lg-3 control-label">Type</label>
                            <div class="col-lg-9">
                                <div class="pull-right">
                                    <asp:Label ID="TTypeL" runat="server" Text="TypeL"></asp:Label>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <label class="col-lg-3 control-label">Percent</label>
                            <div class="col-lg-9">
                                <div class="pull-right">
                                    <asp:Label ID="TPercentL" runat="server" Text="PercentL"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-lg-3 control-label">Start Date</label>
                            <div class="col-lg-9">
                                <div class="pull-right">
                                    <asp:Label ID="TStartDateL" runat="server" Text="StartDateL"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-lg-3 control-label">End Date</label>
                            <div class="col-lg-9">
                                <div class="pull-right">
                                    <asp:Label ID="TEndDateL" runat="server" Text="EndDateL"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="SelectEmplL" runat="server" CssClass="col-lg-12" Text="Select Employees:"></asp:Label>
        <div class="col-lg-12">
            <div class="row">


                <asp:Panel ID="EmpListPanel" Visible="false" runat="server">
                    <asp:CheckBoxList ID="EmployeesCbl" CssClass="checkbox" RepeatLayout="Table" RepeatDirection="Vertical" RepeatColumns="3" runat="server">
                    </asp:CheckBoxList>
                </asp:Panel>

            </div>
        </div>
        <div class="clear"></div>
        <asp:Button ID="AssignB" CssClass="btn btn-default" runat="server" Text="Assign" OnClick="AssignB_Click" />
    </div>


</asp:Content>
