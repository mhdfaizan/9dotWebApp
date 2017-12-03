<%@ Page Title="" Language="C#" MasterPageFile="~/9dot.Master" AutoEventWireup="true" CodeBehind="ReportData.aspx.cs" Inherits="_9dotWebApp.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure want to submit this data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 25%;
        }

        .auto-style3 {
            width: 50%;
        }
        .auto-style4 {
            width: 491px;
        }
        .auto-style5 {
            width: 334px;
        }
        .auto-style6 {
            width: 514px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1" style="vertical-align: top; font-family: Calibri;">
        <tr>
            <td style="text-align: left" class="auto-style4">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" Text="Vertical"></asp:Label>
            </td>
            <td style="text-align: right" class="auto-style5">
                ADS Equity Share:
                <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="TextBox20" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBox20" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td style="text-align: right">
                Year:
                <asp:DropDownList ID="DropDownList5_year" runat="server" OnSelectedIndexChanged="DropDownList5_year_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList5_year" ErrorMessage="*" ForeColor="Red" ValidationGroup="ViewData" AutoPostBack="true"></asp:RequiredFieldValidator>
            </td>
            <td style="text-align: right">
                Month:
                <asp:DropDownList ID="DropDownList4_month" runat="server" OnSelectedIndexChanged="DropDownList4_month_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Jan</asp:ListItem>
                    <asp:ListItem>Feb</asp:ListItem>
                    <asp:ListItem>Mar</asp:ListItem>
                    <asp:ListItem>Apr</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>Jun</asp:ListItem>
                    <asp:ListItem>Jul</asp:ListItem>
                    <asp:ListItem>Aug</asp:ListItem>
                    <asp:ListItem>Sep</asp:ListItem>
                    <asp:ListItem>Oct</asp:ListItem>
                    <asp:ListItem>Nov</asp:ListItem>
                    <asp:ListItem>Dec</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList4_month" ErrorMessage="*" ForeColor="Red" ValidationGroup="ViewData"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
        <table class="auto-style1" style="font-family: Calibri; text-align: right; vertical-align: top;">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Select Currency / Subsidiary:"></asp:Label>
    &nbsp;<asp:DropDownList ID="DropDownList1_country" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1_country" ErrorMessage="*" ForeColor="Red" ValidationGroup="ViewData"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label3" runat="server" Text="Select Vertical:"></asp:Label>
    &nbsp;<asp:DropDownList ID="DropDownList2_vertical" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList2_vertical" ErrorMessage="*" ForeColor="Red" ValidationGroup="ViewData"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Type:"></asp:Label>
    &nbsp;<asp:DropDownList ID="DropDownList3_type" runat="server">
                        <asp:ListItem>Local Currency</asp:ListItem>
                        <asp:ListItem>Actual</asp:ListItem>
                        <asp:ListItem>CC</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    <br />
    <br />
    <table class="auto-style1" style="font-family: Calibri">
        <tr>
            <td class="auto-style3"><strong>Gross Revenue</strong></td>
            <td class="auto-style2">
                <asp:Label ID="Label33" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td class="auto-style2"><strong>Budget</strong></td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp; Gross Transaction Value</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp; Gross Revenue</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table class="auto-style1" style="font-family: Calibri">
        <tr>
            <td class="auto-style3"><strong>Direct Costs / COGS</strong></td>
            <td class="auto-style2">
                <asp:Label ID="Label9" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="Label13" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp; Network</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label14" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp; Direct Labor</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox4" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label15" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp; Commissions</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox5" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label16" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp; Others</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox6" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox6" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label17" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Gross Profit</td>
            <td>
                <asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label18" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table class="auto-style1" style="font-family: Calibri">
        <tr>
            <td class="auto-style3"><strong>OPEX</strong></td>
            <td class="auto-style2">
                <asp:Label ID="Label10" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="Label19" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp; Manpower&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBox8" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox8" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label20" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp; Travelling&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBox9" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox9" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label21" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp; IT Charges&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBox10" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox10" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp; Marketing Cost&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="TextBox11" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBox11" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label23" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp; Professional Charges&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TextBox12" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextBox12" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label24" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp; Others&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="TextBox13" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBox13" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label25" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>EBITDA</td>
            <td>
                <asp:Label ID="Label7" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label26" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table class="auto-style1" style="font-family: Calibri">
        <tr>
            <td class="auto-style3">Depreciation</td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="TextBox15" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TextBox15" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style2">
                <asp:Label ID="Label27" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Net Interest (Income or Expense)</td>
            <td>
                <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="TextBox16" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TextBox16" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label28" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Others</td>
            <td>
                <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="TextBox17" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox17" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label29" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Share of Results</td>
            <td>
                <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="TextBox18" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TextBox18" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label30" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Tax</td>
            <td>
                <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="TextBox19" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TextBox19" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label31" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Profit After Tax</td>
            <td>
                <asp:Label ID="Label8" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label32" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table class="auto-style1" style="font-family: Calibri">
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" ForeColor="#009900">Successful submission message</asp:Label>
            </td>
            <td>
                <asp:Button ID="Button5_clear_all" runat="server" Text="Clear all" OnClick="Button5_Click_ClearAllData"/>
            </td>
            <td>
                <asp:Button ID="Button2_edit" runat="server" Text="Edit" OnClick="Button2_Click_EditData" ValidationGroup="ViewData"/>
            </td>
            <td>
                <asp:Button ID="Button3_save" runat="server" Text="Save &amp; Exit" OnClick="Button3_Click_SaveData" ValidationGroup="Group1"/>
            </td>
            <td>
                <asp:Button ID="Button4_submit" runat="server" Text="Submit" OnClick="Button4_Click_SubmitData" OnClientClick="Confirm()"/>
            </td>
            <td>
                <asp:Button ID="Button6_view" runat="server" OnClick="Button6_Click_ViewData" Text="View" ValidationGroup="ViewData" />
            </td>
        </tr>
    </table>

    <br />
    <br />
</asp:Content>
