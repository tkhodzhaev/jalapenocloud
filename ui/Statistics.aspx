<%@ Page Title="Jalapeno Cloud" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="UI.Statistics"
Async="true" ValidateRequest="true" ViewStateMode="Disabled" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="Robots" content="NOINDEX, NOFOLLOW" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="page-header">
        <h4>
            Statistics
        </h4>
    </div>

    <asp:ScriptManager ID="smgrManager" runat="server"></asp:ScriptManager>

    <tru:UserMessage ID="umgOutput" runat="server"></tru:UserMessage>

    <form action="Statistics.aspx">
        <fieldset>
            <tru:TimePeriod ID="tpdRange" runat="server" />
            <div style="height:10px;"></div>
            <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-small btn-primary" onclick="btnFilter_Click" />
        </fieldset>
    </form>

    <hr />

	<div style="width: 350px;text-align: left;padding-left:10px;">
        <asp:Repeater ID="rptData" runat="server">
            <ItemTemplate>
                <div style="height:5px;"></div>
                <span style="padding-left:10px;color:Black;font-size:14px;font-weight:normal;text-decoration:none;">
                    <asp:Label ID="lbtHeader" runat="server" Text='<%# Eval("Key") %>'></asp:Label>:
                </span>
                &nbsp;
                <span style="padding-left:10px;color:#389CF4;font-size:14px;font-weight:bold;text-decoration:none;">
                    <asp:Label ID="lbtData" runat="server" Text='<%# Eval("Value") %>'></asp:Label>
                </span>
                <div style="height:5px;"></div>
                <div style="border-bottom:1px dotted #eee;"></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
