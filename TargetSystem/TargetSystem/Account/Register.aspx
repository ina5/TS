<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TargetSystem.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new user</h4>
        <hr />
        <div class="row">
            <div class="col-lg-6">
                <%-- First Name --%>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">First Name</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="fName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="fName"
                            CssClass="text-danger" ErrorMessage="The First Name field is required." />
                    </div>
                </div>
                <%-- Surname --%>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Surname</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="surname" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="surname"
                            CssClass="text-danger" ErrorMessage="The Surname field is required." />
                    </div>
                </div>
                <%-- Last Name --%>

                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Last Name</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="lName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="lName"
                            CssClass="text-danger" ErrorMessage="The Last Name field is required." />
                    </div>
                </div>
                <%-- Choose role --%>

                <div class="form-group">
                    <asp:Label ID="roleLabel" runat="server" CssClass="col-md-2 control-label">Role</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList ID="RoleDdl" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>

                <%-- Choose position --%>

                <div class="form-group">
                    <asp:Label runat="server" ID="posLabel" Visible="false" CssClass="col-md-2 control-label">Position</asp:Label>
                    <div class="col-md-6">
                        <asp:DropDownList ID="PositionDdl" Visible="false" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-lg-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Service Email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                            CssClass="text-danger" ErrorMessage="The email field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm Password</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    </div>

                </div>
                <%-- Personal email --%>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Personal Email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="pEmail" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="pEmail"
                            CssClass="text-danger" ErrorMessage="The Personal Email field is required." />
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-8 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Create" CssClass="btn btn-default" />
                <asp:Button runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="CancelButton_Click" />
            </div>

        </div>

    </div>
</asp:Content>
