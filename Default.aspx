<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lindsey's Loan Calculator</title>
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
</head>
<body>
    <h1> Lindsey's Loan Calculator </h1>
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
        
        <%If Not IsPostBack Then%>
        <p>
        <asp:Label ID="lblWelcome" runat="server" Text="Welcome to my morgage calculator. Please complete the fields above to have your monthly payment and loan repayment schedule calculated for you."></asp:Label>
        </p>
       
        <%Else%>
        
        <br />

         Monthly Payment: &nbsp; <asp:Label ID="lblMonthlyPmt" runat="server"></asp:Label>
        
        <br />
        <br />
        
        <asp:GridView ID="loanGridView" runat="server" CssClass="cssgridview">
            <AlternatingRowStyle CssClass="alt" />
        </asp:GridView>

        <%End If%>
    
    </div>
    </form>
</body>
</html>
