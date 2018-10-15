<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebSite1.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Temperature Conversion Program</title>
    <script>
        function UpdateDate()
        {
            var today = new Date();
            document.write("<h2>" + today + "</h2>");
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>
</head>
<body>
    <h1>Temperature Conversion Program</h1>
    <h2>
        <script>
            var today = new Date();
            document.write(today);
        </script>
    </h2>

    <form id="form1" runat="server">
    <div style="height: 148px; width: 1350px">
    
        <table border="10" style="width: 522px">
            <caption>Temperature</caption>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Enter Input Temperature:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtITemp" runat="server" Height="16px"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="baseTemp" runat="server">
                        <asp:ListItem>F</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Converted Temperature:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOTemp" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Convert Temperature" />
                </td>
            </tr>
            
        </table>
        <br />
        <br />
        <br />        
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />    
    
    </div>
    <p>
        &nbsp;<input id="Button2" type="button" value="Show Date" /></p>
    </form>
    </body>
</html>
