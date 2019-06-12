<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserMessage.ascx.cs" Inherits="UI.Controls.UserMessage" %>

<script type="text/javascript">

    function showmessage(message, t, color, classname) {
        $("<div style=\"color:" + color + ";font-size:12px\">" + message + "</div>").floatingMessage({
            show: "fold",
            hide: "puff",
            stuffEaseTime: 500,
            stuffEasing: "swing",
            moveEaseTime: 200,
            moveEasing: "easeInExpo",
            time: t,
            className: classname
        });
    };

</script>

<asp:Repeater ID="rptStaticMessages" runat="server" Visible="false">
    <ItemTemplate>
        <asp:Panel ID="pnlStaticMessage" runat="server" CssClass='<%# Eval("Value") %>'>
            <asp:Label ID="lblStaticMessage" runat="server" Text='<%# Eval("Key") %>'>></asp:Label>
        </asp:Panel>
    </ItemTemplate>
</asp:Repeater>

<asp:Panel ID="pnlStaticMessage" runat="server" Visible="false">
    <asp:Label ID="lblStaticMessage" runat="server" Text=""></asp:Label>
</asp:Panel>
