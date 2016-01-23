Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmSubfile

    Dim dt_AppNo As New DataTable
    Dim sql As String = ""
    Dim qty As Int32 = 0

    Private Sub frmSubfile_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    End Sub

    Private Sub GridAppNo_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles GridAppNo.CellBeginEdit
        Try
            qty = GridAppNo.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue.ToString
        Catch ex As Exception : End Try

    End Sub

    Private Sub GridAppNo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridAppNo.CellEndEdit
        'If GridAppNo.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue.ToString = "" Then
        '    dt_AppNo.Rows(e.RowIndex).Item("qty") = qty
        '    Exit Sub
        If CInt(GridAppNo.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue.ToString) < 1 Then
            MsgBox("กรอกตัวเลขที่มากกว่า 0 เท่านั้น")
            dt_AppNo.Rows(e.RowIndex).Item("qty") = qty
            Exit Sub
        End If
        Dim dal As New TbRequisitionDAL
        Dim trans As New SqlTransactionDB
        dal.GetDataByid(GridAppNo.Rows(e.RowIndex).Cells("id").Value.ToString, trans.Trans)
        dal.QTY = GridAppNo.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue.ToString
        dal.UpdateByid(frmMain.txtUserName.Text, trans.Trans)
    End Sub

    Private Sub GridAppNo_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles GridAppNo.DataError
        MsgBox(e.Exception.Message)
    End Sub

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
        dt_AppNo = dal.GetListBySql("select id,app_no,qty from TB_REQUISTION " & whe, "app_no", Nothing)
        GridAppNo.DataSource = dt_AppNo
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ShowData()
        If GridAppNo.RowCount = 0 Then
            MsgBox("ไม่พบข้อมูล")
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