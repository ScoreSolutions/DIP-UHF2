Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmShelfName

    Dim dt_AppNo As New DataTable

    Sub ShowData()
        Dim whe As String = ""
        
        If txtReqNoFrom.Text <> "" And txtReqNoTo.Text <> "" Then
            whe = "where app_no between '" & txtReqNoFrom.Text & "' and '" & txtReqNoFrom.Text & "'"
        ElseIf txtReqNoFrom.Text <> "" And txtReqNoTo.Text = "" Then
            whe = "where app_no = '" & txtReqNoFrom.Text & "'"
        ElseIf txtReqNoFrom.Text = "" And txtReqNoTo.Text <> "" Then
            whe = "where app_no = '" & txtReqNoTo.Text & "'"
        End If

        Dim dal As New TbRequisitionDAL
        dt_AppNo = dal.GetListBySql("select id,app_no,shelf_name from TB_REQUISTION " & whe, "app_no", Nothing)
        GridAppNo.DataSource = dt_AppNo
    End Sub

    Private Sub frmShelfName_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtReqNoFrom.Focus()
    End Sub


    Private Sub btnTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        btnSave.Enabled = False
        ShowData()
        btnSave.Enabled = True
        If GridAppNo.RowCount = 0 Then
            MsgBox("ไม่พบข้อมูล")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If GridAppNo.RowCount = 0 Then
            MsgBox("กรุณาระบุช่วงของเลขที่เอกสาร")
            Exit Sub
        End If

        If txtShelf.Text.Trim = "" Then
            MsgBox("กรุณากรอกชั้นวางเอกสาร")
            Exit Sub
        End If

        Dim ret As Boolean = True
        Dim _err As String = ""
        Dim dal As New TbRequisitionDAL
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()

        For i As Int32 = 0 To GridAppNo.RowCount - 1
            dal.GetDataByid(GridAppNo.Rows(i).Cells("id").Value.ToString, trans.Trans)
            dal.SHELF_NAME = txtShelf.Text.Trim
            ret = dal.UpdateByid(frmMain.txtUserName.Text, trans.Trans)
            If ret = False Then
                _err = dal.ErrorMessage
                Exit For
            End If
        Next

        If ret = True Then
            trans.CommitTransaction()
            txtReqNoFrom.Text = ""
            txtReqNoTo.Text = ""
            txtShelf.Text = ""
            ShowData()
            MsgBox("บันทึกข้อมูลเรียบร้อย")
        Else
            trans.RollbackTransaction()
            MsgBox(_err)
        End If
    End Sub

    Private Sub txtReqNoFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReqNoFrom.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtReqNoTo.Focus()
        End If
    End Sub

    Private Sub txtReqNoTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReqNoTo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnSearch.Focus()
        End If
    End Sub

End Class