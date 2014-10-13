<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Loan Amount:
        <asp:TextBox ID="txbxLoanAmount" runat="server"></asp:TextBox>
        <br />
        Annual Interest %:
        <asp:TextBox ID="txbxAnnualInterest" runat="server"></asp:TextBox>
        <br />
        Loan Term (Years):
        <asp:TextBox ID="txbxLoanTerm" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" />
        <br />
        <br />
        <asp:Label ID="lblWelcome" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
