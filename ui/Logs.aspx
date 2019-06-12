<%@ Page Title="Jalapeno Cloud" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="UI.Logs"
Async="true" ValidateRequest="true" ViewStateMode="Enabled" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="Robots" content="NOINDEX, NOFOLLOW" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="page-header">
        <h4>
            Logs
        </h4>
    </div>

    <asp:ScriptManager ID="smgrManager" runat="server"></asp:ScriptManager>

    <div class="form-group">
        <tru:TimePeriod ID="tpdRange" runat="server" ViewStateMode="Disabled" />
    </div>
    <div style="height:4px;"></div>
    <div class="form-group">
        <div style="height:5px;"></div>
        <span>Page size&nbsp;</span>
        <tru:Spinner ID="tspPageSize" runat="server" Value="20" ViewStateMode="Disabled" />
    </div>
    <br />
    <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-small btn-primary" OnClick="btnFilter_Click" ViewStateMode="Disabled" />
    <hr />

    <tru:UserMessage ID="umgOutput" runat="server" ViewStateMode="Disabled"></tru:UserMessage>

    <div style="text-align: center">
	    <div style="width: 100%; margin: 0 auto; text-align: left;">
            <h5 class="text-info"><asp:Label ID="lblGridHeader" runat="server" Text="Exceptions"></asp:Label></h5>
        </div>
    </div>

    <tru:PagingGrid ID="pgdData" runat="server" AutoGenerateColumns="true"
        AllowPaging="true" PagerSettings-Position="TopAndBottom"
        HorizontalAlign="Center" GridLines="0"
        CssClass="table table-striped table-condensed"
        OnPageIndexChanged="pgdData_PageIndexChanged"
        HeaderStyle-Wrap="true" RowStyle-Wrap="true" RowStyle-Font-Size="8">
        <Columns>
        </Columns>
        <EmptyDataTemplate>
            <br /><br /><i>No data.</i>
        </EmptyDataTemplate>
    </tru:PagingGrid>

</asp:Content>
