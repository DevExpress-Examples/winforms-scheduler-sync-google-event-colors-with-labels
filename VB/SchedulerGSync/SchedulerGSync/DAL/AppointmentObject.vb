Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Microsoft.EntityFrameworkCore

Namespace SchedulerGSync.DAL
	Public Class AppointmentObject

		Public Property Id() As Integer
		Public Property Start() As DateTime
		Public Property [End]() As DateTime
		Public Property Subject() As String
		Public Property AppointmentType() As Integer
		Public Property RecurrenceInfo() As String
		Public Property ReminderInfo() As String
		Public Property Location() As String
		Public Property Label() As String
		Public Property GId() As String
		Public Property ETag() As String
	End Class
End Namespace
