<%@ Page Title="Jalapeno Cloud" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="UI.Administrator"
Async="true" ValidateRequest="true" ViewStateMode="Enabled" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="Robots" content="NOINDEX, NOFOLLOW" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="page-header">
        <h4>
            Add/Edit Administrator
        </h4>
    </div>

    <tru:UserMessage ID="umgOutput" runat="server" ViewStateMode="Disabled"></tru:UserMessage>

    <h5>
        Account Info
    </h5>
    <br />

    <asp:Panel ID="pnlAccountInfo" runat="server" DefaultButton="btnSave">

        <fieldset>
            <span>Email&nbsp;</span>
            <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
            <div style="height:5px;"></div>
            <span>Name&nbsp;</span>
            <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>

            <asp:PlaceHolder ID="phlPasswordSection" runat="server" Visible="true">
                <div style="height:5px;"></div>
                <span>Password&nbsp;</span>
                <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
                <div style="height:5px;"></div>
                <span>Confirm password&nbsp;</span>
                <asp:TextBox ID="tbxPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
            </asp:PlaceHolder>

            <br /><br />
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-small btn-primary" ViewStateMode="Disabled" onclick="btnSave_Click" />
        </fieldset>

    </asp:Panel>

    <asp:PlaceHolder ID="phlChangePasswordSection" runat="server" Visible="false">

        <br />
        <h5>
            Password Changing
        </h5>
        <br />

        <asp:Panel ID="pnlPasswordChanging" runat="server" DefaultButton="btnChangePassword">

            <fieldset>
                <span>Old password&nbsp;</span>
                <asp:TextBox ID="tbxOldPassword" runat="server" TextMode="Password"></asp:TextBox>
                <div style="height:5px;"></div>
                <span>New password&nbsp;</span>
                <asp:TextBox ID="tbxNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                <div style="height:5px;"></div>
                <span>Confirm new password&nbsp;</span>
                <asp:TextBox ID="tbxNewPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnChangePassword" runat="server" Text="Change password" CssClass="btn btn-small btn-primary" ViewStateMode="Disabled" onclick="btnChangePassword_Click" />
            </fieldset>

        </asp:Panel>

    </asp:PlaceHolder>

</asp:Content>
