<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab_1___Temperature_Converter.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Temperature Converter</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</head>
<body class="container">
    <header class="jumbotron text-center">
        <h1>Temperature 
            <asp:Image ID="Image1" runat="server" Height="146px" ImageUrl="~/Images/Capture.PNG" Width="62px" />
&nbsp;Conversion</h1>
    </header>
    <main>
        <form id="form1" class="form-horizontal" runat="server">
            <div class="form-row">
                <div class="form-group col-sm-6">
                    <label for="ddlFrom">From:</label>
                    <asp:DropDownList ID="ddlFrom" class="form-control col-sm-6" runat="server">
                        <asp:ListItem Value="C">Celsius</asp:ListItem>
                        <asp:ListItem Value="F">Fahrenheit</asp:ListItem>
                        <asp:ListItem Value="K">Kelvin</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-sm-6">
                    <label for="ddlTo">To:</label>
                    <asp:DropDownList ID="ddlTo" class="form-control col-sm-6" runat="server">
                        <asp:ListItem Value="F">Fahrenheit</asp:ListItem>
                        <asp:ListItem Value="C">Celsius</asp:ListItem>
                        <asp:ListItem Value="K">Kelvin</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-6">
                    <label for="txtInput">Input:</label>
                    <asp:TextBox ID="txtInput" class="form-control col-sm-6" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="validator" runat="server" ErrorMessage="RequiredFieldValidator" Display="Dynamic" ControlToValidate="txtInput" Text="Input is a required field"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" class="validator" ErrorMessage="Input must be between -1000 and 1000" Display="Dynamic" ControlToValidate="txtInput" MinimumValue="-1000" MaximumValue="1000" Type="Double"></asp:RangeValidator>
                </div>
                <div class="form-group col-sm-6">
                    <label>Answer:</label>
                    <asp:Label ID="lblAnswer" class="form-control col-sm-6" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="form-row">
                <asp:Button ID="btnCalc" class="col-sm-3 btn" runat="server" Text="Calculate" OnClick="btnCalc_Click" />
                <div class="col-sm-3"></div>
                <asp:Button ID="btnClear" class="col-sm-3 btn" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" />
            </div>
        </form>
    </main>
</body>
</html>
