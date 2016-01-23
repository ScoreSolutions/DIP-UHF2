Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities

Public Class frmPermission

    Sub ShowPermissionMenu(ByVal arg As Int32)
        Dim dt As New DataTable
        Dim dal As New TbPermissionMenuDAL
        Dim sql As String = ""
        Dim chkMenu As Boolean = True

        '****************** Clear Checkbox ******************
        If gvMenuList.Rows.Count > 0 Then
            Dim chk As Boolean = False
            For i As Int32 = 0 To gvMenuList.Rows.Count - 1
                gvMenuList.Rows(i).Cells("cb").Value = chk
            Next
        End If
        '****************************************************

        dt = dal.GetDataList("Permission_id = " & arg, "", Nothing)
        If dt.Rows.Count > 0 Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                If gvMenuList.Rows.Count > 0 Then
                    For j As Int32 = 0 To gvMenuList.Rows.Count - 1
                        If gvMenuList.Rows(j).Cells("Menu_id").Value.ToString = dt.Rows(i).Item("Menu_id").ToString Then
                            gvMenuList.Rows(j).Cells("cb").Value = chkMenu
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Sub ShowPermissionOfficer(ByVal arg As Int32)
        Dim dt As New DataTable
        Dim dal As New TbPermissionOfficerDAL
        Dim sql As String = ""
        Dim chkMenu As Boolean = True

        '****************** Clear Checkbox ******************
        If gvOfficerList.Rows.Count > 0 Then
            Dim chk As Boolean = False
            For i As Int32 = 0 To gvOfficerList.Rows.Count - 1
                gvOfficerList.Rows(i).Cells("cb1").Value = chk
            Next
        End If
        '****************************************************

        dt = dal.GetDataList("Permission_id = " & arg, "", Nothing)
        If dt.Rows.Count > 0 Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                If gvOfficerList.Rows.Count > 0 Then
                    For j As Int32 = 0 To gvOfficerList.Rows.Count - 1
                        If gvOfficerList.Rows(j).Cells("officer_id").Value.ToString = dt.Rows(i).Item("officer_id").ToString Then
                            gvOfficerList.Rows(j).Cells("cb1").Value = chkMenu
                        End If
                    Next
                End If
            Next
        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim dal_Permission As New TbPermissionDAL
            Dim dal_PermissionMenu As New TbPermissionMenuDAL
            Dim dal_PermissionOfficer As New TbPermissionOfficerDAL
            Dim trans As New SqlTransactionDB
            Dim ret As Boolean = True
            Dim chk As Boolean = True
            Dim dt As New DataTable
            Dim Permission_id As Int32 = 0

            If txtPermission.Enabled = True Then
                'Insert
                dal_Permission.PERMISSION_NAME = txtPermission.Text.Trim
                ret = dal_Permission.InsertData(frmMain.txtUserName.Text, trans.Trans)
                dt = dal_Permission.GetDataList("Permission_name = '" & txtPermission.Text.Trim & "'", "", Nothing)
                Permission_id = dt.Rows(0).Item("id").ToString
                If ret = False Then
                    trans.RollbackTransaction()
                    MsgBox(dal_Permission.ErrorMessage)
                    Exit Sub
                End If

                For i As Int32 = 0 To gvMenuList.Rows.Count - 1
                    If gvMenuList.Rows(i).Cells("cb").Value = chk Then
                        dal_PermissionMenu = New TbPermissionMenuDAL
                        dal_PermissionMenu.PERMISSION_ID = Permission_id
                        dal_PermissionMenu.MENU_ID = gvMenuList.Rows(i).Cells("Menu_id").Value.ToString
                        ret = dal_PermissionMenu.InsertData(frmMain.txtUserName.Text, trans.Trans)
                        If ret = False Then
                            trans.RollbackTransaction()
                            MsgBox(dal_PermissionMenu.ErrorMessage)
                            Exit Sub
                        End If
                    End If
                Next

                If gvOfficerList.Rows.Count > 0 Then
                    For i As Int32 = 0 To gvOfficerList.Rows.Count - 1
                        If gvOfficerList.Rows(i).Cells("cb1").Value = chk Then
                            dal_PermissionOfficer = New TbPermissionOfficerDAL
                            dal_PermissionOfficer.PERMISSION_ID = Permission_id
                            dal_PermissionOfficer.OFFICER_ID = gvOfficerList.Rows(i).Cells("officer_id").Value.ToString
                            ret = dal_PermissionOfficer.InsertData(frmMain.txtUserName.Text, trans.Trans)
                            If ret = False Then
                                trans.RollbackTransaction()
                                MsgBox(dal_PermissionOfficer.ErrorMessage)
                                Exit Sub
                            End If
                        End If
                    Next
                End If
            Else
                'Update
                Permission_id = gvPermissionList.SelectedRows(0).Cells("permission_id").Value.ToString
                'dal_PermissionMenu.GetDataByid(Permission_id, trans.Trans)
                'dal_PermissionMenu.DeleteByid(trans.Trans)
                Permission_id = gvPermissionList.SelectedRows(0).Cells("permission_id").Value.ToString
                SqlDB.ExecuteNonQuery("delete from TB_PERMISSION_MENU where Permission_id = '" & Permission_id & "'")

                For i As Int32 = 0 To gvMenuList.Rows.Count - 1
                    If gvMenuList.Rows(i).Cells("cb").Value = chk Then
                        dal_PermissionMenu = New TbPermissionMenuDAL
                        dal_PermissionMenu.PERMISSION_ID = Permission_id
                        dal_PermissionMenu.MENU_ID = gvMenuList.Rows(i).Cells("Menu_id").Value.ToString
                        ret = dal_PermissionMenu.InsertData(frmMain.txtUserName.Text, trans.Trans)
                        If ret = False Then
                            trans.RollbackTransaction()
                            MsgBox(dal_PermissionMenu.ErrorMessage)
                            Exit Sub
                        End If
                    End If
                Next

                If gvOfficerList.Rows.Count > 0 Then
                    'dal_PermissionOfficer.GetDataByid(Permission_id, trans.Trans)
                    'dal_PermissionOfficer.DeleteByid(trans.Trans)
                    SqlDB.ExecuteNonQuery("delete from TB_PERMISSION_OFFICER where Permission_id = '" & Permission_id & "'")
                    For i As Int32 = 0 To gvOfficerList.Rows.Count - 1
                        If gvOfficerList.Rows(i).Cells("cb1").Value = chk Then
                            dal_PermissionOfficer = New TbPermissionOfficerDAL
                            dal_PermissionOfficer.PERMISSION_ID = Permission_id
                            dal_PermissionOfficer.OFFICER_ID = gvOfficerList.Rows(i).Cells("officer_id").Value.ToString
                            ret = dal_PermissionOfficer.InsertData(frmMain.txtUserName.Text, trans.Trans)
                            If ret = False Then
                                trans.RollbackTransaction()
                                MsgBox(dal_PermissionOfficer.ErrorMessage)
                                Exit Sub
                            End If
                        End If
                    Next
                End If

            End If

            If ret = True Then
                trans.CommitTransaction()
                MsgBox("บันทึกข้อมูลเรียบร้อย")
                btnClear.PerformClick()
            End If
        End If
    End Sub

    Sub ClearMenuList()
        If gvMenuList.Rows.Count > 0 Then
            Dim chk As Boolean = False
            For i As Int32 = 0 To gvMenuList.Rows.Count - 1
                gvMenuList.Rows(i).Cells("cb").Value = chk
            Next
        End If
    End Sub

    Sub ClearOfficerList()
        If gvOfficerList.Rows.Count > 0 Then
            Dim chk As Boolean = False
            For i As Int32 = 0 To gvOfficerList.Rows.Count - 1
                gvOfficerList.Rows(i).Cells("cb1").Value = chk
            Next
        End If
    End Sub

    Private Sub gvPermissionList_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gvPermissionList.CellMouseClick
        gvPermissionList.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue
        gvPermissionList.DefaultCellStyle.SelectionForeColor = Color.White
        ShowPermissionMenu(gvPermissionList.SelectedRows(0).Cells("permission_id").Value.ToString)
        ShowPermissionOfficer(gvPermissionList.SelectedRows(0).Cells("permission_id").Value.ToString)
        txtPermission.Text = gvPermissionList.SelectedRows(0).Cells("Permission_name").Value.ToString
        txtPermission.Enabled = False
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearMenuList()
        ClearOfficerList()
        txtPermission.Text = ""
        txtPermission.Enabled = True
        txtPermission.Focus()
        TabControl1.SelectedTab = TabPage1
        ShowData()
    End Sub

    Private Sub frmPermission_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowData()
        TabControl1.SelectedTab = TabPage2
        TabControl1.SelectedTab = TabPage1
    End Sub

    Sub ShowData()
        Dim dal As New TbPermissionDAL
        Dim dt As DataTable = dal.GetDataList("", "", Nothing)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("seq")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("seq") = i + 1
            Next
            gvPermissionList.AutoGenerateColumns = False
            gvPermissionList.DataSource = dt
        End If


        Dim sql1 As String = "select md.module_name, m.menu_name,m.id as menu_id from tb_module md inner join tb_menu m on m.module_id=md.id "
        gvMenuList.AutoGenerateColumns = False
        gvMenuList.DataSource = dal.GetListBySql(sql1, "module_name, menu_name", Nothing)
        gvMenuList.Columns("module_name").ReadOnly = True
        gvMenuList.Columns("menu_name").ReadOnly = True

        Dim sql2 As String = "select ff.id as officer_id,ltrim(isnull(tt.title_name,'') + ' ' + isnull(ff.fname,'') + ' ' + isnull(ff.lname,'')) staff_name, dp.department_name, ps.position_name "
        sql2 += " from tb_officer ff "
        sql2 += " left join tb_department dp on dp.id=ff.department_id"
        sql2 += " left join tb_position ps on ps.id=ff.position_id"
        sql2 += " left join TB_TITLE tt on ff.title_id = tt.id"
        gvOfficerList.AutoGenerateColumns = False
        gvOfficerList.DataSource = dal.GetListBySql(sql2, "fname,lname", Nothing)
        gvOfficerList.Columns("staff_name").ReadOnly = True
        gvOfficerList.Columns("department_name").ReadOnly = True
        gvOfficerList.Columns("position_name").ReadOnly = True

        gvPermissionList.DefaultCellStyle.SelectionBackColor = Color.White
        gvPermissionList.DefaultCellStyle.SelectionForeColor = Color.Black
        txtPermission.Focus()
    End Sub

    Private Function Validation() As Boolean
        Dim ret As Boolean = True
        Dim Num As Int32 = 0
        Dim dt As New DataTable
        Dim dal As New TbPermissionDAL

        If txtPermission.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกสิทธิ์การใช้งาน")
            txtPermission.Focus()
            Return ret
        End If

        If txtPermission.Enabled = True Then
            dt = dal.GetDataList("Permission_name = '" & txtPermission.Text.Trim & "'", "", Nothing)
            If dt.Rows.Count > 0 Then
                ret = False
                MsgBox("สิทธิ์การใช้งานซ้ำกับข้อมูลในระบบ")
                txtPermission.Focus()
                Return ret
            End If
        End If

        If gvMenuList.Rows.Count > 0 Then
            Dim chk As Boolean = True
            For i As Int32 = 0 To gvMenuList.Rows.Count - 1
                If gvMenuList.Rows(i).Cells("cb").Value = chk Then
                    Num = Num + 1
                    Exit For
                End If
            Next
            If Num = 0 Then
                ret = False
                MsgBox("กรุณาเลือกเมนูสิทธิ์การใช้งาน")
                Return ret
            End If
        Else
            ret = False
            MsgBox("กรุณาเพิ่มเมนูสิทธิ์การใช้งานก่อน")
            Return ret
        End If

        Return ret

    End Function

    Private Sub frmPermission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class