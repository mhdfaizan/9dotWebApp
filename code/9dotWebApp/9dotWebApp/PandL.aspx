<%@ Page Title="" Language="C#" MasterPageFile="~/9dot.Master" AutoEventWireup="true" CodeBehind="PandL.aspx.cs" Inherits="_9dotWebApp.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
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
    <div class="mtb-30"></div>
    <div class="col-lg-12 form-gross">
        <div class="alert alert-light" role="alert">
            <table>
                <tr>
                    <td style="width: 45px;">
                        <img style="height: 30px;" src="images/alert.png" /></td>
                    <td>Step 3: This Interface is for entering Profit and Loss values in local currency for selected month. Once submited Constant Currency and actual rates will be applied.</td>
                </tr>
            </table>
            <!--a href="#" class="alert-link">an example link</a-->

        </div>
        <div class="col-lg-12">
            <h2 class="heading-ver">
                <asp:Label ID="Label1" runat="server" Text="Vertical"></asp:Label></h2>
        </div>


        <div class="col-lg-12 panel-vertical">
            <table class="auto-style1" style="font-family: Calibri; vertical-align: top;">
                <tr>
                    <td class="col-lg-4 input-group">
                        <div class="col-lg-12">
                            <div class="col-lg-12">
                                <div class="col-lg-12">
                                    <div class="col-lg-12">
                                        <div class="col-lg-12">
                                            <asp:Label ID="Label2" runat="server" Text="Select Country / Subsidiary:"></asp:Label>
                                            &nbsp;<asp:DropDownList ID="DropDownList1_country" CssClass="form-control" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1_country" ErrorMessage="*" ForeColor="Red" ValidationGroup="ViewData"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td class="col-lg-4 input-group">
                        <div class="col-lg-12">
                            <div class="col-lg-12">
                                <div class="col-lg-12">
                                    <div class="col-lg-12">
                                        <div class="col-lg-12">
                                            <asp:Label ID="Label3" runat="server" Text="Select Vertical:"></asp:Label>
                                            &nbsp;<asp:DropDownList ID="DropDownList2_vertical" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList2_vertical" ErrorMessage="*" ForeColor="Red" ValidationGroup="ViewData"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                    <td class="col-lg-4 input-group">
                        <div class="col-lg-12">
                            <div class="col-lg-12">
                                <div class="col-lg-12">
                                    <div class="col-lg-12">
                                        <div class="col-lg-12">
                                            <asp:Label ID="Label4" runat="server" Text="Type:"></asp:Label>
                                            &nbsp;<asp:DropDownList ID="DropDownList3_type" CssClass="form-control" runat="server">
                                                <asp:ListItem>Local Currency</asp:ListItem>
                                                <asp:ListItem>Actual</asp:ListItem>
                                                <asp:ListItem>CC</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br clear="all" />
        <div class="mtb-30"></div>

        <div class="pull-right month-select">
            <table>
                <tr>
                    <td class="form-group">
                        <label class="control-label pa-0" for="name">ADS Equity Share (%):</label>
                    </td>
                    <td class="equity-share"><asp:TextBox ID="TextBox20" CssClass="form-year setup-curency-year" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="TextBox20" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBox20" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator></td>
                    <td class="form-group">
                        <label class="control-label select-year" for="name">Year:&nbsp;&nbsp;</label>
                    </td>
                    <td><asp:DropDownList ID="DropDownList5_year" CssClass="form-year setup-curency-year" runat="server" OnSelectedIndexChanged="DropDownList5_year_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList5_year" ErrorMessage="*" ForeColor="Red" ValidationGroup="ViewData" AutoPostBack="true"></asp:RequiredFieldValidator></td>
                    <td><label class="control-label select-year" for="name">Month:&nbsp;&nbsp;</label></td>
                    <td class="form-group">
                        <asp:DropDownList ID="DropDownList4_month" CssClass="form-year setup-curency-year" runat="server" OnSelectedIndexChanged="DropDownList4_month_SelectedIndexChanged" AutoPostBack="true">
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
                    <td class="form-group">
                        <asp:Button ID="Button6_view" CssClass="btn-sub-enabled" runat="server" OnClick="Button6_Click_ViewData" Text="View" ValidationGroup="ViewData" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-lg-12 form-gross">
            <div class="form-head">
                <div class="mtb-30"></div>
                <div class="col-md-6">
                    <h3>Gross Revenue</h3>
                </div>
                <div class="col-md-2 text-right">
                    <h3>
                        <asp:Label  ID="Label33" runat="server"></asp:Label></h3>
                </div>
                <div class="col-md-4 text-left">
                    <h3>Budget</h3>
                </div>
                <div class="mtb-30"></div>
            </div>
            <br clear="all" />
            <div class="form-group">
                <label class="col-md-6 control-label">Gross Transaction Value</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label11" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Gross Revenue</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="TextBox2" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label12" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="form-head">
                <div class="mtb-30"></div>
                <div class="col-md-6">
                    <h3>Direct Costs / COGS</h3>
                </div>
                <div class="col-md-2 text-right">
                    <h3>
                        <asp:Label ID="Label9" runat="server"></asp:Label></h3>
                </div>
                <div class="col-md-4 text-left">
                    <h3>
                        <asp:Label ID="Label13" runat="server"></asp:Label></h3>
                </div>
                <div class="mtb-30"></div>
            </div>
            <div class="mtb-30"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Network</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox3" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label14" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Direct Labor</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox4" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label15" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Commissions</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox5" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label16" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Others</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox6" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox6" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label17" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label font-18">Gross Profit</label>
                <div class="col-md-2 text-right">
                    <asp:Label ID="Label6" CssClass="text-right font-18" runat="server"></asp:Label>
                </div>
                <div class="col-md-4 text-left">
                    <asp:Label ID="Label18" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-head">
                <div class="mtb-30"></div>
                <div class="col-md-6">
                    <h3>OPEX</h3>
                </div>
                <div class="col-md-2 text-right">
                    <h3>
                        <asp:Label  ID="Label10" runat="server"></asp:Label></h3>
                </div>
                <div class="col-md-4 text-left">
                    <h3>
                        <asp:Label ID="Label19" runat="server"></asp:Label></h3>
                </div>
                <div class="mtb-30"></div>
            </div>
            <br clear="all" />
            <div class="form-group">
                <label class="col-md-6 control-label">Manpower</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBox8" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox8" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label20" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Incidental OPEX</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox7" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label5" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Network Cost</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox14" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="TextBox14" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="TextBox14" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label34" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Travelling</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBox9" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox9" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label21" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">IT Charges</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox10" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBox10" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox10" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label22" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Marketing Cost</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox11" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="TextBox11" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBox11" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label23" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Professional Charges</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox12" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TextBox12" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextBox12" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label24" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Others</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox13" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="TextBox13" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBox13" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label25" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label font-18">EBITDA</label>
                <div class="col-md-2 text-right font-18">
                    <asp:Label ID="Label7" runat="server"></asp:Label>

                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label26" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-head">
                <div class="mtb-30"></div>
                <div class="col-md-6">
                    <h3></h3>
                </div>
                <div class="col-md-6">
                    <h3></h3>
                </div>
                <div class="mtb-30"></div>
            </div>
            <br clear="all" />
            <div class="form-group">
                <label class="col-md-6 control-label">Depreciation</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox15" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="TextBox15" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TextBox15" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label27" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Net Interest <span style="font-size: 11px;">(Income or Expense)</span></label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox16" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="TextBox16" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TextBox16" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label28" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Others</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox17" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="TextBox17" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox17" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label29" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Share of Results</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox18" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="TextBox18" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TextBox18" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label30" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label">Tax</label>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox19" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="TextBox19" ValidationGroup="Group1" ErrorMessage="*" ValidationExpression="^[0-9]+([.][0-9]+)?$" ForeColor="#FFCC00"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TextBox19" ErrorMessage="*" ForeColor="Red" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label31" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <label class="col-md-6 control-label font-18">Profit After Tax</label>
                <div class="col-md-2 font-18 text-right">
                    <asp:Label ID="Label8" runat="server"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label32" runat="server" Font-Bold="False"></asp:Label>
                </div>
            </div>
        </div>
        <div class="mtb-30"></div>
        <br clear="all" />
        <div class="pull-right">
            <table class="btns-form">
                <tr>
                    <td>
                        <asp:Button ID="Button5_clear_all" runat="server" Text="Clear all" OnClick="Button5_Click_ClearAllData" />
                    </td>
                    <td>
                        <asp:Button ID="Button2_edit" runat="server" Text="Edit" OnClick="Button2_Click_EditData" ValidationGroup="ViewData" />
                    </td>
                    <td>
                        <asp:Button ID="Button3_save" runat="server" Text="Save &amp; Exit" OnClick="Button3_Click_SaveData" ValidationGroup="Group1" />
                    </td>
                    <td>
                        <asp:Button ID="Button4_submit" runat="server" Text="Submit" OnClick="Button4_Click_SubmitData" OnClientClick="Confirm()" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br clear="all"/>
    <div class="mtb-30"></div>
    <div class="col-lg-12 text-center"><p>2018 &copy; Axiata Digital - Financial Reporting</p></div>
    <div class="mtb-30"></div>
</asp:Content>
