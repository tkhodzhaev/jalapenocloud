<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimePeriod.ascx.cs" Inherits="UI.Controls.TimePeriod" %>

<style type="text/css">
    .ui-datepicker {
    background: #fff;
    font-size:10px;
    padding:10px;
    border:1px dotted #ccc;
    }
    .ui-datepicker table {
    width:170px;
    }
    .ui-datepicker table td {
    text-align:center;
    }
    .ui-datepicker a {
    cursor:pointer;
    text-decoration:none;
    }
    .ui-datepicker-prev {
    }
    .ui-datepicker-next {
    float:right;
    }
    .ui-datepicker-title {
    text-align: center;
    font-weight:bold;
    }
</style>

<script type="text/javascript">
    jQuery(function ($) {
        $.datepicker.regional['ru'] = {
            closeText: 'Закрыть',
            prevText: '&#x3c;Пред',
            nextText: 'След&#x3e;',
            currentText: 'Сегодня',
            monthNames: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь',
                'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
            monthNamesShort: ['Янв', 'Фев', 'Мар', 'Апр', 'Май', 'Июн',
                'Июл', 'Авг', 'Сен', 'Окт', 'Ноя', 'Дек'],
            dayNames: ['воскресенье', 'понедельник', 'вторник', 'среда', 'четверг', 'пятница', 'суббота'],
            dayNamesShort: ['вск', 'пнд', 'втр', 'срд', 'чтв', 'птн', 'сбт'],
            dayNamesMin: ['ВС', 'ПН', 'ВТ', 'СР', 'ЧТ', 'ПТ', 'СБ'],
            weekHeader: 'Не',
            dateFormat: 'dd.mm.yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['ru']);
    });

    $(document).ready(function () {
        $("#<%= tbxStart.ClientID %>").datepicker({ dateFormat: 'dd.mm.yy' });
        $("#<%= tbxEnd.ClientID %>").datepicker({ dateFormat: 'dd.mm.yy' });
    });
</script>

From&nbsp;
<asp:TextBox ID="tbxStart" runat="server" Width="90px" Height="15px" MaxLength="10" Font-Size="9" CssClass="input-small"></asp:TextBox>
&nbsp;To&nbsp;
<asp:TextBox ID="tbxEnd" runat="server" Width="90px" Height="15px" MaxLength="10" Font-Size="9" CssClass="input-small"></asp:TextBox>
