<%@ Page Title="Contact Us!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TargetSystem.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>We can not solve your problem if you do not tell us about it.</h3>

    <div class="col-sm-6">

        <img src="/Images/VP.jpg" alt="Smiley face" class="img-circle" height="150" width="150" />
        <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">
<%--        <link href="/Content/bootstrap.css" rel="stylesheet" integrity="sha256-MfvZlkHCEqatNoGiOXveE8FIwMzZg4W85qfrfIFBfYc= sha512-dTfge/zgoMYpP7QbHy4gWMEGsbsdZeCXz7irItjcC3sPUFtf0kuFbDz/ixG7ArTxmDjLXDmezHubeNikyKGVyQ==" crossorigin="anonymous">--%>
        <a href="https://www.facebook.com/vaniimark"><i id="social-fb" class="fa fa-facebook-square fa-3x social"></i></a>
        <a href="https://github.com/ina5"><img src="/Images/github-logo.png" class="glyphicon-align-center" height="40" width="40" /> </a>
        <a href="mailto:inapanova5@gmail.com"><i id="social-em" class="fa fa-envelope-square fa-3x social"></i></a>
        <div class="pull-right" style="color:#FFFFFF">

            
        </div>



</div>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
