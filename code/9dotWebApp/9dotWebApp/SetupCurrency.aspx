<%@ Page Title="" Language="C#" MasterPageFile="~/9dot.Master" AutoEventWireup="true" CodeBehind="SetupCurrency.aspx.cs" Inherits="_9dotWebApp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="css/stylesheet.css" rel="stylesheet" type="text/css" />--%>
    <link href="https://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="css/MonthPicker.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/examples.css" />

    <script src="https://code.jquery.com/jquery-1.12.1.min.js"></script>
    <script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
    <script src="https://cdn.rawgit.com/digitalBush/jquery.maskedinput/1.4.1/dist/jquery.maskedinput.min.js"></script>
    <script src="js/MonthPicker.min.js"></script>

    <script type='text/javascript'>
        $(function () {
            $('#IconDemo').MonthPicker({ StartYear: 2012, ShowIcon: true, MonthFormat: 'M, yy' });
        });

    </script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style3 {
            height: 23px;
            text-align: left;
        }
        .auto-style4 {
            width: 80%;
        }
        .auto-style5 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1" style="font-family: Calibri">
        <tr>
            <td class="auto-style2">
                <%--<input id="IconDemo" class='Default' type="text" name="month_year"/>--%>
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ForeColor="Red" ValidationGroup="YearValidation"></asp:RequiredFieldValidator>
                &nbsp;
                <asp:Button ID="Button1_view" runat="server" Text="View" OnClick="Button1_Click_ViewYearData" ValidationGroup="YearValidation" />
            </td>
        </tr>
    </table>
    <br />
    <table class="auto-style1" style="font-family: Calibri; text-align: center;">
        <tr>
            <td class="auto-style3" colspan="18" style="vertical-align: top;">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Foreign Currencies to USD (Monthly, Quarterly &amp; Yearly Average) - "></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;" class="auto-style5">&nbsp;</td>
            <td style="vertical-align: top;"><strong>Jan</strong></td>
            <td style="vertical-align: top;"><strong>Feb</strong></td>
            <td style="vertical-align: top;"><strong>Mar</strong></td>
            <td style="vertical-align: top;"><strong>Apr</strong></td>
            <td style="vertical-align: top;"><strong>May</strong></td>
            <td style="vertical-align: top;"><strong>Jun</strong></td>
            <td style="vertical-align: top;"><strong>Jul</strong></td>
            <td style="vertical-align: top;"><strong>Aug</strong></td>
            <td style="vertical-align: top;"><strong>Sep</strong></td>
            <td style="vertical-align: top;"><strong>Oct</strong></td>
            <td style="vertical-align: top;"><strong>Nov</strong></td>
            <td style="vertical-align: top;"><strong>Dec</strong></td>
            <td style="vertical-align: top;"><strong>Q1</strong></td>
            <td style="vertical-align: top;"><strong>Q2</strong></td>
            <td style="vertical-align: top;"><strong>Q3</strong></td>
            <td style="vertical-align: top;"><strong>Q4</strong></td>
            <td style="vertical-align: top;"><strong>YTD Avg.</strong></td>
        </tr>
        <tr>
            <td style="vertical-align: top;" class="auto-style5"><strong>MYR</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox2" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox7" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox7" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox12" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox12" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox17" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox17" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox22" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox22" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox27" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox27" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox32" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBox32" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox37" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBox37" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox42" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBox42" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox47" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="TextBox47" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox52" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TextBox52" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox57" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="TextBox57" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox62" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="TextBox62" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox67" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="TextBox67" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox72" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="TextBox72" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox77" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="TextBox77" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox82" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;" class="auto-style5"><strong>IDR</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox3" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox8" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="TextBox8" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox13" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="TextBox13" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox18" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="TextBox18" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox23" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="TextBox23" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox28" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="TextBox28" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox33" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="TextBox33" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox38" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ControlToValidate="TextBox38" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox43" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ControlToValidate="TextBox43" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox48" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ControlToValidate="TextBox48" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox53" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" ControlToValidate="TextBox53" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox58" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ControlToValidate="TextBox58" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox63" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox68" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox73" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox78" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox83" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;" class="auto-style5"><strong>LKR</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox4" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server" ControlToValidate="TextBox4" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox9" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server" ControlToValidate="TextBox9" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox14" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator37" runat="server" ControlToValidate="TextBox14" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox19" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator38" runat="server" ControlToValidate="TextBox19" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox24" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator39" runat="server" ControlToValidate="TextBox24" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox29" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server" ControlToValidate="TextBox29" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox34" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server" ControlToValidate="TextBox34" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox39" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server" ControlToValidate="TextBox39" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox44" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server" ControlToValidate="TextBox44" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox49" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator44" runat="server" ControlToValidate="TextBox49" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox54" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator45" runat="server" ControlToValidate="TextBox54" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox59" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator46" runat="server" ControlToValidate="TextBox59" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox64" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator71" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox69" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator72" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox74" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator73" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox79" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator74" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox84" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator75" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;" class="auto-style5"><strong>BDT</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox5" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator47" runat="server" ControlToValidate="TextBox5" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox10" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator48" runat="server" ControlToValidate="TextBox10" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox15" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator49" runat="server" ControlToValidate="TextBox15" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox20" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator50" runat="server" ControlToValidate="TextBox20" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox25" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator51" runat="server" ControlToValidate="TextBox25" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox30" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator52" runat="server" ControlToValidate="TextBox30" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox35" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator53" runat="server" ControlToValidate="TextBox35" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox40" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator54" runat="server" ControlToValidate="TextBox40" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox45" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator55" runat="server" ControlToValidate="TextBox45" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox50" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator56" runat="server" ControlToValidate="TextBox50" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox55" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator57" runat="server" ControlToValidate="TextBox55" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox60" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator58" runat="server" ControlToValidate="TextBox60" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox65" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator76" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox70" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator77" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox75" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator78" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox80" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator79" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox85" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator80" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;" class="auto-style5"><strong>INR</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox6" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator59" runat="server" ControlToValidate="TextBox6" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox11" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator60" runat="server" ControlToValidate="TextBox11" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox16" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator61" runat="server" ControlToValidate="TextBox16" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox21" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator62" runat="server" ControlToValidate="TextBox21" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox26" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator63" runat="server" ControlToValidate="TextBox26" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox31" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator64" runat="server" ControlToValidate="TextBox31" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox36" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator65" runat="server" ControlToValidate="TextBox36" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox41" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator66" runat="server" ControlToValidate="TextBox41" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox46" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator67" runat="server" ControlToValidate="TextBox46" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox51" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator68" runat="server" ControlToValidate="TextBox51" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox56" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator69" runat="server" ControlToValidate="TextBox56" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox61" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator70" runat="server" ControlToValidate="TextBox61" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox66" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator81" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox71" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator82" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox76" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator83" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox81" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator84" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox86" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator85" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;" class="auto-style5"><strong>AUD</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox152" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="TextBox152" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox153" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator91" runat="server" ControlToValidate="TextBox153" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox154" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator92" runat="server" ControlToValidate="TextBox154" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox155" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator93" runat="server" ControlToValidate="TextBox155" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox156" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator94" runat="server" ControlToValidate="TextBox156" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox157" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator95" runat="server" ControlToValidate="TextBox157" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox158" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator96" runat="server" ControlToValidate="TextBox158" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox159" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator97" runat="server" ControlToValidate="TextBox159" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox160" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator98" runat="server" ControlToValidate="TextBox160" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox161" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator99" runat="server" ControlToValidate="TextBox161" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox162" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator100" runat="server" ControlToValidate="TextBox162" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox163" runat="server" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator101" runat="server" ControlToValidate="TextBox163" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox164" runat="server" Width="60px" ReadOnly="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator102" runat="server" ControlToValidate="TextBox164" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox165" runat="server" Width="60px" ReadOnly="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator103" runat="server" ControlToValidate="TextBox165" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox166" runat="server" Width="60px" ReadOnly="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator104" runat="server" ControlToValidate="TextBox166" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox167" runat="server" Width="60px" ReadOnly="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator105" runat="server" ControlToValidate="TextBox167" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox168" runat="server" Width="60px" ReadOnly="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator106" runat="server" ControlToValidate="TextBox168" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>

    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Red" Text="*"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Required"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#FFCC00" Text="*"></asp:Label>
