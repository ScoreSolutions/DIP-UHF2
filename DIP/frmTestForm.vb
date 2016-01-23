Public Class frmTestForm

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bm As New Bitmap(180, 20)
        Dim g As Graphics = Graphics.FromImage(bm)
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        g.Clear(Color.White)
        g.DrawString("นายอัครวัฒน์ พุทธจันทร์", New Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 1, 2)

        bm.Save("C:\TestDrawTextImage.jpg", Imaging.ImageFormat.Jpeg)
        bm.Dispose()
        g.Dispose()


    End Sub
End Class