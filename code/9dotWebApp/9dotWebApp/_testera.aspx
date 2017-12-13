<%@ Page Title="" Language="C#" MasterPageFile="~/9dot.Master" AutoEventWireup="true" CodeBehind="_testera.aspx.cs" Inherits="_9dotWebApp.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet" />--%>

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/smoothness/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
        $("#dialog").dialog({
            autoOpen: true,
            dialogClass: "no-close",
            buttons: [
              {
                  text: "Yes",
                  click: function () {
                      $(this).dialog("close");
                  }
              },
              {
                  text: "No",
                  click: function () {
                      $(this).dialog("close");
                  }
              }
            ]
        });
        function open() {
            $("#dialog").dialog("open");
        };
    </script>

    <%--<script type="text/javascript">
        function AlertBox(msgtitle, message, controlToFocus) {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            $("#msgDialogAlert").dialog({
                autoOpen: false,
                modal: true,
                title: msgtitle,
                closeOnEscape: true,
                buttons: [{
                    text: "Yes",
                    click: function () {
                        $(this).dialog("close");
                        confirm_value.value = "Yes";
                        if (controlToFocus != null)
                            controlToFocus.focus();
                    }
                }, {
                    text: "No",
                    click: function () {
                        $(this).dialog("close");
                        confirm_value.value = "No";
                        if (controlToFocus != null)
                            controlToFocus.focus();
                    }
                }],
                close: function () {
                    $("#operationMsgAlert").html("x");
                    if (controlToFocus != null)
                        controlToFocus.focus();
                },
                show: { effect: "clip", duration: 200 }
            });
            $("#operationMsgAlert").html(message);
            $("#msgDialogAlert").dialog("open");
            document.forms[0].appendChild(confirm_value);
        };

        function ShowMessage() {
            AlertBox("Confirmation", "Are you sure you want to save this data?", null);
            return false;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div id="msgDialogAlert" style="display: none; text-align: center; vertical-align: central;">
        <p id="operationMsgAlert"></p>
    </div>--%>

    Database Connection Info<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" OnClientClick="open()"/>
    <div id="dialog" title="Dialog Title">I'm a dialog</div>
 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>
