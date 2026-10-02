Imports System.IO
Imports System.Xml.Serialization

Namespace SchedulerGSync

    Public Class ApplicationConfig

        Private Shared instanceField As ApplicationConfig

        Public Shared Property Instance As ApplicationConfig
            Get
                If instanceField Is Nothing Then instanceField = Load()
                Return instanceField
            End Get

            Private Set(ByVal value As ApplicationConfig)
                instanceField = value
            End Set
        End Property

        Private Shared Function Load() As ApplicationConfig
            Dim fileInfo = New FileInfo($"{NameOf(SchedulerGSync)}.appsettings")
            If Not fileInfo.Exists Then Return New ApplicationConfig()
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(ApplicationConfig))
            Using fileStream = fileInfo.OpenRead()
                Return CType(serializer.Deserialize(fileStream), ApplicationConfig)
            End Using
        End Function

        Public Sub New()
        End Sub

        Public Property CalendarId As String

        Public Sub Save()
            Dim fileInfo = New FileInfo($"{NameOf(SchedulerGSync)}.appsettings")
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(ApplicationConfig))
            Using fileStream = fileInfo.OpenWrite()
                serializer.Serialize(fileStream, Me)
            End Using
        End Sub
    End Class
End Namespace
