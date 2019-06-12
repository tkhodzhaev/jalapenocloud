<%@ Page Title="Jalapeno Cloud" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Login"
Async="true" ValidateRequest="true" ViewStateMode="Enabled" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="Robots" content="NOINDEX, NOFOLLOW" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <div class="page-header">
        <h4>
            Log In
        </h4>
    </div>

    <tru:UserMessage ID="umgOutput" runat="server"></tru:UserMessage>

    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">

        <div class="control-group">
            <label class="control-label">Email</label>
            <div class="controls">
                <asp:TextBox ID="tbxEmail" runat="server" MaxLength="128">
                </asp:TextBox>
            </div>
        </div>

        <div class="control-group">
            <label class="control-label">Password</label>
            <div class="controls">
                <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" MaxLength="512">
                </asp:TextBox>
            </div>
        </div>

        <asp:Button ID="btnLogin" runat="server" Text="Log In"
                    CssClass="btn btn-small btn-primary"
                    onclick="btnLogin_Click" />

        <br /><br />

        <div style="font-size:12px;">
            <asp:CheckBox ID="chbRememberMe" runat="server" />&nbsp;Remember Me
        </div>

    </asp:Panel>

</asp:Content>
