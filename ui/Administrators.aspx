<%@ Page Title="Jalapeno Cloud" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Administrators.aspx.cs" Inherits="UI.Administrators"
Async="true" ValidateRequest="true" ViewStateMode="Enabled" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="Robots" content="NOINDEX, NOFOLLOW" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="page-header">
        <h4>
            Administrators
        </h4>
    </div>

    <tru:UserMessage ID="umgOutput" runat="server" ViewStateMode="Disabled"></tru:UserMessage>

    <asp:HyperLink ID="hplEdit" runat="server" NavigateUrl="~/Administrator.aspx" Text="+ Add" CssClass="btn-primary btn-small"></asp:HyperLink>

    <br /><br />

    <div style="text-align: center">
	    <div style="width: 100%; margin: 0 auto; text-align: left;">
            <h5 class="text-info">Administrators</h5>
        </div>
    </div>

    <asp:GridView ID="gdvData" runat="server" AutoGenerateColumns="false"
        Width="100%" HorizontalAlign="Center" GridLines="0"
        CssClass="table table-striped table-condensed" 
        onrowcommand="gdvData_RowCommand">
        <Columns>
            <asp:TemplateField ItemStyle-ForeColor="#0764B5" ItemStyle-Width="5%" ItemStyle-Wrap="true" Visible="true">
                <ItemTemplate>
                    <asp:LinkButton ID="lbnDelete" runat="server" Text="Delete" CommandName="Remove" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure?');">
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-ForeColor="#0764B5" ItemStyle-Width="5%" ItemStyle-Wrap="true" Visible="true">
                <ItemTemplate>
                    <asp:HyperLink ID="hplEdit" runat="server" NavigateUrl='<%# "~/Administrator.aspx?id=" + Eval("Id") %>' Text="Edit" CssClass="btn-link"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="true" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="true" />
        </Columns>

    </asp:GridView>

</asp:Content>
