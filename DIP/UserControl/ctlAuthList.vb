Imports DIP_RFID.DAL.Table

Public Class ctlAuthList

    Private DragFrom As String
    Private _colID As String
    Private _colName As String

    Public WriteOnly Property ColID() As String
        Set(ByVal value As String)
            _colID = value
        End Set
    End Property
    Public WriteOnly Property ColName() As String
        Set(ByVal value As String)
            _colName = value
        End Set
    End Property

    Public Function GetRightList() As DataTable
        Return GetList(lstRightList)
    End Function
    Public Function GetLeftList() As DataTable
        Return GetList(lstLeftList)
    End Function

    Private Function GetList(ByVal lst As ListBox) As DataTable
        Dim ret As New DataTable
        If lst.Items.Count > 0 Then
            ret = lst.DataSource
        End If
        Return ret
    End Function

    Public Sub SetLeftList(ByVal dt As DataTable, ByVal valueMember As String, ByVal displayMember As String)
        SetList(lstLeftList, dt, valueMember, displayMember)
    End Sub
    Public Sub SetRightList(ByVal dt As DataTable, ByVal valueMember As String, ByVal displayMember As String)
        SetList(lstRightList, dt, valueMember, displayMember)
    End Sub

    Private Sub SetList(ByVal lst As ListBox, ByVal dt As DataTable, ByVal valueMember As String, ByVal displayMember As String)
        If dt.Rows.Count > 0 Then
            lst.DataSource = dt
            lst.ValueMember = valueMember
            lst.DisplayMember = displayMember
        End If
    End Sub

    Private Sub lstRightList_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstRightList.DragDrop
        SetDragDrop(e, lstRightList)
    End Sub

    Private Sub lstRightList_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstRightList.DragOver
        If e.Data.GetDataPresent("System.Data.DataRowView") Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub SetDragDrop(ByVal e As System.Windows.Forms.DragEventArgs, ByVal lst As ListBox)
        If e.Data.GetDataPresent("System.Data.DataRowView") Then
            Dim dRow As DataRowView = e.Data.GetData("System.Data.DataRowView")
            If lst.Items.Count > 0 Then
                Dim dt As DataTable = lst.DataSource
                Dim dr As DataRow = dt.NewRow
                dr(_colID) = dRow(_colID)
                dr(_colName) = dRow(_colName)
                dt.Rows.Add(dr)
                lst.DataSource = dt
            Else
                Dim dt As New DataTable
                dt.Columns.Add(_colID)
                dt.Columns.Add(_colName)

                Dim dr As DataRow = dt.NewRow
                dr(_colID) = dRow(_colID)
                dr(_colName) = dRow(_colName)
                dt.Rows.Add(dr)

                lst.DataSource = dt
                lst.ValueMember = _colID
                lst.DisplayMember = _colName
            End If
        End If
    End Sub

    Private Sub lstLeftList_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstLeftList.DragDrop
        'If DragFrom = "lstRightList" Then
        SetDragDrop(e, lstLeftList)
        'End If
    End Sub

    Private Sub lstLeftList_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstLeftList.DragOver
        If e.Data.GetDataPresent("System.Data.DataRowView") Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub lstLeftList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstLeftList.MouseDown
        If lstLeftList.Items.Count > 0 Then
            Dim index As Integer = lstLeftList.SelectedIndex
            Dim dRow As DataRowView = CType(lstLeftList.Items(index), DataRowView)
            Dim dde1 As DragDropEffects = DoDragDrop(dRow, DragDropEffects.All)

            Dim dt As DataTable = CType(lstLeftList.DataSource, DataTable)
            If dde1 = DragDropEffects.All Then
                dt.Rows.RemoveAt(index)
            End If
            lstLeftList.DataSource = dt
        End If
    End Sub

    Private Sub lstRightList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstRightList.MouseDown
        If lstRightList.Items.Count > 0 Then
            Dim index As Integer = lstRightList.SelectedIndex
            Dim dRow As DataRowView = CType(lstRightList.Items(index), DataRowView)
            Dim dde2 As DragDropEffects = DoDragDrop(dRow, DragDropEffects.All)

            Dim dt As DataTable = CType(lstRightList.DataSource, DataTable)
            If dde2 = DragDropEffects.All Then
                dt.Rows.RemoveAt(index)
            End If
            lstRightList.DataSource = dt
        End If
    End Sub

    Private Sub MoveItem(ByVal FromItem As ListBox, ByVal ToItem As ListBox)
        If FromItem.SelectedItems.Count > 0 Then

            Dim fDt As New DataTable
            Dim tDt As New DataTable
            Dim rDt As New DataTable

            fDt = FromItem.DataSource
            tDt = ToItem.DataSource
            rDt = fDt.Clone

            For i As Integer = 0 To FromItem.SelectedItems.Count - 1
                Dim dRow As DataRowView = FromItem.SelectedItems(i)
                If tDt Is Nothing Then
                    tDt = New DataTable
                    tDt.Columns.Add(_colID)
                    tDt.Columns.Add(_colName)
                End If
                Dim dr As DataRow = tDt.NewRow
                dr(_colID) = dRow.Item(_colID)
                dr(_colName) = dRow(_colName)
                tDt.Rows.Add(dr)
            Next
            ToItem.DataSource = tDt
            ToItem.ValueMember = _colID
            ToItem.DisplayMember = _colName

            For i As Integer = 0 To FromItem.Items.Count - 1
                If FromItem.GetSelected(i) = False Then
                    Dim dRow As DataRowView = FromItem.Items(i)
                    Dim dr As DataRow = rDt.NewRow
                    dr(_colID) = dRow.Item(_colID)
                    dr(_colName) = dRow(_colName)
                    rDt.Rows.Add(dr)
                End If
            Next
            FromItem.DataSource = rDt

        End If
    End Sub
    Private Sub MoveAllItem(ByVal FromItem As ListBox, ByVal ToItem As ListBox)
        If FromItem.Items.Count > 0 Then
            For i As Integer = 0 To FromItem.Items.Count - 1
                FromItem.SetSelected(i, True)
            Next
            MoveItem(FromItem, ToItem)
        End If
    End Sub

    Private Sub btnDelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelAll.Click
        MoveAllItem(lstLeftList, lstRightList)
    End Sub

    Private Sub btnDelSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelSel.Click
        MoveItem(lstLeftList, lstRightList)
    End Sub

    Private Sub btnAddSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSel.Click
        MoveItem(lstRightList, lstLeftList)
    End Sub

    Private Sub btnAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAll.Click
        MoveAllItem(lstRightList, lstLeftList)
    End Sub
End Class