&nbsp;<asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Only decimal values and integers are allowed"></asp:Label>
            </td>
            <td>
                <asp:Button ID="Button2_edit_actual" runat="server" Text="Edit" OnClick="Button2_Click_EditMonthData"/>
            </td>
            <td>
                <asp:Button ID="Button3_save_actual" runat="server" Text="Save" OnClick="Button3_Click_SaveMonthData" ValidationGroup="Group1"/>
            </td>
            <td>
                <asp:Button ID="Button4_submit_actual" runat="server" Text="Submit &amp; Apply" ValidationGroup="Group1" OnClick="Button4_Click_SubmitMonthData"/>
            </td>
        </tr>
    </table>

    <br />
    <br />
    <br />
    <table class="auto-style1" style="border: thin none #000000; font-family: Calibri; text-align: center;">
        <tr>
            <td colspan="14" style="text-align: left;"><strong style="text-align: left">CC Rate</strong></td>
        </tr>
        <tr>
            <td style="text-align: left;"><strong></strong></td>
            <td style="vertical-align: top;"><strong>Jan</strong></td>
            <td style="vertical-align: top;"><strong>Feb</strong></td>
            <td style="vertical-align: top;"><strong>Mar</strong></td>
            <td style="vertical-align: top;"><strong>Apr</strong></td>
            <td style="vertical-align: top;"><strong>May</strong></td>
            <td style="vertical-align: top;"><strong>Jun</strong></td>
            <td style="vertical-align: top;"><strong>Jul</strong></td>
            <td style="vertical-align: top;"><strong>Aug</strong></td>
            <td style="vertical-align: top;"><strong>Sep</strong></td>
            <td style="vertical-align: top;"><strong>Oct</strong></td>
            <td style="vertical-align: top;"><strong>Nov</strong></td>
            <td style="vertical-align: top;"><strong>Dec</strong></td>
            <td style="vertical-align: top;"><strong>CC Rate</strong></td>
        </tr>
        <tr>
            <td style="text-align: left;"><strong>MYR</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox87" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox92" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox97" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox102" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox107" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox112" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox117" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox122" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox127" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox132" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox137" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox142" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox147" runat="server" Width="80px" TabIndex="1"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator86" runat="server" ControlToValidate="TextBox147" ValidationGroup="Group2" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox147" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;"><strong>IDR</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox88" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox93" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox98" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox103" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox108" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox113" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox118" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox123" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox128" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox133" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox138" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox143" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox148" runat="server" Width="80px" TabIndex="2"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator87" runat="server" ControlToValidate="TextBox148" ValidationGroup="Group2" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox148" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;"><strong>LKR</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox89" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox94" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox99" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox104" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox109" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox114" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox119" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox124" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox129" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox134" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox139" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox144" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox149" runat="server" Width="80px" TabIndex="3"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator88" runat="server" ControlToValidate="TextBox149" ValidationGroup="Group2" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox149" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;"><strong>BDT</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox90" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox95" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox100" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox105" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox110" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox115" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox120" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox125" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox130" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox135" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox140" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox145" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox150" runat="server" Width="80px" TabIndex="4"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator89" runat="server" ControlToValidate="TextBox150" ValidationGroup="Group2" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox150" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;"><strong>INR</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox91" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox96" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox101" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox106" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox111" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox116" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox121" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox126" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox131" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox136" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox141" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox146" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox151" runat="server" Width="80px" TabIndex="5"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator90" runat="server" ControlToValidate="TextBox151" ValidationGroup="Group2" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox151" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;"><strong>AUD</strong></td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox169" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox170" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox171" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox172" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox173" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox174" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox175" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox176" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox177" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox178" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox179" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox180" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="TextBox181" runat="server" Width="80px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator107" runat="server" ControlToValidate="TextBox181" ValidationGroup="Group2" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox181" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="Red" Text="*"></asp:Label>
