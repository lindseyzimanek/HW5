Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        'declare variables
        Dim loanAmount As Double
        Dim annualRate As Double
        Dim interestRate As Double
        Dim term As Integer
        Dim loanTerm As Integer
        Dim monthlyPayment As Double
        Dim paymentDate As Date

        'declare variables for loan amortization
        Dim interestPaid As Double
        Dim nBalance As Double
        Dim principal As Double

        'declare table to hold payment info
        Dim table As DataTable = New DataTable("ParentTable")
        Dim loanAmortTbl As DataTable = New DataTable("AmortizationTable")
        Dim tRow As DataRow

        'add default values to variables
        interestPaid = 0.0

        'convert input strings to appropriate variable assigned
        loanAmount = CDbl(txbxLoanAmount.Text)
        annualRate = CDbl(txbxAnnualInterest.Text)
        term = CDbl(txbxLoanTerm.Text)

        'format loan input to currency
        txbxLoanAmount.Text = FormatCurrency(loanAmount)

        'convert annual rate to monthly rate
        interestRate = annualRate / (100 * 12)

        'convert years (term) into months (loan term)
        loanTerm = term * 12

        'calculate monthly payment using converted interst rate and loan term
        monthlyPayment = loanAmount * interestRate / (1 - Math.Pow((1 + interestRate), (-loanTerm)))

        'display monthly payment in textbox and convert to currency
        lblMonthlyPmt.Text = FormatCurrency(monthlyPayment)

        'add items to listbox, format them for currency, and add pad spacing for each item
        loanAmortTbl.Columns.Add("Payment Number", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("Payment Date", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("Principal Paid", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("Interest Paid", System.Type.GetType("System.String"))
        loanAmortTbl.Columns.Add("New Balance", System.Type.GetType("System.String"))

        'payment now
        paymentDate = Date.Now

        'first payment is next month
        paymentDate = DateAdd("m", 1, paymentDate)

        'use loop to display loan balance and interst paid over term of loan
        For counterStart = 1 To loanTerm

            'perform calculations for amortization of loan
            interestPaid = loanAmount * interestRate
            principal = monthlyPayment - interestPaid
            nBalance = loanAmount - principal
            loanAmount = nBalance

            'write data to new row in gridview
            tRow = loanAmortTbl.NewRow()
            tRow("Payment Number") = String.Format(counterStart)
            tRow("Payment Date") = String.Format("{0:MM/dd/yyyy}", paymentDate)
            tRow("Principal Paid") = String.Format("{0:C}", principal)
            tRow("Interest Paid") = String.Format("{0:C}", interestPaid)
            tRow("New Balance") = String.Format("{0:C}", nBalance)
            loanAmortTbl.Rows.Add(tRow)

            'add one month to payment date
            paymentDate = DateAdd("m", 1, paymentDate)

            'loops to next counterStart and continues loop until counterStart requirements are met (loanTerm)
        Next counterStart

        loanGridView.DataSource = loanAmortTbl
        loanGridView.DataBind()

        loanGridView.Visible = True

    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txbxLoanAmount.Text = String.Empty
        txbxAnnualInterest.Text = String.Empty
        txbxLoanTerm.Text = String.Empty

        loanGridView.Visible = False

        lblMonthlyPmt.Text = String.Empty
    End Sub
End Class
