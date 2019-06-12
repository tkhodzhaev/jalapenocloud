<%@ Page Title="Jalapeno Cloud" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="UI.Settings"
Async="true" ValidateRequest="false" ViewStateMode="Enabled" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="Robots" content="NOINDEX, NOFOLLOW" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="page-header">
        <h4>
            Settings
        </h4>
    </div>

    <tru:UserMessage ID="umgOutput" runat="server" ViewStateMode="Disabled"></tru:UserMessage>

    <div style="text-align: center">
	    <div style="width: 100%; margin: 0 auto; text-align: left;">
            <h5 class="text-info">Settings</h5>
        </div>
    </div>

    <br />
    <asp:Button ID="btnGenerateNewKeyPair" runat="server" CssClass="btn btn-danger" Text="Generate new key pair" OnClientClick="return confirm('Are you sure?');" onclick="btnGenerateNewKeyPair_Click" />
    <br /><br />

    <asp:GridView ID="gdvData" runat="server" AutoGenerateColumns="false"
        Width="100%" HorizontalAlign="Center" GridLines="0"
        AutoGenerateEditButton="true"
        CssClass="table table-striped table-condensed"
        onrowediting="gdvData_RowEditing"
        onrowcancelingedit="gdvData_RowCancelingEdit"
        onrowupdating="gdvData_RowUpdating"
        onrowupdated="gdvData_RowUpdated">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
            <asp:BoundField DataField="Key" HeaderText="Key" ReadOnly="true" ItemStyle-Font-Bold="true" />
            <asp:BoundField DataField="Value" HeaderText="Value" />
        </Columns>

    </asp:GridView>

</asp:Content>
