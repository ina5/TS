﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateTask.aspx.cs" Inherits="TargetSystem.Views.CreateTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2><%: Title %>Create Task</h2>
        <div class="clear"></div>
        <div class="row">
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Goal</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="goalTextBox" CssClass="form-control" />

                </div>
            </div>
        </div>
        <div class="clear"></div>
        <div class="row">
            <div class="form-group">
                <label for="textArea" class="col-lg-2 control-label">Description</label>
                <div class="col-lg-4">
                    <textarea rows="4" class="form-control" style="height: 88px; width: 280px;" runat="server" id="textArea"></textarea>
                    <span class="help-block">Set task/s</span>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="form-group">
                <label class="col-lg-2 control-label">Type</label>
                <div class="col-lg-10">

                    <asp:RadioButtonList ID="TargetTypeRbl" AutoPostBack="true" runat="server"></asp:RadioButtonList>

                </div>
            </div>
        </div>
        <%-- Task Percent --%>
        <div class="row">
            <div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-lg-2 control-label">Percent</asp:Label>
                    <div class="col-md-1">
                        <asp:TextBox runat="server" ID="PercentTb" CausesValidation="true" CssClass="form-control" />
                        <asp:RangeValidator ID="PercentRv" runat="server" Type="Double" ControlToValidate="PercentTb" MinimumValue="1" MaximumValue="99"
                            ValidationGroup="valid" ForeColor="Red" ErrorMessage="Out of Range" />
                    </div>
                </div>
            </div>
            <div>
                <asp:Label class="col-lg-1 control-label" runat="server" CssClass="col-md-2 control-label">%</asp:Label>
            </div>
        </div>
        <%-- Calendar --%>

        <div class="row">
            <div>
                <div>
                    <asp:Label class="col-lg-2 control-label" ID="calendarStartLabel" runat="server" Text="Start date"></asp:Label>
                    <div class="col-md-2">
                        <asp:TextBox ID="CalendarStartTB" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%--   <div class="col-md-2">
                        <img class="calendar" src="/Images/calendar.ico" />
                    </div>--%>
                </div>
            </div>

            <div>
                <div>
                    <asp:Label class="col-lg-1 control-label" ID="calendarEndLabel" runat="server" Text="End date"></asp:Label>

                    <div class="col-md-2">
                        <asp:TextBox ID="CalendarEndTB" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%--<div class="col-md-2">
                        <img class="calendar" src="/Images/calendar.ico" />
                    </div>--%>
                </div>
            </div>

        </div>
        <div class="clear"></div>

        <%-- Buttons --%>
        <div class="row">
            <div>
                <div class="col-lg-10 col-lg-offset-2">
                    <asp:Button ID="CreateButton" CssClass="btn btn-default" runat="server" Text="Create" Style="float: right" OnClick="CreateButton_Click" />
                    <asp:Button ID="CancelButton" CssClass="btn btn-default" runat="server" Text="Cancel" Style="float: right" OnClick="CancelButton_Click" />
                </div>
            </div>
        </div>
    </div>


    <script src="/Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="/Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="/Content/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=CalendarStartTB.ClientID %>").dynDateTime({
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=CalendarEndTB.ClientID %>").dynDateTime({
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

