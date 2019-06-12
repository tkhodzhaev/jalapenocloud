<%@ Page Title="Jalapeno Cloud" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Spammers.aspx.cs" Inherits="UI.Spammers"
Async="true" ValidateRequest="true" ViewStateMode="Enabled" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="Robots" content="NOINDEX, NOFOLLOW" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="page-header">
        <h4>
            Spammers
        </h4>
    </div>

    <asp:ScriptManager ID="smgrManager" runat="server"></asp:ScriptManager>

    <div class="form-group">
        <tru:TimePeriod ID="tpdRange" runat="server" ViewStateMode="Disabled" />
    </div>
    <div style="height:4px;"></div>
    <div class="form-group">
        <label>Order</label>
        <asp:DropDownList ID="ddlSortOrder" runat="server">
            <asp:ListItem Text="RegistrationDate" Value="RegistrationDate" Selected="True"></asp:ListItem>
            <asp:ListItem Text="TotalComplaints" Value="TotalComplaints" Selected="False"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div style="height:4px;"></div>
    <div class="form-group">
        <label>Search</label>
        <asp:TextBox ID="tbxSearch" runat="server" Font-Size="9" Height="15px" Width="268px"></asp:TextBox>
    </div>
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
            <h5 class="text-info"><asp:Label ID="lblGridHeader" runat="server" Text="Spammers"></asp:Label></h5>
        </div>
    </div>

    <tru:PagingGrid ID="pgdData" runat="server" AutoGenerateColumns="true"
        AllowPaging="true" PagerSettings-Position="TopAndBottom"
        HorizontalAlign="Center" GridLines="0"
        CssClass="table table-striped table-condensed"
        OnPageIndexChanged="pgdData_PageIndexChanged" OnRowCommand="pgdData_RowCommand"
        HeaderStyle-Wrap="true" RowStyle-Wrap="true" RowStyle-Font-Size="9">
        <Columns>
            <asp:TemplateField ItemStyle-ForeColor="#0764B5" ItemStyle-Wrap="true" HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="lbnDelete" runat="server" Text="Delete" CommandName="Ban" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('Are you sure?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <br /><br /><i>No data.</i>
        </EmptyDataTemplate>
    </tru:PagingGrid>

</asp:Content>
