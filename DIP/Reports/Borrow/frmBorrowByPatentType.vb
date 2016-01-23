Imports DIP_RFID.DAL.Table
Public Class frmBorrowByPatentType

    Private Sub frmBorrowByPatentType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dal As New TbPatentTypeDAL
        Dim dt As DataTable = dal.GetDataList("1=1", "patent_type_name", Nothing)
        Dim dr As DataRow = dt.NewRow
        dr("id") = 0
        dr("patent_type_name") = "-----------เลือก-----------"
        dt.Rows.InsertAt(dr, 0)

        cmbPatentType.DataSource = dt
        cmbPatentType.DisplayMember = "patent_type_name"
        cmbPatentType.ValueMember = "id"
    End Sub


    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click

    End Sub
End Class