&nbsp;<asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Required"></asp:Label>
                <br />
                <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" ForeColor="#FFCC00" Text="*"></asp:Label>
&nbsp;<asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" Text="Only decimal values and integers are allowed"></asp:Label>
            </td>
            <td>
                <asp:Button ID="Button5_edit_cc" runat="server" Text="Edit" OnClick="Button5_Click_EditCCData" />
            </td>
            <td>
                <asp:Button ID="Button6_save_cc" runat="server" Text="Save" OnClick="Button6_Click_SaveCCData" ValidationGroup="Group2" />
            </td>
            <td>
                <asp:Button ID="Button7_submit_cc" runat="server" Text="Submit &amp; Apply" OnClick="Button7_Click_SubmitCCData"/>
            </td>
        </tr>
    </table>

    <br />

    <br />
    <br />
    <table class="auto-style1" style="font-family: Calibri; text-align: center">
        <tr>
            <td colspan="18" style="text-align: left"><strong>Actual Rate for Budget</strong></td>
        </tr>
        <tr>
            <td><strong></strong></td>
            <td><strong>Jan</strong></td>
            <td><strong>Feb</strong></td>
            <td><strong>Mar</strong></td>
            <td><strong>Apr</strong></td>
            <td><strong>May</strong></td>
            <td><strong>Jun</strong></td>
            <td><strong>Jul</strong></td>
            <td><strong>Aug</strong></td>
            <td><strong>Sep</strong></td>
            <td><strong>Oct</strong></td>
            <td><strong>Nov</strong></td>
            <td><strong>Dec</strong></td>
            <td><strong>Q1</strong></td>
            <td><strong>Q2</strong></td>
            <td><strong>Q3</strong></td>
            <td><strong>Q4</strong></td>
            <td><strong>YTD Avg.</strong></td>
        </tr>
        <tr>
            <td><strong>MYR</strong></td>
            <td>
                <asp:TextBox ID="TextBox182" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox183" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox184" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox185" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox186" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox187" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox188" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox189" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox190" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox191" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox192" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox193" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox194" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox195" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox196" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox197" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox198" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><strong>IDR</strong></td>
            <td>
                <asp:TextBox ID="TextBox199" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox200" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox201" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox202" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox203" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox204" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox205" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox206" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox207" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox208" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox209" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox210" runat="server" Width="60px" ReadOnly="true"> </asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox211" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox212" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox213" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox214" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox215" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><strong>LKR</strong></td>
            <td>
                <asp:TextBox ID="TextBox216" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox217" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox218" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox219" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox220" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox221" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox222" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox223" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox224" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox225" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox226" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox227" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox228" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox229" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox230" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox231" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox232" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><strong>BDT</strong></td>
            <td>
                <asp:TextBox ID="TextBox233" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox234" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox235" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox236" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox237" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox238" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox239" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox240" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox241" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox242" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox243" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox244" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox245" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox246" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox247" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox248" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox249" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><strong>INR</strong></td>
            <td>
                <asp:TextBox ID="TextBox250" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox251" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox252" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox253" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox254" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox255" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox256" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox257" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox258" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox259" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox260" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox261" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox262" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox263" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox264" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox265" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox266" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><strong>AUD</strong></td>
            <td>
                <asp:TextBox ID="TextBox267" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox268" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox269" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox270" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox271" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox272" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox273" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox274" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox275" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox276" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox277" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox278" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox279" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox280" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox281" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox282" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox283" runat="server" Width="60px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
    </table>

    <br />
    <br />

</asp:Content>
