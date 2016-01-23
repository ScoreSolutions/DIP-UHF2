Imports DIP_RFID.DAL.Table

Public Class frmReturnByPatentType

    Private Sub frmReturnByPatentType_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim dal As New TbPatentTypeDAL
        Dim dt As DataTable = dal.GetDataList("", "patent_type_name", Nothing)
        Dim dr As DataRow = dt.NewRow
        dr("id") = "0"
        dr("patent_type_name") = "--------------------เลือก-------------------"
        dt.Rows.InsertAt(dr, 0)
        With cmbPatentType
            .DataSource = dt
            .ValueMember = "id"
            .DisplayMember = "patent_type_name"
        End With

    End Sub

    Private Sub btnPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewReport.Click

    End Sub

End Class