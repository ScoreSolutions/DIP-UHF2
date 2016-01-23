Module ModuleConfig

    Public LocalConnectionString As String = "Data Source=\My Documents\DIP.SDF" ' SQLCe Database File
    Public ExportFileName As String = "\My Documents\DIPExport.dat" ' File That Export From PC
    Public ReportFileName As String = "\My Documents\DIPImport.dat" ' File That Export To PC

    Public Function ApplicationPath() As String
        Dim path As String = System.IO.Path.GetDirectoryName( _
           System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        Return path
    End Function

End Module
