Public Class txtDate

    Public Property DateValue() As Date
        Get
            Dim ret As Date
            If TextBox1.Text.Trim() <> "" Then
                ret = dtDate.Value
            End If
            Return ret
        End Get
        Set(ByVal value As Date)
            'dtDate.Value = value
            'TextBox1.Text = value.ToShortDateString
        End Set
    End Property
    Public ReadOnly Property TextDate() As String
        Get
            Return TextBox1.Text.Trim
        End Get
    End Property

    Public ReadOnly Property DateCondition() As String
        Get
            Dim vDate As String = dtDate.Value.Day.ToString.PadLeft(2, "0")
            Dim vMonth As String = dtDate.Value.Month.ToString.PadLeft(2, "0")
            Dim vYear As String
            If dtDate.Value.Year > 2500 Then
                vYear = (dtDate.Value.Year - 543).ToString
            Else
                vYear = dtDate.Value.Year.ToString
            End If
            Return vYear & "-" & vMonth & "-" & vDate
        End Get
    End Property

    Private Sub dtDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtDate.ValueChanged
        TextBox1.Text = dtDate.Value.ToShortDateString
        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = Len(TextBox1.Text)
    End Sub

    Private Sub txtDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'dtDate.Value = DateTime.Now.Date
        'TextBox1.Text = ""
    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = Len(TextBox1.Text)
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 8 Then
            TextBox1.Text = ""
        Else
            e.Handled = True
        End If
    End Sub
End Class
