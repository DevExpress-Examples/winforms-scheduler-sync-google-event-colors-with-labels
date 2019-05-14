Imports System
Imports System.IO
Imports System.Linq
Imports System.Xml.Serialization

Namespace SchedulerGSync
	Public Class ApplicationConfig
		Private Shared privateInstance As ApplicationConfig = Load()
		Public Shared Property Instance() As ApplicationConfig
			Get
				Return privateInstance
			End Get
			Private Set(ByVal value As ApplicationConfig)
				privateInstance = value
			End Set
		End Property

		Shared Function Load() As ApplicationConfig
			Dim fileInfo = New FileInfo($"{NameOf(SchedulerGSync)}.appsettings")
			If Not fileInfo.Exists Then
				Return New ApplicationConfig()
			End If
			Dim serializer As New XmlSerializer(GetType(ApplicationConfig))
			Using fileStream = fileInfo.OpenRead()
				Return DirectCast(serializer.Deserialize(fileStream), ApplicationConfig)
			End Using
		End Function

		Public Sub New()
		End Sub

		Public Property CalendarId() As String

		Public Sub Save()
			Dim fileInfo = New FileInfo($"{NameOf(SchedulerGSync)}.appsettings")
			Dim serializer As New XmlSerializer(GetType(ApplicationConfig))
			Using fileStream = fileInfo.OpenWrite()
				serializer.Serialize(fileStream, Me)
			End Using
		End Sub
	End Class
End Namespace
