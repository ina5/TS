<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurrentTargets.aspx.cs" Inherits="TargetSystem.Views.CurrentTargets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="clear"></div>
    <div class="row">
        <div class="form-group">
            <label class="col-lg-2 control-label">Choose a type:</label>
            <div class="col-lg-10">
                <asp:RadioButtonList ID="TargetTypeRbl" AutoPostBack="true" runat="server"></asp:RadioButtonList>
            </div>
        </div>
    </div>

    <div class="clear"></div>
    <div class="col-lg-6">
        <asp:GridView ID="CTargetsGV" OnRowCommand="Grid_RowCommand" OnRowDataBound="CTargetsGV_RowDataBound" Visible="false" runat="server" Width="500px" CssClass="table  table-bordered table-condensed table-hover">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnDetails" runat="server" Text="Details" UseSubmitBehavior="False" CommandName="Details"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-lg-6">
        <div class="panel panel-primary" visible="false" runat="server" id="panelDetails">
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
                <div class="row">
                    <label class="col-lg-3 control-label">Creator</label>
                    <div class="col-lg-9">
                        <div class="pull-right">
                            <asp:Label ID="TCreator" runat="server" Text="Creator"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
