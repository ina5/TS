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
        <asp:GridView ID="CTargetsGV"
            OnRowCommand="Grid_RowCommand"
            OnRowDataBound="CTargetsGV_RowDataBound"
            Visible="false"
            ItemType="TargetSystem.ViewModel.UserTargetView"
            runat="server"
            Width="500px"
            CssClass="table  table-bordered table-condensed table-hover"
            AutoGenerateColumns="false">
            <Columns>

                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Goal" HeaderText="Goal" />
                <asp:BoundField DataField="Percent" HeaderText="Percent" />

                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDetails" class="btn btn-info" runat="server" Text="Details"  CommandName="Details"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-lg-6">
        <div class="row">
            <div class="panel panel-info" visible="false" runat="server" id="panelDetails">
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
                        <asp:Label ID="TPercent" runat="server" class="col-lg-3 control-label">Percent</asp:Label>
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
                    <div class="row">

                        <div class="col-lg-12">
                            <div class="pull-right">
                                <asp:Button ID="Mark_btn" class="btn btn-success" runat="server" Text="Submit" OnClick="Mark_btn_Click" />
                                <asp:Button ID="Close_btn" class="btn btn-default" runat="server" Text="Close" OnClick="Close_btn_Click" />
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
        <div class="row">

            <div class="panel panel-info" runat="server" visible="false" id="panelMark">
                <div class="panel-heading">
                    <h3 class="panel-title">Note</h3>
                </div>
                <div class="panel-body">
                    <textarea id="NoteTextArea" runat="server" cols="60" rows="2"></textarea>
                    <div class="col-lg-12">
                        <div class="pull-right">
                            <asp:Button ID="Send_btn" class="btn btn-success" runat="server" Text="Send" OnClick="Send_btn_Click" />
                            <asp:Button ID="Cancel_btn" class="btn btn-default" runat="server" Text="Cancel" OnClick="Cancel_btn_Click" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
