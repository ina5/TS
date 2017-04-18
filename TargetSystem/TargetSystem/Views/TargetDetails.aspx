<%@ Page Title="Target Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TargetDetails.aspx.cs" Inherits="TargetSystem.Views.TargetDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2>Target Details.</h2>
        <div class="row">
            <div class="col-lg-6">
                <asp:Label ID="PositionsL" runat="server" CssClass="col-lg-12" Text="Select Position:"></asp:Label>
                <div class="col-lg-6">
                    <asp:DropDownList ID="PositionDdl" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <asp:Label ID="TGoalL" runat="server" Text="TGoalL"></asp:Label></h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <label class="col-lg-3 control-label">Description</label>
                            <div class="col-lg-9">
                                <div class="pull-right">
                                    <asp:Label ID="DescriptionL" runat="server" Text="DescriptionL"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-lg-3 control-label">Type</label>
                            <div class="col-lg-9">
                                <div class="pull-right">
                                    <asp:Label ID="TypeL" runat="server" Text="TypeL"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-lg-3 control-label">Start Date</label>
                            <div class="col-lg-9">
                                <div class="pull-right">
                                    <asp:Label ID="StartDateL" runat="server" Text="StartDateL"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <label class="col-lg-3 control-label">End Date</label>
                            <div class="col-lg-9">
                                <div class="pull-right">
                                    <asp:Label ID="EndDateL" runat="server" Text="EndDateL"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-12">
            <div class="row">

                <%-- ????? --%>
                <asp:UpdatePanel ID="UpdatePanelEmployee" runat="server">
                    <ContentTemplate>
                        <asp:CheckBoxList ID="EmployeesCbl" OnRowCommand="EmployeeGv_RowCommand" OnRowDataBound="EmployeesGV_RowDataBound" runat="server">
                        </asp:CheckBoxList>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <%-- <asp:CheckBoxList ID="EmployeesCbl" CssClass="checkbox" RepeatDirection="Vertical" RepeatColumns="3" runat="server"></asp:CheckBoxList>--%>
            </div>
        </div>
    </div>


</asp:Content>
