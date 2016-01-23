Imports System.Data
Imports System.Data.SqlClient
Imports DIP_RFID.DAL
Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common.Utilities
Imports DIP_RFID.Data.Common.Utilities


Public Class frmOfficer

    Dim _err As String = ""

    Private Sub frmOfficer_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowData()
    End Sub

    Sub ShowData()

        Dim dal_position As New TbPositionDAL
        With cbPosition
            .DataSource = dal_position.GetDataList("1=1", "position_name", Nothing)
            .ValueMember = "id"
            .DisplayMember = "position_name"
        End With

        Dim dal_department As New TbDepartmentDAL
        With cbDepartment
            .DataSource = dal_department.GetDataList("1=1", "department_name", Nothing)
            .ValueMember = "id"
            .DisplayMember = "department_name"
        End With

        Dim dal_title As New TbTitleDAL
        With cbTitle
            .DataSource = dal_title.GetDataList("1=1", "title_name", Nothing)
            .ValueMember = "id"
            .DisplayMember = "title_name"
        End With

        SetData()
        
    End Sub

    Private Sub SetData()
        Dim dal As New TbOfficerDAL
        If txtId.Text.Trim <> "" Then
            dal.GetDataByid(txtId.Text.Trim, Nothing)
        End If

        'If dal.USERNAME <> "" Then
        '    txtUs.Text = dal.USERNAME
        '    'txtUs.ReadOnly = True
        'Else
        txtUs.Text = dal.USERNAME
        'txtUs.ReadOnly = False
        'End If
        txtPw.Text = ""
        txtCpw.Text = ""
        txtOfficerNo.Text = dal.OFFICER_NO
        txtfname.Text = dal.FNAME
        txtlname.Text = dal.LNAME
        cbTitle.SelectedValue = dal.TITLE_ID
        cbDepartment.SelectedValue = dal.DEPARTMENT_ID
        cbPosition.SelectedValue = dal.POSITION_ID
        SetAuthList()
        txtOfficerNo.Focus()
    End Sub

    Private Sub SetAuthList()
        Dim poDal As New TbPermissionOfficerDAL
        CtlAuthGroupList.ColID = "id"
        CtlAuthGroupList.ColName = "permission_name"
        Dim gaSql As String = "select p.id, p.Permission_name "
        gaSql += " from TB_PERMISSION_OFFICER po"
        gaSql += " inner join TB_PERMISSION p on p.id=po.permission_id"
        gaSql += " where po.officer_id = '" & txtId.Text.Trim & "'"
        Dim dt As DataTable = poDal.GetListBySql(gaSql, "permission_name", Nothing)
        CtlAuthGroupList.SetLeftList(dt, "id", "permission_name")
        Dim pDal As New TbPermissionDAL
        CtlAuthGroupList.SetRightList(pDal.GetDataList("id not in (select permission_id from tb_permission_officer where officer_id = '" & txtId.Text & "')", "permission_name", Nothing), "id", "permission_name")
        CtlAuthGroupList.SetLeftList(pDal.GetDataList("id in (select permission_id from tb_permission_officer where officer_id = '" & txtId.Text & "')", "permission_name", Nothing), "id", "permission_name")

        Dim moSql As New TbOfficerMenuDAL
        CtlAuthPersonList.ColID = "id"
        CtlAuthPersonList.ColName = "menu_name"
        Dim maSql As String = "select m.id,m.menu_name "
        maSql += " from TB_OFFICER_MENU om "
        maSql += " inner join TB_MENU m on m.id=om.menu_id "
        maSql += " where om.officer_id = '" & txtId.Text.Trim & "'"
        Dim mDt As DataTable = pDal.GetListBySql(maSql, "menu_name", Nothing)
        If mDt.Rows.Count > 0 Then
            CtlAuthPersonList.SetLeftList(mDt, "id", "menu_name")
            Dim mDal As New TbMenuDAL
            CtlAuthPersonList.SetRightList(mDal.GetDataList("id not in (select menu_id from tb_officer_menu where officer_id = '" & txtId.Text & "')", "menu_name", Nothing), "id", "menu_name")
            CtlAuthPersonList.SetLeftList(mDal.GetDataList("id in (select menu_id from tb_officer_menu where officer_id = '" & txtId.Text & "')", "menu_name", Nothing), "id", "menu_name")
        Else
            maSql = "select m.id,m.menu_name "
            maSql += " from TB_MENU m"
            'maSql += " inner join TB_MENU m on m.id=om.menu_id "
            'maSql += " where om.officer_id = '" & txtId.Text.Trim & "'"
            Dim dt_menu As New DataTable
            dt_menu = pDal.GetListBySql(maSql, "menu_name", Nothing)
            CtlAuthPersonList.SetRightList(dt_menu, "id", "menu_name")

        End If
        

    End Sub

    Private Function SaveData(ByVal trans As SqlTransaction) As Boolean
        Dim retu As Boolean = False
        If Validation() = True Then
            Dim dal As New TbOfficerDAL
            If txtId.Text.Trim <> "" Then
                dal.GetDataByid(txtId.Text.Trim, trans)
            End If

            dal.USERNAME = txtUs.Text
            dal.OFFICER_NO = txtOfficerNo.Text.Trim
            dal.FNAME = txtfname.Text
            dal.LNAME = txtlname.Text
            dal.TITLE_ID = cbTitle.SelectedValue
            dal.POSITION_ID = cbPosition.SelectedValue
            dal.DEPARTMENT_ID = cbDepartment.SelectedValue

            Dim ret As Boolean = False
            If txtId.Text.Trim = "" Then
                dal.PASSWORD = Func.GetEncrypt(txtPw.Text)
                ret = dal.InsertData(frmMain.txtUserName.Text, trans)
            Else
                If txtPw.Text.Trim <> "" Then
                    dal.PASSWORD = Func.GetEncrypt(txtPw.Text)
                End If
                ret = dal.UpdateByid(txtId.Text, trans)
            End If

            If ret = True Then
                If SaveAuthGroup(dal.ID, trans) = True Then
                    If SaveAuthPerson(dal.ID, trans) = True Then
                        txtId.Text = dal.ID
                        retu = True
                    Else
                        retu = False
                    End If
                Else
                    retu = False
                End If
            Else
                _err = dal.ErrorMessage
                retu = False
            End If
        Else
            retu = False
        End If

        Return retu
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim trans As New SqlTransactionDB
        trans.CreateTransaction()
        If SaveData(trans.Trans) = True Then
            trans.CommitTransaction()
            SetData()
            MsgBox("บันทึกข้อมูลเรียบร้อย")
        Else
            trans.RollbackTransaction()
            MsgBox(_err, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Function SaveAuthGroup(ByVal vID As String, ByVal trans As SqlTransaction) As Boolean
        Dim ret As Boolean = True
        Dim dal As New TbPermissionOfficerDAL
        Dim delDt As DataTable = dal.GetDataList("officer_id = '" & vID & "'", "", trans)
        For Each dr As DataRow In delDt.Rows
            Dim dDel As New TbPermissionOfficerDAL
            dDel.GetDataByid(dr("id"), trans)
            If dDel.DeleteByid(trans) = False Then
                _err = "SaveAuthGroup dDel : " & dDel.ErrorMessage
                Return False
            End If
        Next

        Dim dt As DataTable = CtlAuthGroupList.GetLeftList()
        For Each dr As DataRow In dt.Rows
            Dim iDal As New TbPermissionOfficerDAL
            iDal.PERMISSION_ID = dr("id")
            iDal.OFFICER_ID = Val(vID)
            If iDal.InsertData(frmMain.txtUserName.Text, trans) = False Then
                _err = "SaveAuthGroup iDal : " & iDal.ErrorMessage
                Return False
            End If
        Next
        Return ret

    End Function
    Private Function SaveAuthPerson(ByVal vID As String, ByVal trans As SqlTransaction) As Boolean
        Dim ret As Boolean = True
        Dim dal As New TbOfficerMenuDAL
        Dim delDt As DataTable = dal.GetDataList("officer_id = '" & vID & "'", "", trans)
        For Each dr As DataRow In delDt.Rows
            Dim dDel As New TbOfficerMenuDAL
            dDel.GetDataByid(dr("id"), trans)
            If dDel.DeleteByid(trans) = False Then
                _err = "SaveAuthPerson dDel : " & dDel.ErrorMessage
                Return False
            End If
        Next

        Dim dt As DataTable = CtlAuthPersonList.GetLeftList()
        For Each dr As DataRow In dt.Rows
            Dim iDal As New TbOfficerMenuDAL
            iDal.MENU_ID = dr("id")
            iDal.OFFICER_ID = Val(vID)
            If iDal.InsertData(frmMain.txtUserName.Text, trans) = False Then
                _err = "SaveAuthPerson iDal : " & iDal.ErrorMessage
                Return False
            End If
        Next
        Return ret
    End Function

    Private Function Validation() As Boolean
        Dim ret As Boolean = True
        If txtUs.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกชื่อผู้ใช้ระบบ")
            txtUs.Focus()
        ElseIf txtPw.Text.Trim <> txtCpw.Text.Trim And txtId.Text.Trim = "" Then
            ret = False
            MsgBox("การยืนยันรหัสผ่านไม่ตรงกัน")
            txtCpw.Focus()
        ElseIf txtPw.Text.Trim = "" And txtId.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกรหัสผ่าน")
            txtPw.Focus()
        ElseIf txtCpw.Text.Trim = "" And txtId.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกยืนยันรหัสผ่าน")
            txtCpw.Focus()
        ElseIf txtOfficerNo.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกรหัสเจ้าหน้าที่")
            txtOfficerNo.Focus()
        ElseIf txtfname.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกชื่อ")
            txtfname.Focus()
        ElseIf txtlname.Text.Trim = "" Then
            ret = False
            MsgBox("กรุณากรอกนามสกุล")
            txtlname.Focus()
        ElseIf ChkDupData(Nothing) = True Then
            ret = False
            MsgBox("ชื่อเข้าระบบซ้ำ")
            txtUs.Focus()
        End If
        Return ret
    End Function

    Private Function ChkDupData(ByVal trans As SqlTransaction) As Boolean
        Dim dal As New TbOfficerDAL
        Return dal.ChkDataByWhere("username = '" & txtUs.Text.Trim & "' and id <> '" & Val(txtId.Text) & "'", trans)
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        SetData()
    End Sub

    Private Sub btnSaveRFID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRFID.Click
        Dim ini As New IniReader(INIFlieName)
        ini.Section = "SETTING"
        Dim port As Int32 = ini.ReadString("MF_ComPort")

        Dim ctl As New MifareControl
        If ctl.Connect(port, 9600) = True Then
            Dim act As MifareControl.ActivityStatus
            act = ctl.SelectTag()
            If act.Available = True Then
                Dim trans As New SqlTransactionDB
                trans.CreateTransaction()
                If SaveData(trans.Trans) = True Then
                    If WriteToMyFair(act.Result, trans.Trans) = True Then
                        trans.CommitTransaction()
                        SetData()
                        MsgBox("บันทึกข้อมูลในบัตรเจ้าหน้าที่เรียบร้อย")
                    Else
                        trans.RollbackTransaction()
                        MsgBox(trans.ErrorMessage)
                    End If
                Else
                    trans.RollbackTransaction()
                    MsgBox(_err, MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("กรุณาแตะบัตรที่เครื่องอ่าน")
            End If
            ctl.DisConnect()
        End If
    End Sub

    Private Function WriteToMyFair(ByVal vMifareCardID As String, ByVal trans As SqlTransaction) As Boolean
        Dim dal As New TbOfficerDAL
        SqlDB.ExecuteNonQuery("update tb_officer set mifare_card_id=null where mifare_card_id='" & vMifareCardID & "'", trans)

        dal.GetDataByid(txtId.Text, trans)
        dal.MIFARE_CARD_ID = vMifareCardID
        Return dal.UpdateByid(frmMain.txtUserName.Text.Trim, trans)

    End Function

    Private Sub frmOfficer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmLogin.Timer1.Enabled = False
    End Sub

    Private Sub frmOfficer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmLogin.Timer1.Enabled = True
    End Sub
End Class