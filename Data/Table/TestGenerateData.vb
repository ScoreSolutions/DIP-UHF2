﻿
Namespace Table
    'Represents a transaction for TEST_GENERATE table Data.
    '[Create by  on December, 19 2010]
    Public Class TestGenerateData

        'Generate Field List
        Dim _ID As Long = 0
        Dim _COLUNIQUE As String = ""
        Dim _COLINT As Long = 0
        Dim _COLVARCHAR As String = ""
        Dim _COLDATETIME As DateTime = New DateTime(1, 1, 1)
        Dim _CREATEBY As String = ""
        Dim _CREATEON As DateTime = New DateTime(1, 1, 1)
        Dim _UPDATEBY As String = ""
        Dim _UPDATEON As DateTime = New DateTime(1, 1, 1)

        'Generate Field Property 
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        Public Property COLUNIQUE() As String
            Get
                Return _COLUNIQUE
            End Get
            Set(ByVal value As String)
                _COLUNIQUE = value
            End Set
        End Property
        Public Property COLINT() As Long
            Get
                Return _COLINT
            End Get
            Set(ByVal value As Long)
                _COLINT = value
            End Set
        End Property
        Public Property COLVARCHAR() As String
            Get
                Return _COLVARCHAR
            End Get
            Set(ByVal value As String)
                _COLVARCHAR = value
            End Set
        End Property
        Public Property COLDATETIME() As DateTime
            Get
                Return _COLDATETIME
            End Get
            Set(ByVal value As DateTime)
                _COLDATETIME = value
            End Set
        End Property
        Public Property CREATEBY() As String
            Get
                Return _CREATEBY
            End Get
            Set(ByVal value As String)
                _CREATEBY = value
            End Set
        End Property
        Public Property CREATEON() As DateTime
            Get
                Return _CREATEON
            End Get
            Set(ByVal value As DateTime)
                _CREATEON = value
            End Set
        End Property
        Public Property UPDATEBY() As String
            Get
                Return _UPDATEBY
            End Get
            Set(ByVal value As String)
                _UPDATEBY = value
            End Set
        End Property
        Public Property UPDATEON() As DateTime
            Get
                Return _UPDATEON
            End Get
            Set(ByVal value As DateTime)
                _UPDATEON = value
            End Set
        End Property
    End Class
End Namespace