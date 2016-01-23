Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmShutdownMenu

    Dim dt As New DataTable
    Dim sql As String = ""

    Private Sub frmShutdownMenu_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowListCombobox()
        Clear()
    End Sub

    Sub ShowListCombobox()
        Dim dal_ShutdownMenu As New TbShutdownsMenuDAL
        Dim dal_Menu As New TbMenuDAL
        With cboCom
            .DataSource = dal_ShutdownMenu.GetListBySql("select distinct com_name from TB_SHUTDOWS_MENU", "com_name", Nothing)
            .DisplayMember = "com_name"
        End With

        With cboMenu
            .DataSource = dal_Menu.GetDataList("id in (2,3)", "", Nothing)
            .ValueMember = "id"
            .DisplayMember = "menu_name"
        End With

    End Sub

    Sub ShowData()
        Dim dal As New TbShutdownsMenuDAL
        Dim sqlDb As New SqlDB
        sql = "select TB_SHUTDOWS_MENU.id,convert(varchar(20),dateadd(yyyy,543,open_datetime),103) as stDate,"
        sql &= " CONVERT(varchar(5),open_datetime,108) open_time,"
        sql &= " CONVERT(varchar(5),close_datetime,108) close_time,menu_name,menu_id,s_status,"
        sql &= " case when s_status = 'Y' then 'ใช้งาน' else 'ไม่ใช้งาน' end as status_name"
        sql &= " from TB_SHUTDOWS_MENU left join TB_MENU on TB_SHUTDOWS_MENU.menu_id = TB_MENU.id"
        sql &= " where com_name = " & sqlDb.SetString(cboCom.SelectedItem(0).ToString)
        DataGridView1.DataSource = dal.GetListBySql(sql, "com_name", Nothing)
    End Sub

    'Private Sub cboCom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCom.LostFocus
    '    ShowData()
    'End Sub

    Private Sub cboCom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCom.SelectedValueChanged

        cboCom.SelectionStart = 0
        cboCom.SelectionLength = Len(cboCom.Text)
    End Sub

    Private Sub cboCom_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCom.SelectionChangeCommitted
        If btnAdd.Enabled = True Then
            ShowData()
        End If
    End Sub

    Private Function Validation() As Boolean
        Dim ret As Boolean = True
        If cboCom.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกชื่อเครื่อง")
            cboCom.Focus()
        ElseIf TxtDate.TextBox1.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณาระบุวันที่")
            cboCom.Focus()
        ElseIf CDbl(cbo_s_h.Text & "." & cbo_s_m.Text) >= CDbl(cbo_e_h.Text & "." & cbo_e_m.Text) Then
            ret = False
            MsgBox("รูปแบบของเวลาเปิด-ปิดไม่ถูกต้อง")
            cbo_e_h.Focus()
        ElseIf ChkDupData(Nothing) = True Then
            ret = False
            MsgBox("วันที่และเมนู ซ้ำกับข้อมูลในระบบ")
            TxtDate.Focus()
        End If
        Return ret
    End Function

    Private Function ChkDupData(ByVal trans As SqlTransaction) As Boolean
        Dim dal As New TbShutdownsMenuDAL
        Return dal.ChkDataByWhere("datediff(d,open_datetime,'" & FixDate(TxtDate.dtDate.Value) & "') = 0 and menu_id = '" & cboMenu.SelectedValue.ToString & "' and id <> '" & Val(txtId.Text) & "'", trans)
    End Function

    Sub Add()
        DataGridView1.Enabled = False
        cboCom.DropDownStyle = ComboBoxStyle.DropDown
        cboMenu.Enabled = True
        TxtDate.Enabled = True
        cbo_s_h.Enabled = True
        cbo_s_m.Enabled = True
        cbo_e_h.Enabled = True
        cbo_e_m.Enabled = True
        cb.Checked = True
        cb.Enabled = True
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
    End Sub

    Sub Clear()
        DataGridView1.Enabled = True
        cboCom.DropDownStyle = ComboBoxStyle.DropDownList
        cboCom.SelectedIndex = 0
        cboMenu.SelectedIndex = 0
        TxtDate.TextBox1.Text = ""
        cbo_s_h.SelectedIndex = 0
        cbo_s_m.SelectedIndex = 0
        cbo_e_h.SelectedIndex = 0
        cbo_e_m.SelectedIndex = 0
        cboCom.Enabled = True
        cboMenu.Enabled = False
        TxtDate.Enabled = False
        cbo_s_h.Enabled = False
        cbo_s_m.Enabled = False
        cbo_e_h.Enabled = False
        cbo_e_m.Enabled = False
        cb.Enabled = False
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        txtId.Text = ""
        ShowListCombobox()
        ShowData()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Add()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            Dim Starttime() As String = Split(DataGridView1.SelectedRows(0).Cells("open_time").Value.ToString, ":")
            Dim Endtime() As String = Split(DataGridView1.SelectedRows(0).Cells("close_time").Value.ToString, ":")
            DataGridView1.Enabled = False
            cboCom.Enabled = False
            cboMenu.Enabled = True
            TxtDate.Enabled = True
            cbo_s_h.Enabled = True
            cbo_s_m.Enabled = True
            cbo_e_h.Enabled = True
            cbo_e_m.Enabled = True
            cb.Enabled = True
            btnSave.Enabled = True
            btnCancel.Enabled = True
            btnAdd.Enabled = False
            cboMenu.SelectedValue = DataGridView1.SelectedRows(0).Cells("menu_id").Value.ToString
            cbo_s_h.SelectedIndex = cbo_s_h.FindString(Starttime(0))
            cbo_s_m.SelectedIndex = cbo_s_m.FindString(Starttime(1))
            cbo_e_h.SelectedIndex = cbo_e_h.FindString(Endtime(0))
            cbo_e_m.SelectedIndex = cbo_e_m.FindString(Endtime(1))
            TxtDate.dtDate.Value = CDate(DataGridView1.SelectedRows(0).Cells("stDate").Value.ToString)
            TxtDate.TextBox1.Text = TxtDate.dtDate.Value
            txtId.Text = DataGridView1.SelectedRows(0).Cells("id").Value.ToString
            If DataGridView1.SelectedRows(0).Cells("s_status").Value.ToString.ToUpper.Trim = "Y" Then
                cb.Checked = True
            Else
                cb.Checked = True = False
            End If
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim ret As Boolean = True
            Dim dal = New TbShutdownsMenuDAL
            Dim trans As New SqlTransactionDB
            Dim status As Char = "N"
            Dim sqlDB As New SqlDB

            If cb.Checked = True Then
                status = "Y"
            End If

            If txtId.Text = "" Then
                'Insert
                dal.COM_NAME = cboCom.Text
                dal.MENU_ID = cboMenu.SelectedValue.ToString
                dal.OPEN_DATETIME = TxtDate.dtDate.Value.ToShortDateString & " " & cbo_s_h.Text & ":" & cbo_s_m.Text
                dal.CLOSE_DATETIME = TxtDate.dtDate.Value.ToShortDateString & " " & cbo_e_h.Text & ":" & cbo_e_m.Text
                dal.S_STATUS = status
                ret = dal.InsertData(frmMain.txtUserName.Text, trans.Trans)
            Else
                'Update
                dal.GetDataByid(txtId.Text, trans.Trans)
                dal.COM_NAME = cboCom.Text
                dal.MENU_ID = cboMenu.SelectedValue.ToString
                dal.OPEN_DATETIME = TxtDate.dtDate.Value.ToShortDateString & " " & cbo_s_h.Text & ":" & cbo_s_m.Text
                dal.CLOSE_DATETIME = TxtDate.dtDate.Value.ToShortDateString & " " & cbo_e_h.Text & ":" & cbo_e_m.Text
                dal.S_STATUS = status
                ret = dal.UpdateByid(frmMain.txtUserName.Text, trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
                MsgBox("บันทึกข้อมูลเรียบร้อย")
                Clear()
                ShowData()
            Else
                trans.RollbackTransaction()
                MsgBox(dal.ErrorMessage)
            End If
        End If

    End Sub

End Class