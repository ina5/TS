<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompletedTargets.aspx.cs" Inherits="TargetSystem.Views.CompletedTargets" %>
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
                        <asp:Button ID="btnDetails" class="btn btn-info" runat="server" Text="Details" UseSubmitBehavior="False" CommandName="Details"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
