<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportDetails.aspx.cs" Inherits="TargetSystem.Views.ReportDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div style="width: 100%; overflow: hidden;">
            <div style="width: 1000px; float: left;">

                <div class="row">

                    <div class="col-lg-6">
                        <div class="panel panel-primary">

                            <div class="panel-heading">

                                <div class="clear"></div>


                                <h3 class="panel-title">
                                    <asp:Label ID="TGoal" runat="server" Text="Goal"></asp:Label>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <div class="row">

                                    <label class="col-lg-3 control-label">Description</label>
                                    <div class="col-lg-9">
                                        <div class="pull-right">
                                            <asp:Label ID="TDescription" Style="text-align: right" runat="server" Text="Description"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <label class="col-lg-3 control-label">Type</label>
                                    <div class="col-lg-9">
                                        <div class="pull-right">
                                            <asp:Label ID="TType" runat="server" Text="Type"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-lg-3 control-label">Percent</label>
                                    <div class="col-lg-9">
                                        <div class="pull-right">
                                            <asp:Label ID="TPercent" runat="server" Text="Percent"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-lg-3 control-label">Start Date</label>
                                    <div class="col-lg-9">
                                        <div class="pull-right">
                                            <asp:Label ID="TStartDate" runat="server" Text="StartDate"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-lg-3 control-label">End Date</label>
                                    <div class="col-lg-9">
                                        <div class="pull-right">
                                            <asp:Label ID="TEndDate" runat="server" Text="EndDate"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <label class="col-lg-3 control-label">Reported By</label>
                                    <div class="col-lg-9">
                                        <div class="pull-right">
                                            <asp:Label ID="TReportBy" runat="server" Text="ReportBy"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="clear"></div>
    <div style="margin-left: 800px;">
        <div class="row">

            <div class="col-lg-6">
                <div class="panel panel-primary">

                    <div class="panel-heading">

                        <div class="clear"></div>


                        <h3 class="panel-title">
                            <asp:Label ID="ReportLabel" runat="server" Text="Report"></asp:Label>
                        </h3>
                    </div>
                </div>
            </div>

        </div>
    </div>



</asp:Content>
