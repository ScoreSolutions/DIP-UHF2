Imports DIP_RFID.DAL.Table
Imports DIP_RFID.DAL.Common
Imports DIP_RFID.DAL.Common.Utilities
Imports DIP_RFID.Data.Table
Imports System.Data

Public Class frmTestGenerate

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim trans As New SqlTransactionDB
        Dim dal As New TestGenerateDAL

        trans.CreateTransaction()
        'dal.cr
        dal.COLUNIQUE = txtColUnique.Text
        dal.COLINT = txtColInt.Text
        dal.COLVARCHAR = txtColVarchar.Text
        dal.COLDATETIME = DateTime.Now
        If dal.InsertData("KKKKKK", trans.Trans) = True Then
            GetData(dal.ID, trans.Trans)
            trans.CommitTransaction()
            MsgBox("บันทึกข้อมูลเรียบร้อย")
        Else
            trans.RollbackTransaction()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GetData(3, Nothing)
    End Sub

    Private Sub GetData(ByVal id As Long, ByVal trans As SqlClient.SqlTransaction)
        Dim dal As New TestGenerateDAL
        Dim data As New TestGenerateData
        data = dal.GetDataByid(id, trans)
        txtID.Text = data.ID
        txtColUnique.Text = data.COLUNIQUE
        txtColInt.Text = data.COLINT
        txtColVarchar.Text = data.COLVARCHAR
        txtColDatetime.Text = data.COLDATETIME
        txtColCreateby.Text = data.CREATEBY
        txtColCreateon.Text = data.CREATEON
        txtColUpdateby.Text = data.UPDATEBY
        txtColUpdateon.Text = data.UPDATEON

        'Dim dal As New TestGenerateDAL
        'Dim dt As DataTable = dal.GetDataList("id=" & id, "colunique", Nothing)
        ''Dim dt As DataTable = dal.GetListBySql("select * from test_generate where id=" & id, "colunique", Nothing)
        ''Dim dt As DataTable = dal.get
        'txtID.Text = dt.Rows(0)("id")
        'txtColUnique.Text = dt.Rows(0)("COLUNIQUE")
        'txtColInt.Text = dt.Rows(0)("COLINT")
        'txtColVarchar.Text = dt.Rows(0)("COLVARCHAR")
        'txtColDatetime.Text = dt.Rows(0)("COLDATETIME")
        'txtColCreateby.Text = dt.Rows(0)("CREATEBY")
        'txtColCreateon.Text = dt.Rows(0)("CREATEON")
        ''txtColUpdateby.Text = dt.Rows(0)("UPDATEBY")
        ''txtColUpdateon.Text = dt.Rows(0)("UPDATEON")
    End Sub
End Class