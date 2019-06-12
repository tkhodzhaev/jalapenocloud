<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Spinner.ascx.cs" Inherits="UI.Controls.Spinner" %>

<style type="text/css">

    #spinnerspan input
    {
    	margin-top: 0px;
    	margin-bottom: 0px;
    	margin-left: 0px;
    	margin-right: 0px;
    	width:60px;
    	height:15px;
    }

</style>

<script type="text/javascript">
    $(function () {
        $("#<%= tbxSpinner.ClientID %>").spinner({
            min: 1,
            max: 500,
            step: 1,
            start: 1
        });
    });
</script>

<span id="spinnerspan">
    <asp:TextBox ID="tbxSpinner" Font-Size="9" runat="server"></asp:TextBox>
</span>
